
--Section 1. DDL 
CREATE DATABASE [WMS]
GO

CREATE TABLE [Clients]
(
[ClientId] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50) NOT NULL,
[LastName ] VARCHAR(50) NOT NULL,
[Phone] VARCHAR(12) NOT NULL,
CHECK (LEN([Phone]) = 12)
)

CREATE TABLE [Mechanics]
(
[MechanicId] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50) NOT NULL,
[LastName ] VARCHAR(50) NOT NULL,
[Address] VARCHAR(255) NOT NULL
)


CREATE TABLE [Models]
(
[ModelId] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Jobs]
(
[JobId] INT PRIMARY KEY IDENTITY,
[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
[Status] VARCHAR(11) DEFAULT ('Pending') NOT NULL,
[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
[IssueDate] DATETIME NOT NULL,
[FinishDate] DATETIME,
CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE [Orders]
(
[OrderId] INT PRIMARY KEY IDENTITY,
[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
[IssueDate] DATETIME,
[Delivered] BIT DEFAULT(0) NOT NULL
)

CREATE TABLE [Vendors]
(
[VendorId] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Parts]
(
[PartId] INT PRIMARY KEY IDENTITY,
[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
[Description] VARCHAR(255),
[Price] DECIMAL(6, 2) NOT NULL,
[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
[StockQty] INT DEFAULT(0) NOT NULL,
CHECK ([Price] > 0),
CHECK ([StockQty] >= 0)
)

CREATE TABLE [OrderParts]
(
[OrderId] INT FOREIGN KEY REFERENCES [Orders]([Orderid]) NOT NULL,
[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
[Quantity] INT  DEFAULT(1) NOT NULL,
PRIMARY KEY ([OrderId], [PartId]),
CHECK ([Quantity] > 0)
)

CREATE TABLE [PartsNeeded]
(
[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
[Quantity] INT DEFAULT(1),
PRIMARY KEY ([JobId], [PartId]),
CHECK ([Quantity] > 0)
)



-- 2. Insert
INSERT INTO [Clients]  VALUES
('Teri','Ennaco','570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene','Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie',	'Knipp', '805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')


INSERT INTO [Parts] ([SerialNumber], [Description], [Price], [VendorId]) VALUES
('WP8182119', 'Door Boot Seal',	117.86,	2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive',	13.94, 3)



--3. Update
UPDATE [Jobs]
   SET [MechanicId] = 3, [Status] = 'In Progress'
 WHERE [Status] = 'Pending'



--4. Delete 
DELETE FROM [OrderParts]
      WHERE [OrderId] = 19

DELETE FROM [Orders]
      WHERE [OrderId] = 19



--5. Mechanic Assignments
   SELECT m.[FirstName] + ' ' + m.[LastName] AS [Mechanic], j.[Status], j.[IssueDate]
     FROM [Mechanics] AS m
LEFT JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
 ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId]



 --6. Current Clients 
  SELECT c.[FirstName] + ' ' + c.[LastName] AS [Client],
DATEDIFF(DAY, j.[IssueDate], '2017-04-24') AS [Days going], j.[Status]
    FROM [Clients] AS c
    JOIN [Jobs] AS j ON c.[ClientId] = j.[ClientId]
   WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.[ClientId]



--7. Mechanic Performanc
--SELECT [Mechanic], AVG([Average Days Query]) AS [Average Days] FROM
--     (
--       SELECT m.[MechanicId], m.[FirstName] + ' ' + m.[LastName] AS [Mechanic],
--     DATEDIFF(DAY,j.IssueDate, j.[FinishDate]) AS [Average Days Query]
--         FROM [Mechanics] AS m
--         JOIN [Jobs] AS j ON m.[MechanicId] = j.MechanicId
--        WHERE j.[Status] = 'Finished'
--     ) AS [Avarage Days Query]
--GROUP BY [Mechanic], [MechanicId]
--ORDER BY [MechanicId]
-----------
  SELECT m.[FirstName] + ' ' + m.[LastName ] AS [Mechanic],
     AVG (DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
    FROM [Mechanics] AS m
    JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
   WHERE j.[Status] = 'Finished'
GROUP BY m.[MechanicId], m.[FirstName], m.[LastName]
ORDER BY m.[MechanicId]



--8. Available Mechanics 
SELECT [FirstName] + ' ' + [LastName] AS [Available] FROM [Mechanics]
 WHERE [MechanicId] NOT IN 
	(
	SELECT [MechanicId] FROM [Jobs]
	WHERE [Status] = 'In Progress'
    GROUP BY [MechanicId]
	)



--9. Past Expenses
   SELECT j.[JobId], ISNULL(SUM(p.[Price] * op.[Quantity]), 0) AS [Total]
     FROM [Jobs] AS j
LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
LEFT JOIN [Parts] AS p ON op.[PartId] = p.[PartId]
    WHERE j.[Status] = 'Finished'
 GROUP BY j.[JobId]
 ORDER BY [Total] DESC, j.[JobId]



--10. Missing Parts 
SELECT p.[PartId],
       p.[Description],
       SUM(pn.[Quantity]) AS [Required],
	   SUM(p.[StockQty]) AS [In Stock],
       ISNULL(SUM(op.[Quantity]), 0) AS [Ordered]
     FROM [Jobs] AS j
LEFT JOIN [PartsNeeded] AS pn ON j.[JobId] = pn.[JobId]
LEFT JOIN [Parts] AS p ON pn.[PartId] = p.[PartId]
LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
    WHERE j.[Status] <> 'Finished'
 GROUP BY p.[PartId], p.[Description]
   HAVING SUM(pn.[Quantity]) > SUM(p.[StockQty]) + ISNULL(SUM(op.[Quantity]), 0)
 ORDER BY p.[PartId]  

-- SELECT * FROM 
--      (
--        SELECT p.[PartId],
--               p.[Description],
--               pn.[Quantity] AS [Required],
--               p.[StockQty] AS [In Stock],
--               ISNULL(op.[Quantity], 0) AS [Ordered]
--        FROM [Jobs] AS j
--        LEFT JOIN [PartsNeeded] AS pn ON j.[JobId] = pn.[JobId]
--        LEFT JOIN [Parts] AS p ON pn.[PartId] = p.[PartId]
--        LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
--        LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
--        WHERE j.[Status] <> 'Finished' AND (o.[Delivered] = 0 OR o.[Delivered] IS NULL)
--     ) AS [PartsQuantitySubQuery]
--WHERE [Required] > [In Stock] + [Ordered]
--ORDER BY [PartId]



--12. Cost Of Order
CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(8, 2)
AS
BEGIN
    DECLARE @totalCost DECIMAL(8, 2)
 
    DECLARE @jobOrdersCount INT = (SELECT COUNT(OrderId) FROM [Jobs] AS j
                                    LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
                                    WHERE j.[JobId] = @jobId
                                  )
    
    IF @jobOrdersCount = 0
        RETURN 0
 
    SET @totalCost =   (SELECT SUM(p.[Price] * op.[Quantity]) FROM [Jobs] AS j
                        LEFT JOIN [Orders] AS o ON j.[JobId] = o.[JobId]
                        LEFT JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
                        LEFT JOIN [Parts] AS p ON op.[PartId] = p.[PartId]
                        WHERE j.[JobId] = @jobId
                       )
 
    RETURN @totalCost
END