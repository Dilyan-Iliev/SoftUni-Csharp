USE [SoftUni]

--T.01
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [Salary] > 35000

GO
EXEC usp_GetEmployeesSalaryAbove35000

--T.02
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Range DECIMAL(18, 4))
AS
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [Salary] >= @Range

GO
EXEC usp_GetEmployeesSalaryAboveNumber 48100

--T.03
GO
CREATE PROC usp_GetTownsStartingWith (@StartingLetter VARCHAR(10))
AS
SELECT [Name] AS [Town]
FROM [Towns]
WHERE LEFT([Name], LEN(@StartingLetter)) = @StartingLetter

GO
EXEC usp_GetTownsStartingWith 'sa'

--T.04
GO
CREATE PROC usp_GetEmployeesFromTown (@TownName VARCHAR(20))
AS
SELECT [e].[FirstName],
       [e].[LastName]
FROM [Employees] AS [e]
    JOIN [Addresses] AS [a]
        ON [e].AddressID = [a].AddressID
    JOIN [Towns] AS [t]
        ON [a].TownID = [t].TownID
WHERE [t].Name = @TownName

GO
EXEC usp_GetEmployeesFromTown 'Sofia'

--T.05
GO
CREATE FUNCTION udf_GetSalaryLevel (@Salary DECIMAL(18, 4))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Result VARCHAR(10)
    IF (@Salary < 30000)
    BEGIN
        SET @Result = 'Low'
    END
    ELSE IF (@Salary BETWEEN 30000 AND 50000)
    BEGIN
        SET @Result = 'Average'
    END
    ELSE
        SET @Result = 'High'

    RETURN @Result
END

GO
SELECT [Salary],
       dbo.udf_GetSalaryLevel([Salary]) AS [Salary Level]
FROM [Employees]

--T.06
GO
CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE dbo.udf_GetSalaryLevel([Salary]) = @SalaryLevel

GO
EXEC usp_EmployeesBySalaryLevel 'High'

--T.07
GO
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(20), @Word VARCHAR(20))
RETURNS BIT
AS
BEGIN
    DECLARE @i INT = 1;

    WHILE (@i <= LEN(@word))
    BEGIN
        DECLARE @currChar CHAR = SUBSTRING(@word, @i, 1);
        DECLARE @charIndex INT = CHARINDEX(@currChar, @setOfLetters);

        IF (@charIndex = 0)
        BEGIN
            RETURN 0;
        END

        SET @i += 1;
    END

    RETURN 1;
END

GO
USE [Bank]
--T.09
GO
CREATE PROC usp_GetHoldersFullName
AS
SELECT 
CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
FROM [AccountHolders]

GO
EXEC usp_GetHoldersFullName

--T.10
GO
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(18, 4))
AS
SELECT [ah].[FirstName],
       [ah].[LastName]
FROM [AccountHolders] AS [ah]
    JOIN [Accounts] AS [a]
        ON [ah].Id = [a].AccountHolderId
GROUP BY [ah].FirstName,
         [ah].LastName
HAVING SUM([a].Balance) > @Number
ORDER BY [ah].FirstName,
         [ah].LastName

GO
EXEC usp_GetHoldersWithBalanceHigherThan 1000

--T.11
GO
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL (18,4), @yir FLOAT, @yearsCount INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @furtureValue DECIMAL(18,4);

	SET @furtureValue = @sum * (POWER((1 + @yir), @yearsCount));

	RETURN @furtureValue
END

--T.12
GO
CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
SELECT [ah].[Id] AS [Account Id],
       [ah].FirstName,
       [ah].[LastName],
       [a].[Balance] AS [Current Balance],
       dbo.ufn_CalculateFutureValue([a].Balance, @InterestRate, 5) AS [Balances in 5 years]
FROM [Accounts] AS [a]
    JOIN [AccountHolders] AS [ah]
        ON [a].Id = [ah].Id
WHERE [a].Id = @AccountId

GO
EXEC usp_CalculateFutureValueForAccount 1, 0.1