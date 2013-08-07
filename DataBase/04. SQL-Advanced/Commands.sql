/* 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.*/

SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE Salary = (Select MIN(Salary) FROM Employees)

/* 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company. */

SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE Salary > (Select MIN(Salary) FROM Employees) A
ND Salary < (Select MIN(Salary)* 1.1 FROM Employees)

/* 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement. */

SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID

/* 4. Write a SQL query to find the average salary in the department #1. */

SELECT AVG(Salary) as AverageSalary from Employees e
WHERE e.DepartmentID = 1

/* 5. Write a SQL query to find the average salary  in the "Sales" department. */

SELECT AVG(Salary) as AverageSalary from Employees e
Join Departments d 
ON e.DepartmentID = d.DepartmentID
Where d.Name = 'Sales'

/* 6.  Write a SQL query to find the number of employees in the "Sales" department. */
SELECT COUNT(*) Cnt FROM Employees e
Join Departments d
On e.DepartmentID = d.DepartmentID
Where d.Name = 'Sales'
 
/* 7. Write a SQL query to find the number of all employees that have manager. */

SELECT COUNT(*) Cnt FROM Employees e
where e.ManagerID IS NOT NULL

/* 8. Write a SQL query to find the number of all employees that have no manager. */

SELECT COUNT(*) Cnt FROM Employees e
where e.ManagerID IS NULL

/* 9. Write a SQL query to find all departments and the average salary for each of them. */

SELECT DepartmentID, AVG(Salary) as AverageSalary
FROM Employees
GROUP BY DepartmentID

/* 10. Write a SQL query to find the count of all employees in each department and for each town. */

SELECT t.Name as Town, d.Name as Department, Count(*) as [Count]
FROM Employees e
Join Departments d
ON e.DepartmentID = d.DepartmentID
Join Addresses a
On e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID

Group BY t.Name, d.Name
 
/* 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. */
 
SELECT m.FirstName, m.LastName, COUNT(*) AS Number FROM (Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID)
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

/* 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)". */

SELECT e.LastName EmpLastName, COALESCE(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Manager Name]
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

/*13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function. */

SELECT e.FirstName, e.LastName
From Employees e 
WHERE  LEN(e.LastName) = 5

/* 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server. */

SELECT CONVERT(VARCHAR(24), GETDATE(), 113) as [Date]

/*15. Write a SQL statement to create a table Users. Users should have username, 
 password, full name and last login time. Choose appropriate data types for the table fields. 
 Define a primary key column with a primary key constraint. Define the primary key column as identity to 
 facilitate inserting records. Define unique constraint to avoid repeating usernames.
 Define a check constraint to ensure the password is at least 5 characters long. */
 
CREATE TABLE Users ( 
  ID int IDENTITY NOT NULL, 
  UserName  nvarchar(50) NOT NULL UNIQUE,
  Passwords nvarchar(50) NOT NULL check (len(Passwords) >= 5), 
  FullName nvarchar(100) NOT NULL,
  LastLogTime datetime, 
  CONSTRAINT PK_Persons PRIMARY KEY(ID) 
)
GO

/* 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly. */ 

CREATE VIEW [Users-View] AS
SELECT  * from Users

/* 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column. */

CREATE TABLE Groups ( 
  ID int IDENTITY NOT NULL, 
  Name  nvarchar(50) NOT NULL UNIQUE, 
  CONSTRAINT ID PRIMARY KEY(ID) 
)
GO

 /* 18. Write a SQL statement to add a column GroupID to the table Users. 
 Fill some data in this new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. */

ALTER TABLE Users ADD GroupID int
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(ID)
  
 /* 19. Write SQL statements to insert several records in the Users and Groups tables. */

INSERT INTO Users (UserName,Passwords,FullName,LastLogTime, GroupID)
VALUES ('John','132143', 'John Smith', '20:36:34.347', 4 )

INSERT INTO Groups (Name)
VALUES ('SixthGroup')

/* 20. Write SQL statements to update some of the records in the Users and Groups tables. */
UPDATE Users
SET Passwords='11111111'
WHERE UserName='Pesho';

 UPDATE Groups
