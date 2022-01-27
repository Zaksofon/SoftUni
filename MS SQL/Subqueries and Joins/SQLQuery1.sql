USE [SoftUni1]
GO

--1.	 Employee Address
SELECT TOP (5) e.[EmployeeID], e.[JobTitle], a.[AddressID], a.[AddressText] 
      FROM [Employees] AS e
 LEFT JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
  ORDER BY e.[AddressID]


--2.	 Addresses with Towns
SELECT TOP (50) e.[FirstName], e.[LastName], t.[Name] AS [Town], a.[AddressText] 
      FROM [Employees] AS e
      JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
      JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
  ORDER BY e.[FirstName], e.[LastName]


--3. Sales Employee
  SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name] AS [DepartmentName]
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[DepartmentID] = 3
ORDER BY e.[EmployeeID]


--4.	 Employee Departments
SELECT TOP(5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name] AS [DepartmentName] 
      FROM [Employees] AS e
      JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
     WHERE e.[Salary] > 15000
  ORDER BY d.[DepartmentID] 


--5. Employees Without Project
SELECT TOP(3) e.[EmployeeID], e.[FirstName] FROM [Employees] AS e
 LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
     WHERE ep.[ProjectID] IS NULL
  ORDER BY e.[EmployeeID] ASC

--5. Employees Without Project - 2
SELECT TOP(3) [EmployeeID], [FirstName] FROM [Employees]
     WHERE [EmployeeID] NOT IN 
   (SELECT [EmployeeID] FROM [EmployeesProjects])
  ORDER BY [EmployeeID]


--6.	 Employees Hired After
  SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName] 
    FROM [Employees] AS e
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[HireDate] > '1999-01-01'
     AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.[HireDate]


--7.	 Employees with Project
SELECT TOP(5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName] 
      FROM [Employees] AS e
      JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
      JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
     WHERE p.[StartDate] > '2002-08-13'
       AND p.[EndDate] IS NULL
  ORDER BY e.[EmployeeID]


--8. Employee 24
   SELECT e.[EmployeeID], e.[FirstName],
     CASE
     WHEN YEAR(p.[StartDate]) >= '2005' THEN NULL
     ELSE p.[Name] 
	  END AS [ProjectName] 
	 FROM [Employees] AS e 
     JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	 JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
    WHERE e.[EmployeeID] = 24


--9. Employee Manager
 SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], m.[FirstName] AS [ManagerName]
   FROM [Employees] AS e
   JOIN [Employees] AS m ON m.[EmployeeID] = e.[ManagerID]
   WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID]


--10. Employee Summary
SELECT TOP(50) 
e.[EmployeeID], 
(e.[FirstName] + ' ' + e.[LastName]) AS [EmployeeName],
(m.[FirstName] + ' ' + m.[LastName]) AS [ManagerName], 
d.[Name] AS [DepartmentName]
     FROM [Employees] AS e
     JOIN [Employees] AS m ON m.[EmployeeID] = e.[ManagerID]
LEFT JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
 ORDER BY e.[EmployeeID]


--11. Min Average Salary
SELECT TOP(1) AVG(e.[Salary]) AS [MinAverageSalary] 
      FROM [Employees] AS e
      JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
  GROUP BY e.[DepartmentID]
  ORDER BY [MinAverageSalary]



  USE [Geography]
  GO

--12. Highest Peaks in Bulgaria
SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation] FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
WHERE mc.CountryCode = 'BG'
AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC


--13. Count Mountain Ranges
SELECT c.[CountryCode], COUNT(mc.[MountainID]) AS [MountainRanges] FROM [Countries] AS c
JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
WHERE c.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY c.[CountryCode]


--14. Countries with Rivers
SELECT TOP(5) c.[CountryName], r.[RiverName] FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]


--15. *Continents and Currencies
SELECT [ContinentCode], [CurrencyCode], [CurrencyCount] AS [CurrencyUsage]
FROM
  (
   SELECT *, DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS [CurrencyRank]
   FROM
        (  
        SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount] 
        FROM [Countries]
        GROUP BY [ContinentCode], [CurrencyCode]
        ) AS [Subquery1]
   WHERE [CurrencyCount] > 1 
   ) AS [CurrencyRankSubquery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]


--16. Countries Without Any Mountains
SELECT COUNT(*) - COUNT(m.[Id]) FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
WHERE m.[Id] IS NULL
	  
    
--17. Highest Peak and Longest River by Country
SELECT TOP(5) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]


--18. Highest Peak Name and Elevation by Country
SELECT TOP (5) [CountryName] AS [Country],
       ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
       ISNULL([Elevation], 0) AS [Highest Peak Elevation],
       ISNULL([MountainRange], '(no mountain)') AS [Mountain]
FROM (
        SELECT c.[CountryName],
               p.[PeakName],
               p.[Elevation],
               m.[MountainRange],
               DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
        FROM [Countries] AS c
        LEFT JOIN [MountainsCountries] AS mc
        ON c.[CountryCode] = mc.[CountryCode]
        LEFT JOIN [Mountains] AS m
        ON mc.[MountainId] = m.[Id]
        LEFT JOIN [Peaks] AS p
        ON m.[Id] = p.[MountainId]
     ) AS [PeaksRankingSubQuery]
WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]
