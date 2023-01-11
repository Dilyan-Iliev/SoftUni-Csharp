CREATE DATABASE [Zoo]

GO
USE [Zoo]

--T.01
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50)
)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)


CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
	CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--T.02
INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId)
	VALUES
		 ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
		 ('Dimitur Stoev', '0877564223', NULL, 42,4),
		 ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
		 ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
		 ('Boryana Mileva', '0888112233', NULL, 31, 5)

	INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId)
	VALUES
		 ('Giraffe', '2018-09-21', 21, 1),
		 ('Harpy Eagle', '2015-04-17', 15, 3),
		 ('Hamadryas Baboon', '2017-11-02', NULL, 1),
		 ('Tuatara', '2021-06-30', 2, 4)

--T.03
UPDATE Animals
	   SET OwnerId = 4
	 WHERE OwnerId IS NULL

--T.04
DELETE FROM [Volunteers] 
WHERE DepartmentId = 2

DELETE FROM [VolunteersDepartments] 
WHERE Id = 2

--T.05
SELECT [Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId]
    FROM [Volunteers]
ORDER BY [Name], [AnimalId], [DepartmentId]

--T.06
SELECT 
		   [a].[Name], 
		   [at].[AnimalType],
		   FORMAT([a].BirthDate, 'dd.MM.yyyy')
		   AS [BirthDate]
	  FROM [Animals] AS [a]
	  JOIN [AnimalTypes] AS [at]
	  ON [a].AnimalTypeId = [at].Id
ORDER BY [a].[Name]

--T.07
SELECT TOP(5) [o].[Name] 
		   AS [Owner],
		COUNT(*) 
		   AS [CountOfAnimals]
      FROM [Animals]
        AS [a]
      JOIN [Owners]
        AS [o]
        ON [a].OwnerId = [o].Id
  GROUP BY [o].Name
  ORDER BY [CountOfAnimals] DESC, [Owner]

--T.08
   SELECT 
	      CONCAT([o].Name, '-', [a].Name) 
	      AS [OwnersAnimals],
		  [o].PhoneNumber,
		  [c].Id 
		  AS [CageId]
	FROM [Owners]
	  AS [o]
	JOIN [Animals] 
	  AS [a]
	  ON [a].OwnerId = [o].Id
	JOIN [AnimalTypes] 
	  AS [at]
	  ON [a].AnimalTypeId = [at].Id
	JOIN [AnimalsCages] 
	  AS [ac]
	  ON [ac].AnimalId = [a].Id
	JOIN [Cages]
	  AS [c]
	  ON [c].Id = [ac].CageId
   WHERE [at].AnimalType = 'Mammals'
ORDER BY [o].Name, [a].Name DESC	

--T.09
	SELECT [v].[Name],
		   [v].PhoneNumber,
		   SUBSTRING([v].[Address], CHARINDEX(',', [v].[Address]) + 2, LEN([v].[Address])) AS [Address]
	  FROM [Volunteers] 
	    AS [v]
	  JOIN [VolunteersDepartments] 
	    AS [vd]
	    ON [v].DepartmentId = [vd].Id
	 WHERE [vd].DepartmentName = 'Education program assistant'
	   AND [v].Address LIKE '%Sofia%'
  ORDER BY [v].Name

--T.10
	SELECT [a].[Name],
		   DATEPART(YEAR, [a].BirthDate)
		   AS [BirthYear],
		   [at].AnimalType
	  FROM [Animals] 
	    AS [a]
	  JOIN [AnimalTypes] 
	    AS [at]
		ON [a].AnimalTypeId = [at].Id
	 WHERE [a].OwnerId IS NULL
	   AND DATEDIFF(YEAR, [a].BirthDate, '01/01/2022') < 5
	   AND [at].AnimalType != 'Birds'
  ORDER BY [a].[Name]

--T.11
GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (
		SELECT COUNT(*)
		FROM [Volunteers] AS [v]
		JOIN [VolunteersDepartments] AS [vd]
		  ON [v].DepartmentId = [vd].Id
		WHERE [vd].DepartmentName = @VolunteersDepartment
	)

	RETURN @Result
END

--T.12
GO

CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT [a].[Name],
		   CASE
			WHEN [o].[Name] IS NULL THEN 'For adoption'
			ELSE [o].[Name]
			END AS [OwnersName]
	  FROM [Animals] 
	    AS [a]
 LEFT JOIN [Owners]
	    AS [o]
		ON [a].OwnerId = [o].Id
	 WHERE [a].[Name] = @AnimalName
END