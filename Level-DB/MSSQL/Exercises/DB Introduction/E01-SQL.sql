--T.01
CREATE DATABASE Minions

--T.02
USE [Minions]

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] TINYINT NOT NULL,
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)

--T.03
ALTER TABLE [Minions] 
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

--T.04
GO
INSERT INTO [Towns] ([Id], [Name]) 
	VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')
GO

GO
ALTER TABLE [Minions]
ALTER COLUMN [Age] INT
GO

GO
INSERT INTO [Minions] ([Id], [Name], [Age], [TownId]) 
	VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)
GO

--T.05
TRUNCATE TABLE [Minions]

--T.07
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000), --това проверява дали дължината
	--на данните записани в колоната Picture <= 2mb
	[Height] DECIMAL(3,2), --(3,2) -> общ брой цифри(3) брой цифри след запетая (2) и съответно ще стане 2.00 или 3.00 или нещо такова
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'), --проверявам стойността в колоната Gender да е = m или f
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX) --така задавам максималната дължина на дадена променлива в T-SQL
)

INSERT INTO [People]
	([Name], [Height], [Weight], [Gender], [Birthdate])
VALUES 
('Pesho', 1.66, 85.2, 'm', '1995-05-12'),
('Gosho', 1.86, 75.2, 'm', '1995-02-12'),
('Misho', 1.46, 55.2, 'm', '1995-04-12'),
('Pepi', 1.96, 65.2, 'm', '1995-09-12'),
('Acho', 1.66, 95.2, 'm', '1995-12-12')

SELECT * FROM [People]

--T.08
CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATE,
	[IsDeleted] BIT,
	CHECK ([IsDeleted] = 0 OR [IsDeleted] = 1)
)

INSERT INTO [Users]
([Username], [Password], [IsDeleted])
VALUES
('John', '123asd', 0),
('Mike', '123asd', 1),
('Bob', '123asd', 0),
('Steve', '123asd', 1),
('George', '123asd', 0)

SELECT * FROM [Users]

--T.09
ALTER TABLE [Users]
DROP [Id] 