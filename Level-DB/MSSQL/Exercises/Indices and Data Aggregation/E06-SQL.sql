
USE [Gringotts]
--T.01
SELECT COUNT(*) AS [Count] FROM [WizzardDeposits]

--T.02
SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]

--T.03
SELECT [DepositGroup],
	   MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--T.04
SELECT TOP (2)
    [DepositGroup]
FROM
(
    SELECT [DepositGroup],
           AVG([MagicWandSize]) AS [AverageWandSize]
    FROM [WizzardDeposits]
    GROUP BY [DepositGroup]
) AS [AverageWandSizeQuantity]
ORDER BY [AverageWandSize]

--T.05
SELECT [DepositGroup],
       SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--T.06
SELECT [DepositGroup],
       SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] IN ( 'Ollivander family' )
GROUP BY [DepositGroup]

--T.07
SELECT [DepositGroup],
       SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] IN ( 'Ollivander family' )
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--T.08
SELECT [DepositGroup],
       [MagicWandCreator],
       MIN([DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits]
GROUP BY [DepositGroup],
         [MagicWandCreator]
ORDER BY [MagicWandCreator],
         [DepositGroup]

--T.09
SELECT [AgeGroup],
       COUNT(*) AS [WizzardCount]
FROM
(
    SELECT 
		   CASE
               WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
               WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
               WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
               WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
               WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
               WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
               ELSE '[61+]'
           END AS [AgeGroup]
    FROM [WizzardDeposits]
) AS [AgeGroupQuery]
GROUP BY [AgeGroup]

--T.10
SELECT DISTINCT
    [FirstLetter]
FROM
(
    SELECT LEFT([FirstName], 1) AS [FirstLetter]
    FROM [WizzardDeposits]
    WHERE [DepositGroup] IN ( 'Troll Chest' )
    GROUP BY [FirstName]
) AS [Query]
ORDER BY [FirstLetter]

--T.11
SELECT [DepositGroup],
       [IsDepositExpired],
       AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup],
         [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
         [IsDepositExpired]

--T.12
--JOIN Solution
SELECT * FROM [WizzardDeposits] AS [wd1]
JOIN [WizzardDeposits] AS [wd2]
ON [wd1].Id + 1 = [wd2].Id
--.....

SELECT SUM([Host Wizzard Deposit] - [Guest Wizzard Deposit])
AS [Sum Difference]
FROM (
SELECT [FirstName] AS [Host Wizzard],
	   [DepositAmount] AS [Host Wizzard Deposit],
	   LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizzard],
	   LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Guest Wizzard Deposit]
FROM [WizzardDeposits]
) AS [HostGuestWizzardQuery]
WHERE [Guest Wizzard] IS NOT NULL


USE [SoftUni]
--T.13
SELECT [DepartmentID],
	   SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]

--T.14
SELECT [DepartmentID],
       MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
      WHERE [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]
HAVING [DepartmentID] IN ( 2, 5, 7 )

--T.15
SELECT *
INTO [FilteredEmployees]
FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM [FilteredEmployees]
WHERE [ManagerID] = 42

UPDATE [FilteredEmployees]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID],
       AVG([Salary]) AS [AverageSalary]
FROM [FilteredEmployees]
GROUP BY [DepartmentID]

--T.16
SELECT [DepartmentID],
	   MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--T.17
SELECT COUNT([EmployeeID]) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL

--T.18
SELECT DepartmentID, Salary AS [ThirdHighestSalary]
	FROM (
			SELECT DepartmentID,
			       Salary,
				   DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [SalaryRank]
			FROM Employees
			GROUP BY DepartmentID, Salary
		 ) AS [SalaryRankingsQuery]
	WHERE SalaryRank = 3