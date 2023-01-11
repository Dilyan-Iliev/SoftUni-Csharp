	GO
	CREATE DATABASE [Airport]

	GO
	USE [Airport]

	GO

--T.01
	CREATE TABLE Passengers (
		[Id] INT PRIMARY KEY IDENTITY,
		[FullName] VARCHAR(100) UNIQUE NOT NULL,
		[Email] VARCHAR(50) UNIQUE NOT NULL
	)

	CREATE TABLE Pilots(
		[Id] INT PRIMARY KEY IDENTITY,
		[FirstName] VARCHAR(30) UNIQUE NOT NULL,
		[LastName] VARCHAR(30) UNIQUE NOT NULL,
		[Age] TINYINT NOT NULL CHECK([Age] >= 21 AND [Age] <= 62),
		[Rating] FLOAT CHECK([Rating] >= 0.0 AND [Rating] <= 10.0)
	)

	CREATE TABLE AircraftTypes(
		[Id] INT PRIMARY KEY IDENTITY,
		[TypeName] VARCHAR(30) UNIQUE NOT NULL
	)

	CREATE TABLE Aircraft(
		[Id] INT PRIMARY KEY IDENTITY,
		[Manufacturer] VARCHAR(25) NOT NULL,
		[Model] VARCHAR(30) NOT NULL,
		[Year] INT NOT NULL,
		[FlightHours] INT,
		[Condition] CHAR(1) NOT NULL,
		[TypeId] INT NOT NULL FOREIGN KEY REFERENCES [AircraftTypes](Id)
	)

	CREATE TABLE PilotsAircraft(
		[AircraftId] INT NOT NULL FOREIGN KEY REFERENCES [Aircraft](Id),
		[PilotId] INT NOT NULL FOREIGN KEY REFERENCES [Pilots](Id)
		PRIMARY KEY(AircraftId, PilotId)
	)

	CREATE TABLE Airports(
		[Id] INT PRIMARY KEY IDENTITY,
		[AirportName] VARCHAR(70) UNIQUE NOT NULL,
		[Country] VARCHAR(100) UNIQUE NOT NULL
	)

	CREATE TABLE FlightDestinations(
		[Id] INT PRIMARY KEY IDENTITY,
		[AirportId] INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
		[Start] DATETIME NOT NULL,
		[AircraftId] INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
		[PassengerId] INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
		[TicketPrice] DECIMAL(18,2) NOT NULL DEFAULT 15
	)

--T.02
	--bad info from the task

--T.03
	UPDATE [Aircraft]
	   SET [Condition] = 'A'
	 WHERE [Condition] IN ('C', 'B')
	   AND [FlightHours] IS NULL OR [FlightHours] <= 100
	   AND [Year] >= 2013

--T.04
	DELETE FROM FlightDestinations 
		  WHERE [PassengerId] IN (
								  SELECT Id FROM [Passengers] WHERE LEN(FullName) <= 10
		                         )

	DELETE FROM [Passengers] 
		  WHERE LEN(FullName) <= 10

--T.05
  SELECT [Manufacturer],
		 [Model],
		 [FlightHours],
		 [Condition]
	FROM [Aircraft]
ORDER BY [FlightHours] DESC

--T.06
	SELECT [p].FirstName,
		   [p].LastName,
		   [a].Manufacturer,
		   [a].Model,
		   [a].FlightHours
	  FROM [Pilots] AS [p]
	  JOIN [PilotsAircraft] AS [pa]
		ON [p].Id = [pa].PilotId
	  JOIN [Aircraft] AS [a]
		ON [a].Id = [pa].AircraftId
	 WHERE [a].FlightHours IS NOT NULL
	   AND [a].FlightHours <= 304
  ORDER BY [a].FlightHours DESC,
           [p].FirstName

--T.07
	SELECT TOP(20)
		   [fd].Id,
		   [fd].[Start],
		   [p].FullName,
		   [air].AirportName,
		   [fd].TicketPrice
      FROM [Airports] AS [air]
	  JOIN [FlightDestinations] AS [fd]
	    ON [air].Id = [fd].AirportId
	  JOIN [Passengers] AS [p]
	    ON [p].Id = [fd].PassengerId
	 WHERE DATEPART(DAY, [fd].[Start]) % 2 = 0
  ORDER BY [fd].TicketPrice DESC,
           [air].AirportName

--T.08
	SELECT [a].Id,
		   [a].Manufacturer,
		   [a].FlightHours,
		   COUNT(*) AS [FlightDestinationsCount],
		   ROUND(AVG([fd].TicketPrice), 2) AS [AvgPrice]
	  FROM [FlightDestinations] AS [fd]
	  JOIN [Aircraft] AS [a]
	    ON [fd].AircraftId = [a].Id
  GROUP BY [a].[Id],
	       [a].Manufacturer,
		   [a].FlightHours
    HAVING COUNT(*) >= 2
  ORDER BY [FlightDestinationsCount] DESC,
		   [a].Id

--T.09
	SELECT [p].FullName,
	       COUNT(*) AS [CountOfAircraft],
		   SUM([fd].TicketPrice) AS [TotalPayed]
	  FROM [FlightDestinations] AS [fd]
	  JOIN [Passengers] AS [p]
	    ON [fd].PassengerId = [p].Id
	  JOIN [Aircraft] AS [a]
	    ON [a].Id = [fd].AircraftId
	 WHERE SUBSTRING([p].[FullName], 2, 1) = 'a'
  GROUP BY [p].FullName
    HAVING COUNT(*) > 1

--T.10
	SELECT [air].AirportName,
		   [fd].[Start] AS [DayTime],
		   [fd].TicketPrice,
		   [p].FullName,
		   [a].Manufacturer,
		   [a].Model
	  FROM [FlightDestinations] AS [fd]
	  JOIN [Passengers] AS [p]
	    ON [fd].PassengerId = [p].Id
	  JOIN [Aircraft] AS [a]
	    ON [fd].AircraftId = [a].Id
	  JOIN [Airports] AS [air]
	    ON [air].Id = [fd].AirportId
	 WHERE DATEPART(HOUR, [fd].[Start]) BETWEEN 6 AND 20
	   AND [fd].TicketPrice > 2500
  ORDER BY [a].Model

--T.11
GO

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT = (
		SELECT COUNT(*) 
		  FROM [FlightDestinations] AS [fd]
		  JOIN [Passengers] AS [p]
		    ON [fd].PassengerId = [p].Id
		 WHERE [p].Email = @email
	)

	RETURN @Result
END

--T.12
GO

CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	SELECT [air].AirportName,
	       [p].FullName,
		   CASE 
				WHEN [fd].TicketPrice < 400 THEN 'Low'
				WHEN [fd].TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
				ELSE 'High'
		   END AS [LevelOfTickerPrice],
		   [a].Manufacturer,
		   [a].Condition,
		   [at].TypeName
	  FROM [FlightDestinations] AS [fd]
	  JOIN [Airports] AS [air]
	    ON [fd].AirportId = [air].Id
	  JOIN [Aircraft] AS [a]
	    ON [fd].AircraftId = [a].Id
	  JOIN [AircraftTypes] AS [at]
	    ON [at].Id = [a].TypeId
	  JOIN [Passengers] AS [p]
	    ON [fd].PassengerId = [p].Id
	 WHERE [air].AirportName = @airportName
  ORDER BY [a].Manufacturer,
	       [p].FullName
END