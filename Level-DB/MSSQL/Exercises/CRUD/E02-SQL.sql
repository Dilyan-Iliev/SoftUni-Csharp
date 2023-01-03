--T.02
SELECT 
	*
FROM [Departments]

--T.03
SELECT 
	[Name] 
FROM [Departments]

--T.04
SELECT
	[FirstName]
	, [LastName]
	, [Salary]
FROM
[Employees]	

--T.05
SELECT
	[FirstName]
	,[MiddleName]
	,[LastName]
FROM [Employees]

--T.06
SELECT
	CONCAT([FirstName], '.', [LastName], '@softuni.bg') 
AS [Full Email Adress]
FROM [Employees]

--T.07
SELECT DISTINCT
	[Salary]
FROM [Employees]

--T.08
SELECT 
	*
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

--T.09
SELECT
	[FirstName]
	,[LastName]
	,[JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000
--or -> WHERE [Salary] > 20000 AND [Salary] < 30000

--T.10
SELECT
	CONCAT([FirstName], ' ', [MiddleName], ' ' , [LastName]) 
AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

--T.11
SELECT
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE ManagerID IS NULL

--T.12
SELECT
	[FirstName]
	,[LastName]
	,[Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

--T.13
SELECT TOP(5)
	[FirstName]
	,[LastName]
FROM [Employees]
ORDER BY [Salary] DESC

--T.14
SELECT
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE DepartmentID != 4
--or -> WHERE NOT (DepartmentID = 4)

--T.15
SELECT
	*
FROM [Employees]
ORDER BY [Salary] DESC,
[FirstName],
[LastName] DESC,
[MiddleName]

--T.16
CREATE VIEW v_EmployeesSalaries AS
SELECT 
	[FirstName]
	,[LastName]
	,[Salary]
FROM [Employees]

SELECT * FROM v_EmployeesSalaries

--T.17
CREATE VIEW [V_EmployeeNameJobTitle]
AS SELECT 
	CONCAT([FirstName], ' ', ISNULL([MiddleName], ''), ' ', [LastName]) AS [Full Name], [JobTitle]
FROM [Employees]

SELECT * FROM v_EmployeeNameJobTitle

--T.18
SELECT DISTINCT 
	[JobTitle]
FROM [Employees]

--T.19
SELECT TOP(10)
	*
FROM [Projects]
ORDER BY [StartDate],
[Name]

--T.20
SELECT TOP(7)
	[FirstName]
	,[LastName]
	,[HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC

--T.21
UPDATE [Employees]
SET [Salary] += [Salary] * 0.12
WHERE DepartmentID IN (1,2,4,11)

SELECT [Salary] FROM [Employees]

--undo previous update
UPDATE [Employees]
SET [Salary] -= [Salary] * 0.12
WHERE DepartmentID IN (1,2,4,11)

--T.22
GO
USE [Geography]
SELECT
	[PeakName]
FROM [Peaks]
ORDER BY [PeakName]
GO

--T.23
GO
USE [Geography]
SELECT TOP(30)
	[CountryName]
	,[Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,
[CountryName]
GO

--T.24
SELECT [CountryName], [CountryCode],
  CASE 
    WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
    ELSE 'Not Euro' 
  END AS [Currency]
FROM [Countries]
ORDER BY [CountryName]

--T.25
USE [Diablo]
SELECT 
[Name]
FROM [Characters]
ORDER BY [Name]