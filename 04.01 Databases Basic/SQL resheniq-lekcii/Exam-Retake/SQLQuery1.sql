CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)

--Insert

INSERT INTO Planes
VALUES
('Airbus 336',	112	,5132),
('Airbus 330',	432	,5325),
('Boeing 369',	231	,2355),
('Stelt 297',	254	,2143),
('Boeing 338',	165	,5111),
('Airbus 558',	387	,1342),
('Boeing 128',	345	,5541)

INSERT INTO LuggageTypes
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--03 UPDATE
--Make all flights to "Carlsbad" 13% more expensive.

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = '41'

--04.DELETE
--Delete all flights to "Ayn Halagim".

DELETE FROM Tickets 
WHERE FlightId IN ( 
	SELECT Id 
	FROM Flights 
	WHERE Destination = 'Ayn Halagim'
	)
	
DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05.Trips
--Select all flights from the database. Order them by origin (ascending) and destination (ascending).

SELECT f.Origin,f.Destination
FROM Flights AS f
ORDER BY f.Origin,f.Destination

--06.The "Tr" Planes
--Select all of the planes, which name contains "tr". Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).

SELECT p.Id,p.[Name],p.Seats,p.[Range]
FROM Planes AS p
WHERE p.[Name] LIKE '%tr%'
ORDER BY p.Id,p.[Name],p.Seats,p.[Range]

--	7.	Flight Profits
--Select the total profit for each flight from database. Order them by total price (descending), flight id (ascending).

SELECT f.Id ,SUM(t.Price)
FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY SUM(t.Price) DESC,f.Id

--8.	Passengers and Prices

--Select top 10 records from passengers along with the price for their tickets. Order them by price (descending), first name (ascending) and last name (ascending).
--FirstName	LastName	Price

SELECT TOP(10) p.FirstName,p.LastName,t.Price
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
ORDER BY t.Price DESC,p.FirstName,p.LastName

--9.	Most Used Luggage's
--Select luggage type and how many times was used by persons. Sort by count (descending) and luggage type (ascending).

SELECT lt.[Type],COUNT(l.Id) AS [MostUsedLuggage]
FROM LuggageTypes AS lt
JOIN Luggages AS l ON l.LuggageTypeId = lt.Id
GROUP BY lt.[Type]
ORDER BY [MostUsedLuggage] DESC,lt.[Type]

--10.	Passenger Trips
--Select the full name of the passengers with their trips (origin - destination). Order them by full name (ascending), origin (ascending) and destination (ascending).

--Full Name	Origin	Destination

SELECT CONCAT(p.FirstName,' ',P.LastName) AS [Full Name],f.Origin,f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
ORDER BY [Full Name],f.Origin,f.Destination

--11.	Non Adventures People
--Select all people who don't have tickets. Select their first name, last name and age .Order them by age (descending), first name (ascending) and last name (ascending).

--First Name	Last Name	Age

SELECT p.FirstName,p.LastName,p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
WHERE t.FlightId IS NULL
ORDER BY p.Age DESC,p.FirstName,p.LastName

--12.	Lost Luggage's
--Select all passengers who don't have luggage's. Select their passport id and address. Order the results by passport id (ascending) and address (ascending).

--Passport Id	Address

SELECT p.PassportId,p.[Address]
FROM Passengers AS p
LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
WHERE l.PassengerId IS NULL
ORDER BY p.PassportId,p.[Address]

--13.	Count of Trips
--Select all passengers and their count of trips. Select the first name, last name and count of trips. Order the results by total trips (descending), first name (ascending) and last name (ascending).
--First Name	Last Name	Total Trips

SELECT p.FirstName,p.LastName,COUNT(t.Id) AS [Total Trips]
FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
GROUP BY p.FirstName,p.LastName
ORDER BY [Total Trips] DESC,p.FirstName,p.LastName

--14.	Full Info
--Select all passengers who have trips. Select their full name (first name – last name), plane name, trip (in format {origin} - {destination}) and luggage type. Order the results by full name (ascending), name (ascending), origin (ascending), destination (ascending) and luggage type (ascending).

--Full Name	Plane Name	Trip	Luggage Type

