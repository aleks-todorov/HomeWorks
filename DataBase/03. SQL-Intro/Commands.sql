/* 4.Write a SQL query to find all information about all departments (use "TelerikAcademy" database).  */
SELECT * from Departments

/*5. Write a SQL query to find all department names.  */
SELECT d.Name from Departments d

/* 6. Write a SQL query to find the salary of each employee. */
SELECT e.Salary from Employees e

/* 7. Write a SQL to find the full name of each employee. */
SELECT e.FirstName + ' ' + e.LastName from Employees e

/*8. Write a SQL query to find the email addresses of each employee 
 (by his first and last name). Consider that the mail 
 domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
 The produced column should be named "Full Email Addresses".*/

SELECT FirstName + '.' + LastName + '@teleric.com'  
AS [Full Email Address] 
FROM Employees 

/* 9. Write a SQL query to find all different employee salaries. */
SELECT DISTINCT SALARY FROM Employees

/* 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.  */
SELECT * from Employees
where JobTitle = 'Sales Representative'

/* 11. Write a SQL query to find the names of all employees whose first name starts with "SA". */
SELECT FirstName, LastName from Employees
WHERE FirstName LIKE 'SA%'

/* 12. Write a SQL query to find the names of all employees whose last name contains "ei". */
SELECT FirstName, LastName from Employees
WHERE LastName LIKE '%EI%'

/* 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].  */
SELECT Salary from Employees
WHERE Salary BETWEEN 20000 AND 30000

/* 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. */
SELECT FirstName, LastName, Salary from Employees
WHERE Salary  IN(25000, 14000, 12500,23600)
 
/* 15. Write a SQL query to find all employees that do not have manager. */
SELECT FirstName, LastName, ManagerID from Employees
WHERE ManagerID is NULL

/* 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. */

SELECT FirstName, LastName, Salary from Employees
WHERE Salary >= 50000
Order BY Salary DESC
 
/* 17. Write a SQL query to find the top 5 best paid employees. */

SELECT TOP 5 FirstName, LastName, Salary from Employees
Order BY Salary DESC

/* 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause. */

SELECT e.FirstName, e.LastName, 
        a.AddressText AS Address
FROM Employees e 
INNER JOIN Addresses a 
ON a.AddressID = e.AddressID
	
/* 19.  Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). */

SELECT e.FirstName, e.LastName, 
a.AddressText AS Address
FROM Employees e , Addresses a  
WHERE a.AddressID = e.AddressID

/* 20. Write a SQL query to find all employees along with their manager. */

SELECT e.LastName EmpLastName,
       m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID


/* 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a. */

SELECT e.FirstName EmpFirstName, e.LastName EmpLastName,  
      m.LastName MgrLastName, a.AddressText [Manager Address]
FROM Employees e JOIN Employees m
  ON e.ManagerID = m.EmployeeID
  JOIN Addresses a
    ON m.AddressID = a.AddressID


/* 22. Write a SQL query to find all departments and all region names, country names and city names as a single list. Use UNION. */

Select d.Name FROM Departments d
UNION
Select t.Name FROM Towns t 

/* 23.  Write a SQL query to find all the employees and the manager for each of them along with the 
 employees that do not have manager. User right outer join. Rewrite the query to use left outer join.*/

SELECT e.LastName EmpLastName, m.LastName MgrLastName
FROM Employees m RIGHT OUTER JOIN Employees e
ON m.EmployeeID = e.ManagerID

SELECT e.LastName EmpLastName, m.LastName MgrLastName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID

/* 24. Write a SQL query to find the names of all employees from the departments 
"Sales" and "Finance" whose hire year is between 1995 and 2000. */
 
SELECT emp.FirstName + ' ' + emp.LastName AS [Employee Name], d.Name, emp.HireDate 
FROM Employees emp
JOIN Departments d 
ON emp.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') 
AND (YEAR(emp.HireDate) >= 1995
AND YEAR(emp.HireDate) <= 2003)











