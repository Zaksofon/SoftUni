
--Task 1
CREATE DATABASE [TableRelations]
USE [TableRelations]
GO

CREATE TABLE [Passports]
(
[PassportID] INT PRIMARY KEY IDENTITY (101, 1) NOT NULL,
[PassportNumber] CHAR (8) NOT NULL
)

INSERT INTO [Passports] ([PassportNumber]) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

CREATE TABLE [Persons]
(
[PersonID] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] VARCHAR (30) NOT NULL,
[Salary] DECIMAL (10, 2) NOT NULL,
[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) NOT NULL UNIQUE
)

INSERT INTO [Persons] ([FirstName], [Salary], [PassportID]) VALUES
('Roberto', 43300.00, 101),
('Tom',	56100.00, 102),
('Yana', 60200.00, 103)

--Task 2
CREATE TABLE [Manufacturers]
(
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR (30) NOT NULL,
[EstablishedOn] CHAR (10) NOT NULL
)

INSERT INTO [Manufacturers] VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

CREATE TABLE [Models]
(
[ModelID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] NVARCHAR (30) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Models] VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--Task 3
USE [TableRelations]
GO

CREATE TABLE [Students]
(
[StudentID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR (30) NOT NULL
)

INSERT INTO [Students] VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE [Exams]
(
[ExamID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] NVARCHAR (30) NOT NULL
)

INSERT INTO [Exams] VALUES
('SpingMVC'),
('Neo4j'),
('Oracle 11g')

CREATE TABLE [StudentsExams]
(
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
CONSTRAINT PK_Students_Exams PRIMARY KEY ([StudentID], [ExamID])
)

INSERT INTO [StudentsExams] VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Task 4
CREATE TABLE [Teachers]
(
[TeacherID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] NVARCHAR (30) NOT NULL,
[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers] VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted',	 105),
('Mark', 101),
('Greta', 101)

--Problem 5
CREATE DATABASE [OnlineShop]
USE [OnlineShop]
Go

CREATE TABLE [Cities]
(
[CityID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (50) NOT NULL
)

CREATE TABLE [Customers]
(
[CustomerID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (50) NOT NULL,
[Birthday] DATE NOT NULL,
[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders]
(
[OrderID] INT PRIMARY KEY IDENTITY,
[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes]
(
[ItemTypeID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (50)
)

CREATE TABLE [Items]
(
[ItemID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (50),
[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems]
(
[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]),
CONSTRAINT PK_Orders_Items PRIMARY KEY ([OrderID], [ItemID])
)

--Task 6
CREATE DATABASE [University]
USE [University]
GO

CREATE TABLE [Subjects]
(
[SubjectID] INT PRIMARY KEY IDENTITY,
[SubjectName] VARCHAR (30) NOT NULL
)

CREATE TABLE [Majors]
(
[MajorID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (50) NOT NULL
)

CREATE TABLE [Students]
(
[StudentID] INT PRIMARY KEY IDENTITY,
[StudentNumber] CHAR (20) NOT NULL,
[StudentName] VARCHAR (30) NOT NULL,
[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments]
(
[PaymentID] INT PRIMARY KEY IDENTITY,
[Paymentdate] DATE NOT NULL,
[PaymentAmount] DECIMAL (8, 2) NOT NULL,
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

CREATE TABLE [Agenda]
(
[StudentID] INT	FOREIGN KEY REFERENCES [Students]([StudentID]),
[SubjectID]	INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
CONSTRAINT PK_Students_Subjects PRIMARY KEY ([StudentID], [SubjectID])
)

--Task 9
USE [Geography]
GO

SELECT * FROM [Mountains]
WHERE [MountainRange] = 'Rila'

SELECT * FROM [Peaks]
WHERE [MountainId] = 17

SELECT [MountainRange], [PeakName], [Elevation] FROM [Mountains]
JOIN [Peaks] ON [Peaks].[MountainId] = [Mountains].[Id]
WHERE [Mountains].[MountainRange] = 'Rila'
ORDER BY [Elevation] DESC