SELECT p.FirstName + ' ' + p.LastName AS [Full Name]
		,pl.[Name] AS [Plane Name],
		f.Origin + ' - ' + f.Destination AS [Trip],
		lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Luggages AS l ON l.Id = t.LuggageId
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Planes AS pl ON pl.Id = f.PlaneId
ORDER BY [Full Name],pl.[Name],f.Origin,f.Destination,lt.[Type]

--15.	Most Expensive Trips
--Select all passengers who have flights. Select their first name, last name, destination and price for the ticket. Take only the ticket with highest price for user. Order the results by price (descending), first name (ascending), last name (ascending) and destination (ascending).

--First Name	Last Name	Destination	Price

SELECT * --p.FirstName,p.LastName,f.Destination,MAX(t.Price) AS [Price]
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
--WHERE t.FlightId IS NOT NULL
--GROUP BY p.FirstName,p.LastName,f.Destination,f.Id
--HAVING COUNT(t.FlightId) > 0
ORDER BY [Price] DESC,p.FirstName,p.LastName,f.Destination

--16.	Destinations Info
--Select all destinations and trips count to them. Sort the result by trips count (descending) and destination name (ascending).

--Destination	FilesCount

SELECT f.Destination,COUNT(t.Id) AS [FilesCount]
FROM Flights AS f
LEFT JOIN Planes AS p ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
WHERE f.Destination IS NOT NULL
GROUP BY f.Destination
HAVING COUNT(t.Id) >= 0
ORDER BY [FilesCount] DESC,f.Destination

--17Select all planes with their name, seats count and passengers count. Order the results by passengers count (descending), plane name (ascending) and seats (ascending) 
--Name	Seats	Passengers Count

SELECT p.[Name],p.Seats AS [Seats],COUNT(t.PassengerId) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY p.[Name],[Seats]
ORDER BY  [Passengers Count] DESC,p.[Name],[Seats]

--18.Vacation
GO
CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT) 
RETURNS NVARCHAR(MAX)
BEGIN
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"

	IF(@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END

	DECLARE @isValidFlight INT = 
		(SELECT TOP(1) Id FROM Flights AS f WHERE (f.Destination = @destination AND f.Origin = @origin))

	IF(@isValidFlight IS NULL)
	BEGIN 
		RETURN 'Invalid flight!'
	END

	DECLARE @priceForTicket DECIMAL(15,2) =	
	(
		SELECT SUM(t.Price)
		FROM Flights AS f
		JOIN Tickets AS t ON t.FlightId = f.Id
		WHERE f.Id = @isValidFlight
	)
	
	DECLARE @totalPrice DECIMAL(15,2) = (@priceForTicket * @peopleCount)

	RETURN 'Total price ' + CAST(@totalPrice AS NVARCHAR(20))
END
GO

--19.Wrong Data

--Create a user defined stored procedure, named usp_CancelFlights
--The procedure must cancel all flights on which the arrival time is before the departure time. Cancel means you need to leave the departure and arrival time empty.

GO
CREATE PROC usp_CancelFlights
AS 
BEGIN
	DECLARE @wrongFlightCOUNT INT = 
	(
	SELECT COUNT(Planeid) 
	FROM Flights AS f 
	WHERE f.ArrivalTime > f.DepartureTime
	)
	
	DECLARE @counter INT = 0

	WHILE(@counter <= @wrongFlightCOUNT)
	BEGIN
		DECLARE @wrongFlight INT = (SELECT PlaneId FROM Flights AS f WHERE f.ArrivalTime > f.DepartureTime)

		IF(@wrongFlight IS NOT NULL)
		BEGIN
			UPDATE Flights 
			SET ArrivalTime = NULL ,DepartureTime = NULL
			WHERE PlaneId = @wrongFlight
		END

		SET @counter += 1
	END

END
GO

EXEC usp_CancelFlights


--20.DELETED PLANES

--Create a new table "DeletedPlanes" with columns (Id,Name,Seats, Range). Create a trigger, which fires when planes are deleted. After deleting the planes, insert all of the data into the new table "DeletedPlanes".
--Note: Submit only your CREATE TRIGGER statement!

GO
CREATE TABLE DeletedPlanes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)
GO

GO
CREATE TRIGGER tr_PlanesDelete ON Planes
INSTEAD OF DELETE
AS
INSERT INTO DeletedPlanes(Id,[Name],[Seats],[Range])
		SELECT Id,[Name],[Seats],[Range] FROM deleted
GO

