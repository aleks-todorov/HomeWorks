/*2. Create a stored procedure that accepts a number as a parameter and returns 
all persons who have more money in their accounts than the supplied number.*/

CREATE PROC dbo.usp_SelectBetterPaiedPersons (@minSum money)
AS
 SELECT p.FirstName, p.LastName, a.Balance From Persons p 
 JOIN Accounts a
 ON a.PersonID = p.ID
 WHERE a.Balance > @minSum
GO

EXEC dbo.usp_SelectBetterPaiedPersons 15000

/*3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.*/

CREATE FUNCTION ufn_CalcInterest  (@sum money, @yearlyInterest money, @months int)
  RETURNS money 
  AS
	BEGIN
	  DECLARE @result money
	  SET @result = @sum * ((@yearlyInterest /100) / @months) *@months
	  RETURN @result
	END
GO

SELECT dbo.ufn_CalcInterest(10000, 6, 12) as Interest

/*4. Create a stored procedure that uses the function from the previous example to give an interest 
to a person's account for one month. It should take the AccountId and the interest rate as parameters. */

CREATE PROC dbo.usp_AddInterest (@sum money, @yearlyInterest money)
AS
  SELECT dbo.ufn_CalcInterest(@sum, @yearlyInterest, 1) as Interest 
GO
 
EXEC dbo.usp_AddInterest 10000, 6

/*5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.*/
 
CREATE PROC dbo.usp_WithDrowMoney (@sum money, @userID int)
AS
DECLARE @balance money
SET  @balance = (Select Balance From Accounts where PersonID = @userid) 
IF @balance > @sum
BEGIN
UPDATE Accounts
SET Balance = Balance - @sum
WHERE PersonID= @userID ;
END
GO

CREATE PROC dbo.usp_DepositMoney (@sum money, @userID int)
AS 
BEGIN
UPDATE Accounts
SET Balance = Balance + @sum
WHERE PersonID= @userID ;
END
GO
 
 --Used to show the result 
 SELECT Balance FROM Accounts
 WHERE PersonID = 3

 EXEC dbo.usp_WithDrowMoney 5000, 3
 EXEC dbo.usp_DepositMoney 5000, 3

/*6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
 Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes*/

CREATE TRIGGER trg_LogChanges
ON dbo.Accounts AFTER UPDATE
AS
    INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT d.PersonID, d.Balance, ins.Balance
    FROM DELETED d, INSERTED ins

--Example operations
EXEC dbo.usp_WithDrowMoney 5000, 3
EXEC dbo.usp_DepositMoney 5000, 3
 

/*8. Using database cursor write a T-SQL script that scans all employees and 
their addresses and prints all pairs of employees that live in the same town. */

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT e1.FirstName + ' ' + e1.LastName, e2.FirstName + ' ' + e2.LastName, t1.Name
FROM Employees e1
JOIN Addresses a1
ON e1.AddressID = a1.AddressID
JOIN Towns t1
ON a1.TownID = t1.TownID, Employees e2
JOIN Addresses a2
ON e2.AddressID = a2.AddressID
JOIN Towns t2
ON a2.TownID = t2.TownID
WHERE t1.TownID = t2.TownID
AND e1.EmployeeID <> e2.EmployeeID

OPEN empCursor
DECLARE @firstEmp char(50), @secondEmp char(50), @town char(50)
FETCH NEXT FROM empCursor INTO @firstEmp, @secondEmp, @town

WHILE @@FETCH_STATUS = 0
BEGIN
PRINT @firstEmp + ' ' + @secondEmp + ' ' + @town
FETCH NEXT FROM empCursor
INTO @firstEmp, @secondEmp, @town
END

CLOSE empCursor
DEALLOCATE empCursor
 
