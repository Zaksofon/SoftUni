
--Tasc 16
CREATE DATABASE [SoftUni]
GO
USE [SoftUni]
GO

CREATE TABLE [Towns]
(
[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
[Name] NVARCHAR (50) NOT NULL
)

CREATE TABLE [Addresses]
(
[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
[AddressText] NVARCHAR (50) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments]
(
[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
[Name] NVARCHAR (50) NOT NULL
)

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
[FirstName] NVARCHAR (50) NOT NULL,
[MiddleName] NVARCHAR (50) NOT NULL,
[LastName] NVARCHAR (50) NOT NULL,
[JobTitle] NVARCHAR (15) NOT NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
[Hiredate] VARCHAR (15) NOT NULL,
[Salary] DECIMAL (7, 2) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

--Task 18
INSERT INTO [Towns] VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments] VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees] VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88, NULL)

--Task 19
SELECT * FROM [Towns]
GO
SELECT * FROM [Departments]
GO
SELECT * FROM [Employees]
GO

--Task 20
SELECT * FROM [Towns]
ORDER BY [Name] ASC

SELECT * FROM [Departments]
ORDER BY [Name] ASC

SELECT * FROM [Employees]
ORDER BY [Salary] DESC

--Task 21
SELECT [Name] FROM [Towns]
ORDER BY [Name]

SELECT [Name] FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

--Task 22
UPDATE [Employees]
SET [Salary] = [Salary] * 1.1
SELECT [Salary] FROM [Employees]

--Task 23
USE [Hotel]
GO

UPDATE [Payments]
SET [TaxRate] = [TaxRate] * 0.97
SELECT [TaxRate] FROM [Payments]

