--Part I – Queries for SoftUni Database
USE [SoftUni1]
GO

--Problem 1.	 Find Names of All Employees by First Name
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'


--Problem 2.	 Find Names of All employees by Last Name 
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [LastName] LIKE '%ei%'


--Problem 3.	 Find First Names of All Employees
SELECT [FirstName] FROM [Employees]
WHERE [DepartmentID] IN (3, 10) 
AND DATEPART(YEAR, [HireDate]) BETWEEN 1995 AND 2005

--SELECT [FirstName] FROM [Employees]
--WHERE [DepartmentID] IN (3, 10) 
--AND [HireDate] BETWEEN '1994-12-31 00:00:00' AND '2005-12-31 00:00:00'


--Problem 4. Find All Employees Except Engineers
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'


--Problem 5.	Find Towns with Name Length
SELECT [Name] FROM [Towns]
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]


--Problem 6.	 Find Towns Starting With
SELECT * FROM [Towns]
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]


--Problem 7.	 Find Towns Not Starting With
SELECT * FROM [Towns]
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]


--Problem 8.	 Create View Employees Hired After 2000 Year
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT [FirstName], [LastName] FROM [Employees]
WHERE YEAR([HireDate]) > 2000


--Problem 9. Length of Last Name
SELECT [FirstName], [LastName] FROM [Employees]
WHERE LEN([LastName]) = 5


--Problem 10. Rank Employees by Salary
SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Ranked
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC


--Problem 11. Find All Employees with Rank 2 *
SELECT * FROM 
(
SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Ranked
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
)
AS [Result]
WHERE [Ranked] = 2
ORDER BY [Salary] DESC


--Part II – Queries for Geography Database 
USE [Geography]
GO

--Problem 12. Countries Holding ‘A’ 3 or More Times
SELECT [CountryName], [ISOCode] FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [ISOCode]


--Problem 13. Mix of Peak and River Names
SELECT [PeakName], [RiverName], LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName)
AS [Mix]
FROM [Peaks], [Rivers]
WHERE RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]


--Part III – Queries for Diablo Database
USE [Diablo]
GO

--Problem 14. Games from 2011 and 2012 year
SELECT TOP (50)[Name], 
FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]


--Problem 15. User Email Providers
SELECT [Username],
SUBSTRING([Email], CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], [Username]