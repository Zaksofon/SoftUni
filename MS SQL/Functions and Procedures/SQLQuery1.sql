
--01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
SELECT "FirstName", "LastName" FROM "Employees"
 WHERE "Salary" > 35000
END



--02. Employees with Salary Above Number 
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@comaprisonSalaryNumber DECIMAL(18, 4))
AS
SELECT "FirstName", "LastName" FROM "Employees"
 WHERE "Salary" >= @comaprisonSalaryNumber



--03. Town Names Starting With 
CREATE PROC usp_GetTownsStartingWith (@townVariable NVARCHAR (30))
AS
SELECT "Name" FROM "Towns"
 WHERE "Name" LIKE @townVariable + '%'



--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@town NVARCHAR (50))
AS
SELECT e."FirstName", e."LastName" FROM "Employees" AS e
  JOIN "Addresses" AS a ON e."AddressID" = a."AddressID"
  JOIN "Towns" AS t ON a."TownID" = t."TownID"
 WHERE t."Name" = @town



--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
RETURNS VARCHAR (50)
AS
BEGIN
DECLARE @salaryLevel VARCHAR (50)
     IF (@salary < 30000) 
    SET @salaryLevel = 'Low'
ELSE IF (@salary BETWEEN 30000 AND 50000)
    SET @salaryLevel = 'Average'
   ELSE 
    SET @salaryLevel = 'High'
 RETURN @salaryLevel
END

--SELECT LOWER (FirstName), dbo.ufn_GetSalaryLevel (Salary) FROM "Employees"



--06. Employees by Salary Level 
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR (7))
AS
SELECT "FirstName", "LastName" FROM "Employees"
 WHERE dbo.ufn_GetSalaryLevel ("Salary") = @salaryLevel

--EXEC usp_EmployeesBySalaryLevel 'High'



--07. Define Function
CREATE FUNCTION dbo.ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR (MAX))
RETURNS BIT
BEGIN 
DECLARE @count INT = 1
WHILE (@count <= LEN(@word))
BEGIN
    DECLARE @currentLetter CHAR (1) = SUBSTRING (@word, @count, 1)
	IF (CHARINDEX (@currentLetter, @setOfLetters) = 0)
	RETURN 0
    SET @count += 1
END
RETURN 1
END

--SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')



--8. * Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
    ---First we need to delete all records from EmployeesProjects where EmployeeID is one of the lately deleted
    DELETE FROM [EmployeesProjects]
    WHERE [EmployeeID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    ---We need to set ManagerID to NULL of all Employees which have their Manager lately deleted
    UPDATE [Employees]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
 
    ---We need to alter ManagerID column from Departments in order to be nullable because we need to set
    ---ManagerID to NULL of all Departments that have their Manager lately deleted
    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT
 
    ---We need to set ManagerID to NULL (no Manager) to all departments that have their Manager lately deleted
    UPDATE [Departments]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    ---We need to delete all employees from the lately deleted department
    DELETE FROM [Employees]
    WHERE [DepartmentID] = @departmentId
 
    ---Lastly we delete wanted department
    DELETE FROM [Departments]
    WHERE [DepartmentID] = @departmentId
 
    SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END



----------------------------
USE "Bank"
GO

--09. Find Full Name 
CREATE PROC usp_GetHoldersFullName 
AS 
BEGIN
SELECT [FirstName] + ' ' + [LastName] AS [Full Name] 
FROM [AccountHolders]
END
--EXEC usp_GetHoldersFullName 



--10. People with Balance Higher Than 
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@amount DECIMAL)
AS
BEGIN
SELECT ah."FirstName" AS "First Name", ah."LastName" AS "Last Name"
  FROM "AccountHolders" AS ah
  JOIN "Accounts" AS a ON ah."Id" = a."AccountHolderId"
 WHERE a.Balance > @amount
 ORDER BY ah."FirstName", ah."LastName"
END
EXEC usp_GetHoldersWithBalanceHigherThan 100000



--11. Future Value Function
CREATE FUNCTION dbo.ufn_CalculateFutureValue (@sum DECIMAL (10, 4), @yearlyInterestRate FLOAT, @yearsCount INT)
RETURNS DECIMAL (10, 4)
BEGIN
  DECLARE @result DECIMAL (10, 5)
      SET @result = @sum * (POWER((1 + @yearlyInterestRate), @yearsCount))
   RETURN @result
END
--SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)



--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
BEGIN
 SELECT a."Id" AS "Account Id",
        ah."FirstName" AS "First Name",
		ah."LastName" AS "Last Name",
        a."Balance" AS "Current Balance",
		dbo.ufn_CalculateFutureValue(a."Balance", @interestRate, 5) AS "Ballance in 5 years"
   FROM "AccountHolders" AS ah
   JOIN "Accounts" AS a ON ah."Id" = a."AccountHolderId"
  WHERE a.Id = @accountId
END
--EXEC usp_CalculateFutureValueForAccount 1, 0.1


--13. *Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS 
RETURN SELECT(
            SELECT SUM([Cash]) AS [SumCash]
            FROM (
                    SELECT g.[Name],
                           ug.[Cash],
                           ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC) AS [RowNumber]
                      FROM [UsersGames] AS ug
                    JOIN [Games] AS g
                    ON ug.[GameId] = g.[Id]
                    WHERE g.[Name] = @gameName
                 ) AS [RowNumberSubQuery]
            WHERE [RowNumber] % 2 <> 0
         ) AS [SumCash]
 --SELECT * FROM ufn_CashInUsersGames('Love in a mist')