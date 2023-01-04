USE [MyDB]

--T.01 One-to-one
CREATE TABLE [Passports](
[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
[PassportNumber] NVARCHAR(20) NOT NULL
)

INSERT INTO [Passports]
([PassportNumber])
VALUES ('N34FG21B'), ('K65LO4R7'), ('ZE657QP2')

CREATE TABLE [Persons](
[PersonID] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(50),
[Salary] DECIMAL(7,2) NOT NULL,
[PassportID] INT UNIQUE NOT NULL --UNIQUE, защото е one-to-one, и NOT NULL, за да не може FK да е NULL

CONSTRAINT FK_Persons_Passports 
FOREIGN KEY ([PassportID])
REFERENCES Passports([PassportID])
)

INSERT INTO [Persons]
([FirstName], [Salary], [PassportID])
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--T.02 One-to-many
CREATE TABLE [Manufacturers](
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
[EstablishedOn] DATE NOT NULL
)

INSERT INTO [Manufacturers]
([Name], [EstablishedOn])
VALUES
('BMW' , '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

CREATE TABLE[Models](
[ModelID] INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(20) NOT NULL,
[ManufacturerID] INT FOREIGN KEY--така е директно без записване на CONSTRAINTS
REFERENCES [Manufacturers](ManufacturerID) NOT NULL
)

INSERT INTO [Models]
([Name], [ManufacturerID])
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--T.03 Many-to-many
CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
)

INSERT INTO [Students]
([Name])
VALUES
('Mila')
,('Toni')
,('Ron')

CREATE TABLE [Exams](
[ExamID] INT PRIMARY KEY IDENTITY (101,1),
[Name] NVARCHAR(20) NOT NULL
)

INSERT INTO [Exams]
([Name])
VALUES
('SpringMVC')
,('Neo4j')
,('Oracle 11g')

CREATE TABLE [StudentsExams](
[StudentID] INT, --не слагам NOT NULL, понеже тези ключове са едновременно и FK и PK
[ExamID] INT,
--First create PK
CONSTRAINT PK_StudentsExams
PRIMARY KEY(StudentID, ExamID),

--Then create first FK
CONSTRAINT FK_Students_Exams
FOREIGN KEY (StudentID)
REFERENCES [Students](StudentID),

--Then create second FK
CONSTRAINT FK_Exams_Students
FOREIGN KEY (ExamID)
REFERENCES [Exams](ExamID)

--or shortly the whole thing:
--[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
--[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
--PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [StudentsExams]
([StudentID], [ExamID])
VALUES
(1,101)
,(1, 102)
,(2, 101)
,(3, 103)
,(2, 102)
,(2, 103)

--T.04
CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY (101,1),
	[Name] NVARCHAR(20) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers]
([Name], [ManagerID])
VALUES
('John', NULL)
,('Maya', 106)
,('Silvia', 106)
,('Ted', 105)
,('Mark', 101)
,('Greta', 101)


--T.05
CREATE DATABASE [Online Store]
USE [Online Store]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT,
	CONSTRAINT PK_Customers_Cities
	FOREIGN KEY([CityID])
	REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CustomerID] INT,
	CONSTRAINT FK_Orders_Customers
	FOREIGN KEY(CustomerID)
	REFERENCES [Customers](CustomerID)
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT,
	CONSTRAINT FK_Items_ItemTypes
	FOREIGN KEY (ItemTypeID)
	REFERENCES [ItemTypes](ItemTypeID)
)

CREATE TABLE [OrderItems](
	[OrderID] INT,
	[ItemID] INT,

	CONSTRAINT PK_OrderItems
	PRIMARY KEY (OrderID, ItemID),

	CONSTRAINT FK_Orders_Items
	FOREIGN KEY (OrderID)
	REFERENCES [Orders](OrderID),

	CONSTRAINT FK_Items_Orders
	FOREIGN KEY (ItemID)
	REFERENCES [Items](ItemID)
)


--T.06
CREATE DATABASE [University]
USE [University]

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Student Number] VARCHAR(20) NOT NULL,
	[Student Name] VARCHAR(50) NOT NULL,
	[MajorID] INT NOT NULL,

	CONSTRAINT FK_Students_Majors
	FOREIGN KEY ([MajorID])
	REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] INT NOT NULL,
	[StudentID] INT NOT NULL,

	CONSTRAINT FK_Payments_Students
	FOREIGN KEY ([StudentID])
	REFERENCES [Students]([StudentID])
)

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda](
	[StudentID] INT,
	[SubjectID] INT,

	CONSTRAINT PK_StudentsSubjects
	PRIMARY KEY (StudentID, SubjectID),

	CONSTRAINT FK_Students_Subjects
	FOREIGN KEY(StudentID)
	REFERENCES [Students]([StudentID]),

	CONSTRAINT FK_Subjects_Students
	FOREIGN KEY(SubjectID)
	REFERENCES [Subjects]([SubjectID])
)


--T.09
USE [Geography]
SELECT m.MountainRange
,p.PeakName
,p.Elevation
FROM [Mountains] AS m
JOIN [Peaks] AS p ON 
	m.Id = p.MountainId --това е условието
	AND m.MountainRange = 'Rila' --така изобщо няма да има JOIN ако не отговаря на условията
ORDER BY p.Elevation DESC