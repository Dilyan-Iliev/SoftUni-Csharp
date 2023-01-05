USE [SoftUni]

--T.01
SELECT TOP (5)
    [e].[EmployeeID],
    [e].[JobTitle],
    [e].[AddressID],
    [a].[AddressText]
FROM [Employees] as [e]
    JOIN [Addresses] as [a]
        ON [e].AddressID = [a].AddressID
ORDER BY [e].AddressID

--T.02
SELECT TOP (50)
    [e].[FirstName],
    [e].[LastName],
    [t].[Name],
    [a].[AddressText]
FROM [Employees] AS e
    JOIN [Addresses] AS [a]
        ON [e].AddressID = [a].AddressID
    JOIN [Towns] AS [t]
        ON [a].TownID = [t].TownID
ORDER BY [e].[FirstName],
         [e].[LastName]

--T.03
SELECT [e].[EmployeeID],
       [e].[FirstName],
       [e].[LastName],
       [d].[Name]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
        ON [e].DepartmentID = [d].DepartmentID
           AND [d].Name = 'Sales'
ORDER BY [e].[EmployeeID]

--T.04
SELECT TOP (5)
    [e].[EmployeeID],
    [e].[FirstName],
    [e].[Salary],
    [d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
        ON [e].DepartmentID = [d].DepartmentID
           AND [e].[Salary] > 15000
ORDER BY [e].[DepartmentID]

--T.05
SELECT TOP (3)
    [e].[EmployeeID],
    [e].[FirstName]
FROM [Employees] AS [e]
    LEFT JOIN [EmployeesProjects] AS [ep] --т.е. вземи от Employees всички и им match-ни тези, които нямат проекти
        ON [e].EmployeeID = [ep].EmployeeID
WHERE [ep].ProjectID IS NULL
ORDER BY [e].EmployeeID

--T.06
SELECT [e].[FirstName],
       [e].[LastName],
       [e].[HireDate],
       [d].[Name] AS [DeptName]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
        ON [e].DepartmentID = [d].DepartmentID
WHERE [e].[HireDate] > '1/1/1999'
      AND [d].Name IN ( 'Sales', 'Finance' )
ORDER BY [e].[HireDate]

--T.07
SELECT TOP (5)
    [e].[EmployeeID],
    [e].[FirstName],
    [p].[Name] AS [ProjectName]
FROM [Employees] AS [e]
    JOIN [EmployeesProjects] AS [ep]
        ON [e].EmployeeID = [ep].EmployeeID
    JOIN [Projects] AS [p]
        ON [p].ProjectID = [ep].ProjectID
WHERE [p].[StartDate] > '2002.08.13'
      AND [p].EndDate IS NULL
ORDER BY [e].[EmployeeID]

--T.08
SELECT [e].[EmployeeID],
       [e].[FirstName],
       CASE
           WHEN DATEPART(YEAR, [p].[StartDate]) >= 2005 THEN
               NULL
           ELSE
               [p].Name
       END AS [Name]
FROM [Employees] AS [e]
    JOIN [EmployeesProjects] AS [ep]
        ON [e].EmployeeID = [ep].EmployeeID
           AND [e].[EmployeeID] = 24
    LEFT JOIN [Projects] AS [p]
        ON [p].ProjectID = [ep].ProjectID

--T.09
SELECT [e].[EmployeeID],
       [e].[FirstName],
       [e].[ManagerID],
       [m].[FirstName] AS [ManagerName]
FROM [Employees] AS [e]
    JOIN [Employees] AS [m]
        ON [m].[EmployeeID] = [e].[ManagerID]
           AND [e].[ManagerID] IN ( 3, 7 )
ORDER BY [e].[EmployeeID]

--T.10
SELECT TOP (50)
    [e].[EmployeeID],
    CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName],
    CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName],
    [Name] AS [DepartmentName]
FROM [Employees] AS [e]
    JOIN [Employees] AS [m]
        ON [m].EmployeeID = [e].[ManagerID]
    JOIN [Departments] AS [d]
        ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID]

--T.11


USE [Geography]
--T.12
SELECT [c].[CountryCode],
       [m].[MountainRange],
       [p].[PeakName],
       [p].[Elevation]
FROM [Countries] AS [c]
    JOIN [MountainsCountries] AS [mc]
        ON [c].CountryCode = [mc].CountryCode
    JOIN [Mountains] AS [m]
        ON [mc].MountainId = [m].Id
    JOIN [Peaks] AS [p]
        ON [p].[MountainId] = [m].Id
WHERE [c].[CountryCode] = 'BG'
      AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC

--T.13
SELECT CountryCode,
COUNT(MountainId) AS [MountainRanges]
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode

--T.14
SELECT TOP (5)
    [c].[CountryName],
    [r].[RiverName]
FROM [Countries] AS [c]
    LEFT JOIN [CountriesRivers] AS [cr]
        ON [c].CountryCode = [cr].CountryCode
    LEFT JOIN [Rivers] AS [r]
        ON [cr].RiverId = [r].Id
    LEFT JOIN [Continents] AS [con]
        ON [c].ContinentCode = [con].ContinentCode
WHERE [con].ContinentName IN ( 'Africa' )
ORDER BY [c].CountryName

--T.15
SELECT [ContinentCode],
       [CurrencyCode],
       [CurrencyUsage]
FROM
(
    SELECT *,
           DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [CurrencyRank]
    FROM
    (
        SELECT [co].ContinentCode,
               [c].CurrencyCode,
               COUNT([c].CurrencyCode) AS [CurrencyUsage]
        FROM [Continents] AS [co]
            LEFT JOIN [Countries] AS [c]
                ON [c].ContinentCode = [co].ContinentCode
        GROUP BY [co].ContinentCode,
                 [c].CurrencyCode
    ) AS [CurrencyUsageQuery]
    WHERE [CurrencyUsage] > 1
) AS [CurrencyRankingQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]


--T.16
SELECT COUNT([c].CountryCode) AS [Count]
FROM [Countries] AS [c]
    LEFT JOIN [MountainsCountries] AS [mc]
        ON [c].CountryCode = [mc].CountryCode
WHERE [mc].MountainId IS NULL

--T.17
SELECT TOP (5)
    CountryName,
    MAX(p.Elevation) AS [Highest Peak Elevation],
    MAX(r.[Length]) AS [Longest River Length]
FROM Countries c
    LEFT JOIN CountriesRivers cr
        ON cr.CountryCode = c.CountryCode
    LEFT JOIN Rivers r
        ON r.Id = cr.RiverId
    LEFT JOIN MountainsCountries mc
        ON mc.CountryCode = c.CountryCode
    LEFT JOIN Mountains m
        ON m.Id = MC.MountainId
    LEFT JOIN Peaks p
        ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [Highest Peak Elevation] DESC,
         [Longest River Length] DESC,
         CountryName