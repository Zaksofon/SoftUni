USE [Geography]
GO

--Task 22
SELECT [PeakName] FROM [Peaks]
ORDER BY [PeakName]

--Task 23
SELECT TOP (30) [CountryName], [Population] FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName] DESC

--Task 24
SELECT [CountryName], [CountryCode],
CASE
    WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
    ELSE 'Not Euro'
END AS [Currency]
FROM [Countries] 
ORDER BY [CountryName]