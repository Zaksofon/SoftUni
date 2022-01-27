
CREATE DATABASE [CigarShop]
GO

USE [CigarShop]
GO

CREATE TABLE [Sizes]
(
[Id] INT PRIMARY KEY IDENTITY,
[Length] INT NOT NULL,
[RingRange] DECIMAL (10, 2) NOT NULL,
CHECK ([Length] BETWEEN 10 AND 25),
CHECK ([RingRange] BETWEEN 1.5 AND 7.5)
)

CREATE TABLE [Tastes]
(
[Id] INT PRIMARY KEY IDENTITY,
[TasteType] VARCHAR (20) NOT NULL,
[TasteStrength] VARCHAR (15) NOT NULL,
[ImageURL] NVARCHAR (100) NOT NULL
)

CREATE TABLE [Brands]
(
[Id] INT PRIMARY KEY IDENTITY,
[BrandName] VARCHAR (30) UNIQUE NOT NULL,
[BrandDescription] VARCHAR (MAX),
)

CREATE TABLE [Cigars]
(
[Id] INT PRIMARY KEY IDENTITY,
[CigarName] VARCHAR (80) NOT NULL,
[BrandId] INT REFERENCES [Brands]([Id]) NOT NULL,
[TastId] INT REFERENCES [Tastes]([Id]) NOT NULL,
[SizeId] INT REFERENCES [Sizes]([Id]) NOT NULL,
[PriceForSingleCigar] DECIMAL (10, 2) NOT NULL,
[ImageURL] NVARCHAR (100) NOT NULL
)

CREATE TABLE [Addresses]
(
[Id] INT PRIMARY KEY IDENTITY,
[Town] VARCHAR (30) NOT NULL,
[Country] NVARCHAR (30) NOT NULL,
[Streat] NVARCHAR (100) NOT NULL,
[ZIP] VARCHAR (20) NOT NULL
)

CREATE TABLE [Clients]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR (30) NOT NULL,
[LastName] NVARCHAR (30) NOT NULL,
[Email] NVARCHAR (50) NOT NULL,
[AddressId] INT REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [ClientsCigars]
(
[ClientId] INT REFERENCES [Clients]([Id]),
[CigarId] INT REFERENCES [Cigars]([Id]),
PRIMARY KEY ([ClientId], [CigarId])
)


--2.Insert
INSERT INTO [Cigars] (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5,	15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2, 3, 8, 85.21,	'trinidad-coloniales-stick_30.jpg')


INSERT INTO [Addresses] (Town, Country, Streat,	ZIP) 
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)


--3. Update
UPDATE [Cigars] 
SET [PriceForSingleCigar] *= 1.2
WHERE [TastId] = 1

UPDATE [Brands] 
SET [BrandDescription] = 'New description'
WHERE [BrandDescription] IS NULL


-- 4. Delete
DELETE FROM [Clients]
 WHERE [Id] IN (7, 8, 10)

DELETE FROM [Addresses]
 WHERE [Country] LIKE 'C%'


--5. Cigars by Price
  SELECT [CigarName], [PriceForSingleCigar], [ImageURL] FROM Cigars
ORDER BY [PriceForSingleCigar], [CigarName] DESC


--6. Cigars by Taste
  SELECT c.[Id], c.[CigarName], c.[PriceForSingleCigar], t.[TasteType], t.[TasteStrength]
    FROM [Cigars] AS c
    JOIN [Tastes] AS t ON c.[TastId] = t.[Id]
   WHERE t.[TasteType] IN ('Earthy', 'Woody')
ORDER BY c.[PriceForSingleCigar] DESC
 

--7. Clients without Cigars
  SELECT c.[Id], c.[FirstName] + ' ' + c.[LastName] AS [ClientName], c.[Email]
    FROM [Clients] AS c
   WHERE c.[Id] NOT IN (SELECT [ClientId] FROM [ClientsCigars])
ORDER BY [ClientName]


--8. First 5 Cigars 
  SELECT TOP (5) c.[CigarName], c.[PriceForSingleCigar], c.[ImageURL] 
    FROM [Cigars] AS c
    JOIN [Sizes] AS s ON c.[SizeId] = s.[Id]
   WHERE c.[CigarName] LIKE '%ci%' 
      OR (c.[PriceForSingleCigar] > 50.00 AND s.[RingRange] > 2.55 AND s.[Length] >= 12)
ORDER BY c.[CigarName], c.[PriceForSingleCigar] DESC


--9. Clients with ZIP Codes 
  SELECT cl.[FirstName] + ' ' + cl.[LastName] AS [FullName], a.[Country], a.[ZIP], 
  CONCAT('$', MAX(c.[PriceForSingleCigar])) AS [CigarPrice]
    FROM [ClientsCigars] AS cc
    JOIN [Clients] AS cl ON cc.[ClientId] = cl.[Id]
    JOIN [Addresses] AS a ON cl.[AddressId] = a.[Id]
    JOIN [Cigars] AS c ON cc.[CigarId] = c.[Id]
   WHERE ISNUMERIC(a.[ZIP]) = 1
GROUP BY cl.[FirstName], cl.[LastName], a.[Country], a.[ZIP]
ORDER BY [FullName] 


--10. Cigars by Size 
  SELECT cl.[LastName], AVG(s.[Length]) AS [CiagrLength], 
 CEILING(AVG(s.[RingRange])) AS [CiagrRingRange] 
    FROM [ClientsCigars] AS cc
    JOIN [Clients] AS cl ON cc.[ClientId] = cl.[Id]
    JOIN [Cigars] AS c ON cc.[CigarId] = c.[Id]
    JOIN [Sizes] AS s ON c.[SizeId] = s.[Id]
GROUP BY cl.[LastName]
ORDER BY AVG(s.[Length]) DESC


--11. Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @TotalCigars INT = 
	(SELECT COUNT(*) FROM Clients c
    LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
		WHERE c.FirstName = @name)
	  RETURN @TotalCigars
END


--12. Search for Cigar with Specific Taste
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT c.CigarName, 
		CONCAT('$', c.PriceForSingleCigar),	t.TasteType, b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars c
		JOIN Sizes s ON c.SizeId = s.Id
		JOIN Tastes t ON c.TastId = t.Id
		JOIN Brands b ON c.BrandId = b.Id
		WHERE t.TasteType = @taste
	 ORDER BY CigarLength, CigarRingRange DESC
END