SET Name='6thGroup'
WHERE ID='6';

/* 21. Write SQL statements to delete some of the records from the Users and Groups tables. */

DELETE FROM Users
WHERE UserName= 'John';

DELETE FROM Groups
WHERE Id= '6';

/*22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
 Combine the first and last names as a full name. For username use the first letter of the first name + the last name 
 (in lowercase). Use the same for the password, and NULL for last login time. */
 
INSERT INTO Users
 (UserName, Passwords, FullName, LastLogTime)
 (SELECT LOWER(LEFT(FirstName, 1) + LEFT(LastName, 1)), LOWER(LEFT(FirstName, 3) + LEFT(LastName, 3)), FirstName+ ' ' + LastName, NULL
  FROM Employees)

/* 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. */
 
UPDATE Users
SET Passwords = NULL
Where LastLogTime < '10/03.2010'

/* 24. Write a SQL statement that deletes all users without passwords (NULL password). */

DELETE Users
Where Passwords IS NULL

/* 25. Write a SQL query to display the average employee salary by department and job title. */
 
SELECT e.JobTitle,d.Name, AVG(Salary) as [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

/*26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.*/

SELECT e.FirstName + ' '+ e.LastName as [Employee Name], e.JobTitle,d.Name, MIN(Salary) as [MIN Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.FirstName + ' '+ e.LastName, e.JobTitle, d.Name

/* 27. Write a SQL query to display the town where maximal number of employees work. */

SELECT TOP 1 t.Name, 
COUNT(e.EmployeeID) as [Number oF Employes]  
FROM Towns t
JOIN Addresses a
ON t.TownID = a.TownID
JOIN Employees e
ON a.AddressID = e.AddressID 
GROUP BY t.Name  
ORDER BY COUNT(e.EmployeeID) DESC

/* 28. Write a SQL query to display the number of managers from each town. */ 

SELECT t.TownID, t.Name, COUNT(DISTINCT m.EmployeeID)
FROM Employees e 
JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON m.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.TownID, t.Name
ORDER BY COUNT(DISTINCT m.EmployeeID) DESC

/*29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. 
 Issue few SQL statements to insert, update and delete of some data in the table.
 Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete).*/

CREATE TABLE WorkHours ( 
  ID int IDENTITY NOT NULL, 
  UserID  int FOREIGN KEY REFERENCES Employees(EmployeeId),
  CurrentDate datetime, 
  Tasks nvarchar(100), 
  WorkingHours int, 
  Comments text, 
  CONSTRAINT PK_WorkHours PRIMARY KEY(ID)  
)
GO
 
INSERT INTO WorkHours(UserID,CurrentDate,Tasks,WorkingHours, Comments)
VALUES ('1',NULL, 'Perform Quality Checks', 8, 'Will have to do this in the next few days' )

INSERT INTO WorkHours(UserID,CurrentDate,Tasks,WorkingHours, Comments)
VALUES ('5',NULL, 'Perform Tests', 8, 'On plan for these actions' )

INSERT INTO WorkHours(UserID,CurrentDate,Tasks,WorkingHours, Comments)
VALUES ('4',NULL, 'Maintenance', 8, 'Whole day. Slacking !' )

UPDATE WorkHours
SET Tasks = 'Home sick' 
WHERE UserID= 5 ;

DELETE WorkHours
WHERE UserID = 4

/* 30. Start a database transaction, delete all employees from the 'Sales' 
department along with all dependent records from the pother tables. At the end rollback the transaction.*/

BEGIN TRAN

DELETE Departments
WHERE Name = 'Sales'

--Simple check to show that all related entries are deleted
SELECT e.FirstName, e.LastName, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN

/*31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data? */

BEGIN TRAN
DROP TABLE EmployeesProjects

SELECT * FROM EmployeesProjects

ROLLBACK TRAN

/*32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table. */

BEGIN TRAN

SELECT *
INTO #EmployeesProjectsBck
FROM EmployeesProjects

DROP TABLE EmployeesProjects
 
SELECT *
INTO EmployeesProjects
FROM #EmployeesProjectsBck
  
ROLLBACK TRAN

