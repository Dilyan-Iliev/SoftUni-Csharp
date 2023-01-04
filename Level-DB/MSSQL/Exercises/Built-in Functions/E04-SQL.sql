USE [SoftUni]

--T.01
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE LEFT([FirstName], 2) = 'Sa'

--T.02
SELECT [FirstName],
	   [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'

--T.03
SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3,10)
      AND [HireDate] BETWEEN '1995' AND '2005'

--T.04
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'

--T.05
SELECT [Name]
FROM [Towns]
WHERE LEN([Name]) IN ( 5, 6 )
ORDER BY [Name]

--T.06
SELECT [TownID],
       [Name]
FROM [Towns]
WHERE LEFT([Name], 1) IN ( 'M', 'K', 'B', 'E' )
ORDER BY [Name]

--T.07
SELECT [TownID],
       [Name]
FROM [Towns]
WHERE LEFT([Name], 1) NOT IN ( 'R', 'B', 'D' )
ORDER BY [Name]

--T.08
GO
CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE DATEPART(YEAR, [HireDate]) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

GO

--T.09
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5

--T.10
SELECT [EmployeeID],
       [FirstName],
       [LastName],
       [Salary],
       DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--T.11
SELECT * --т.е. селектирай ми всичко от резултата от долния select
FROM
(
    SELECT EmployeeID,
           FirstName,
           LastName,
           Salary,
           DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
    WHERE Salary
    BETWEEN 10000 AND 50000
) AS [Rank Table]
WHERE [Rank] = 2
ORDER BY Salary DESC

USE [Geography]
--T.12
SELECT [CountryName] AS [Country Name],
	   [IsoCode]
FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

--T.13
SELECT [PeakName],
       [RiverName],
       LOWER(CONCAT([PeakName], SUBSTRING([RiverName], 2, LEN([RiverName]) - 1))) AS [Mix]
FROM [Peaks],
     [Rivers]
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY [Mix]

--T.14
USE [Diablo]

SELECT TOP (50)
    [Name],
    FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE DATEPART(YEAR, [Start]) IN (2011,2012)
ORDER BY [Start],
         [Name]

--T.15
SELECT [Username],
       SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider],
         [Username]

--T.16
SELECT Username,
       IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--T.17
SELECT [Name] AS [Game],
       CASE
           WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN
               'Morning'
           WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17  THEN
               'Afternoon'
           ELSE
               'Evening'
       END AS [Part of the Day],

       CASE
           WHEN [Duration] <= 3 THEN
               'Extra Short'
           WHEN [Duration] BETWEEN  4 AND 6  THEN
               'Short'
           WHEN [Duration] > 6 THEN
               'Long'
           ELSE
               'Extra Long'
       END AS [Duration]

FROM [Games]
ORDER BY [Game],
         [Duration],
         [Part of the Day]

--T.18
USE [Orders]

SELECT [ProductName],
       [OrderDate],
       DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
       DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders]

USE [MyDB]
--T.19
CREATE TABLE [People]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    [Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People]
(
    [Name],
    [Birthdate]
)
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name],
       DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People]
