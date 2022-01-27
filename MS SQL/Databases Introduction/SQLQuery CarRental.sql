--Task 14

CREATE DATABASE [CarRental]
USE [CarRental]
GO

CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR (30) NOT NULL,
[DailyRate] DECIMAL (6, 2) NOT NULL,
[WeeklyRate] DECIMAL (6, 2) NOT NULL,
[MonthlyRate] DECIMAL (6, 2) NOT NULL,
[WeekendRate] DECIMAL (6, 2) NOT NULL,
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate]) VALUES
	('Business', 150.00, 1000.00, 4000.00, 300.00),
	('Comfort', 220.00, 1500.00, 6000.00, 410.00),
	('Sport', 199.00, 1350.00, 5850.00, 390.00)

CREATE TABLE [Cars]
(
[Id] INT PRIMARY KEY IDENTITY,
[PlateNumber] VARCHAR (15) NOT NULL,
[Manufacturer] VARCHAR (30) NOT NULL,
[Model] VARCHAR (30),
[CarYear] VARCHAR (20),
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
[Doors] INT,
[Picture] VARCHAR (MAX),
[Condition] VARCHAR (20),
[Available] BIT
)

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available]) VALUES
	('MS-030-GG', 'Mercedess', 'E350', 2010, 1, 4, NULL, 'good', 1),
	('HT-056-JJ', 'Audi', 'A8', 2011, 2, 4, NULL, 'good', 1),
	('TR-304-UI', 'BMW', 'M5', 2014, 3, 4, NULL, 'excellent', 1)

CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR (50) NOT NULL,
[LastName] NVARCHAR (50) NOT NULL,
[Title] NVARCHAR (30),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes]) VALUES
    ('Rodger', 'Federer', 'Manager', 'cool'),
	('Grigor', 'Dimitrov', 'Receptionist', 'lazy'),
	('Rafael', 'Nadal', 'maintenance', 'determent')

CREATE TABLE [Customers]
(
[Id] INT PRIMARY KEY IDENTITY,
[DriverLicenceNumber] VARCHAR (50) NOT NULL,
[FullName] NVARCHAR (100) NOT NULL, 
[Adress] NVARCHAR (200) NOT NULL,
[City] NVARCHAR (30),
[ZIPCode	] NVARCHAR (15),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Adress], [City], [ZIPCode	], [Notes]) VALUES
    ('31684298112', 'Novak Djokovic', '20 Sandal Creek', 'Orlando', '32824', 'Awfull attitude, bad customer'),
	('32155678855', 'Andre Agassi', '135 Orange Ave', 'Albany', '12206', 'paid in full'),
	('61678955673', 'Pete Sampras',  '13345 Secvoia Gigantea', 'Atlanta', '11809', 'owes $3000')

CREATE TABLE [RentalOrders]
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
[TnakLevel] VARCHAR (10) NOT NULL,
[KilometrageStart] VARCHAR (10) NOT NULL,
[KilometrageEnd] VARCHAR (10) NOT NULL,
[TotalKilometrage] VARCHAR (10) NOT NULL,
[Startdate] VARCHAR (10) NOT NULL,
[EndDate] VARCHAR (10) NOT NULL,
[TotalDays] INT NOT NULL,
[RateApplied] DECIMAL (6, 2) NOT NULL,
[TaxRate] DECIMAL (6, 2) NOT NULL,
[OrderStatus] VARCHAR (30),
[Notes] NVARCHAR (MAX)
)

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TnakLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes]) VALUES
    (1, 1, 1, 'full', '889985346', '889985346', '889985346', '12/11/2021', '19/11/2021', 7, 875.00, 15.00, 'on time', 'paid'),
	(2, 2, 2, 'full', '459014553', '459014553', '459014553', '08/11/2021', '11/11/2021', 3, 495.00, 15.00, 'prepairing', 'paid'),
	(3, 3, 3, 'full',  '907771233', '907771233', '907771233', '10/11/2021', '14/11/2021', 4, 340.00, 15.00, 'ready for pick up', 'paid') 
