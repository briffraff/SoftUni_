CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,

	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email CHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL ,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT NOT NULL CHECK (Luggage >= 0)

	PRIMARY KEY(AccountId,TripId)
)

--INSERT

INSERT INTO Accounts
VALUES
('John','	Smith','	Smith',	34	,'1975-07-21','	J_smith@gmail.Com'),
('Gosho	',NULL,'	Petrov',	11	,'1978-05-16','	G_petrov@gmail.Com'),
('Ivan','	Petrovich	','Pavlov',	59,'1849-09-26','	I_pavlov@softuni.Bg'),
('Friedrich','	Wilhelm','	Nietzsche',	2	,'1844-10-15	','f_nietzsche@softuni.bg')

INSERT INTO Trips
VALUES
(101,	'2015-04-12','2015-04-14','2015-04-20','2015-02-02'),
(102,	'2015-07-07	','2015-07-15','	2015-07-22','	2015-04-29'),
(103,	'2013-07-17	','2013-07-23','	2013-07-24	',NULL),
(104,	'2012-03-17	','2012-03-31','	2012-04-01	','2012-01-10'),
(109,	'2017-08-07	','2017-08-28','	2017-08-29	',NULL)

--UPDATE

--Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN(5,7,9)

--DELETE

--Delete all of Account ID 47’s account’s trips from the mapping table.

DELETE FROM AccountsTrips
WHERE AccountId = 47

--5. Bulgarian Cities

SELECT c.Id,c.[Name]
FROM Cities AS c
WHERE c.CountryCode = 'BG'
ORDER BY c.Name

--6. People Born After 1991

--Select all full names and birth years from accounts, who are born after 1991.
--Order them by birth year (descending), then by first name (ascending). Keep in mind that middle names can be NULL 😊

SELECT (a.FirstName + ' ' + ISNULL(a.MiddleName + ' ','') + a.LastName) AS [Full Name],
		DATEPART(YEAR,a.BirthDate) AS [BirthYear]
FROM Accounts AS a
WHERE DATEPART(YEAR,a.BirthDate) > 1991
ORDER BY [BirthYear] DESC,a.FirstName

--7.EEE-EMAILS

--Select accounts whose emails start with the letter “e”. Select their first and last name, their birthdate in the format "MM-dd-yyyy", and their city name.
--Order them by city name (descending)

SELECT a.FirstName,a.LastName,FORMAT(a.BirthDate,'MM-dd-yyyy') AS [BirthDate],c.Name AS [Hometown],a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE a.Email LIKE 'e%'
ORDER BY c.[Name] DESC

----8. City Statistics

--Select all cities with the count of hotels in them. Order them by the hotel count (descending), then by city name. Include cities, which have no hotels in them as well.

SELECT c.[Name],COUNT(h.Id) AS [Hotels]
FROM Cities AS c
LEFT JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY [Hotels] DESC,c.[Name]

--9. Expensive First-Class Rooms

--Find all First-Class rooms and select the Id, Price, Hotel name and City name. 
--Order them by Price (descending), then by Room ID.
--Examples
--Id	Price	Hotel	City

SELECT r.Id,r.Price,h.Name AS [Hotel],c.Name AS [City]
FROM Rooms AS r
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE r.Type = 'First Class'
ORDER BY r.Price DESC,r.Id

--10. Longest and Shortest Trips

--Find the longest and shortest trip for each account, in days. Filter the results to accounts with no middle name and trips, which aren’t cancelled (CancelDate is null).
--Order the results by Longest Trip days (descending), then by Account ID.
--AccountId	FullName	LongestTrip	ShortestTrip

SELECT at.AccountId,
	   a.FirstName +' '+ a.LastName AS [FullName],
	   MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS [LongestTrip] ,
	   MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS [ShortestTrip]
FROM Trips AS t
JOIN AccountsTrips AS at ON at.TripId = t.Id
JOIN Accounts AS a ON a.Id = at.AccountId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY at.AccountId,a.FirstName + ' ' + a.LastName
ORDER BY [LongestTrip] DESC,at.AccountId

--11. Metropolis

--Find the top 5 cities, which have the most registered accounts in them. Order them by the count of accounts (descending).
--Id	City	Country	Accounts

SELECT TOP(5) c.Id,c.[Name] AS [City],c.CountryCode AS [County] , COUNT(a.id) as [Accounts]
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id,c.[Name],c.CountryCode
ORDER BY [Accounts] DESC
