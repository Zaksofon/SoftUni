
CREATE DATABASE [Hotel]
USE [Hotel]
GO

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR (50) NOT NULL,
[LastName] NVARCHAR (50) NOT NULL,
[Title] NVARCHAR (30) NOT NULL,
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes]) VALUES
    ('Rodger', 'Federer', 'Manager', 'cool'),
	('Grigor', 'Dimitrov', 'Receptionist', 'lazy'),
	('Rafael', 'Nadal', 'maintenance', 'determent')

CREATE TABLE [Customers]
(
[AccountNumber] VARCHAR (30) NOT NULL,
[FirstName] NVARCHAR (50) NOT NULL,
[LastName] NVARCHAR (50) NOT NULL,
[PhoneNumber] NVARCHAR (15),
[EmergencyName] NVARCHAR (50),
[EmergencyNumber] NVARCHAR (15),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes]) VALUES
    (1, 'Novak', 'Djokovic', '+31684298112', 'Sevda', '+31344325678', 'Awfull attitude'),
	(2, 'Andre', 'Agassi', '+13215567885', 'Sara', '+13216678909', 'Great person'),
	(3, 'Pete', 'Sampras', '+16167895567', 'Shonda', '+16169908772', 'Old, but wise')

CREATE TABLE [RoomStatus]
(
[RoomStatus] NVARCHAR (10) NOT NULL,
[Notes] NVARCHAR (MAX)
)

INSERT INTO [RoomStatus] VALUES
	('Occupied', 'change bulb'),
	('Vacant', 'clean bathtub'),
	('Maintenace', 'AC')

CREATE TABLE [RoomTypes]
(
[RoomType] NVARCHAR (15) NOT NULL,
[Notes] NVARCHAR (MAX)
)

INSERT INTO [RoomTypes] VALUES
    ('One bedroom', 'cleaned'),
	('Two bedroom', 'cleaned'),
	('Studio', 'dirty')


CREATE TABLE [BedTypes]
(
[BedType] NVARCHAR (15) NOT NULL,
[Notes] NVARCHAR (MAX)
)

INSERT INTO [BedTypes] VALUES
	('One double bed', 'cleaned'),
	('Two double beds', 'cleaned'),
	('Sofa + one bed', 'ready')

CREATE TABLE [Rooms]
(
[RoomNumber] INT PRIMARY KEY NOT NULL,
[RoomType] NVARCHAR (15) NOT NULL,
[BedType] NVARCHAR (15) NOT NULL,
[Rate] DECIMAL (6, 2),
[RoomStatus] NVARCHAR (15) NOT NULL,
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Rooms] VALUES
    (100, 'One bedroom', 'One double bed', 125.00, 'Occupied', '7 days'),
	(101, 'Two bedroom', 'Two double beds', 165.00, 'Vacant', 'ready for rent'),
	(102, 'Studio', 'Sofa + one bed', 85.00, 'Maintenance', '1 day')

CREATE TABLE [Payments]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]),
[PaymentDate] VARCHAR (15) NOT NULL,
[AccountNumber] VARCHAR (30) NOT NULL,
[FirstDateOccupied] VARCHAR (15) NOT NULL,
[LastDateOccupied] VARCHAR (15) NOT NULL,
[TotalDays] INT NOT NULL,
[AmountCharged] DECIMAL (6, 2),
[TaxRate] DECIMAL (6, 2),
[TaxAmount] DECIMAL (6, 2),
[PaymentTotal] DECIMAL (6, 2),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Payments] VALUES
    (1, '19/11/2021', 889985346, '12/11/2021', '19/11/2021', 7, 875, 15.00, 131.25, 1006.25, 'paid'),
	(2, '11/11/2021', 459014553, '08/11/2021', '11/11/2021', 3, 495, 15.00, 74.25, 569.25, 'paid'),
	(3, '14/11/2021', 907771233, '10/11/2021', '14/11/2021', 4, 340, 15.00, 51.00, 391.00, 'paid')

CREATE TABLE [Occupancies]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]),
[DateOccupied] VARCHAR (15) NOT NULL,
[AccountNumber] VARCHAR (30) NOT NULL,
[RoomNumber] INT NOT NULL,
[RateApplied] DECIMAL (6, 2),
[PhoneCharge] DECIMAL (6, 2),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Occupancies] VALUES
    (1, '12/11/2021', 889985346, 100, 125.00, 0.00,  'paid'),
	(2, '08/11/2021', 459014553, 101, 165.00, 0.00, 'paid'),
	(3, '10/11/2021', 907771233, 102, 85.00, 0.00, 'paid')