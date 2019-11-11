GO
--01.Employees with Salary Above 35000
CREATE PROC Usp_GetEmployeesSalaryAbove35000
AS 
	SELECT E.FirstName
		,E.LastName
	FROM Employees AS E
	WHERE E.Salary > 35000
GO

GO
--02. Employees with Salary Above Number
CREATE PROC Usp_GetEmployeesSalaryAboveNumber
@inputNumber decimal(18,4) AS 
	SELECT E.FirstName
		,E.LastName
	FROM Employees AS E
	WHERE E.Salary >= @inputNumber
GO

GO
--03. Town Names Starting With
CREATE PROC Usp_GetTownsStartingWith
@inputString varchar(max) AS 
	SELECT T.Name AS 'Town'
	FROM Towns AS T
	WHERE T.Name LIKE (@inputString + '%')

GO

GO
--04. Employees from Town
CREATE PROC Usp_GetEmployeesFromTown
@townName nvarchar(max) AS 
	SELECT E.FirstName
		,E.LastName
	FROM Employees AS E
			JOIN 
			Addresses AS A
			ON A.AddressID = E.AddressID
				JOIN 
				Towns AS T
				ON T.TownID = A.TownID
		WHERE T.[Name] = @townName

GO

GO
--05. Salary Level Function
CREATE FUNCTION Ufn_GetSalaryLevel(@salary decimal(18,4)) 
RETURNS char(10) AS 
	BEGIN 
		IF(@salary < 30000 ) 
			BEGIN 
				RETURN 'Low'
			END
		IF(@salary BETWEEN 30000 AND 50000) 
			BEGIN 
				RETURN 'Average'
			END
		RETURN 'High'
	END
GO

GO
--06. Employees by Salary Level
CREATE PROC Usp_EmployeesBySalaryLevel
@salaryLevel char(10) AS 
	SELECT E.FirstName
		,E.LastName
	FROM Employees AS E
	WHERE Dbo.Ufn_GetSalaryLevel(E.Salary) = @salaryLevel

GO

GO
--07. Define Function
CREATE FUNCTION Ufn_IsWordComprised(@setOfLetters varchar(max),@word varchar(max)) 
RETURNS bit AS 
	BEGIN 
		DECLARE @count int = 1
		WHILE(@count <= len(@word)) 
			BEGIN 
				DECLARE @currentLetter char(1) = substring(@word,@count,1)
				DECLARE @currentIndex int = charindex(@currentLetter,@setOfLetters)
				IF(@currentIndex = 0) 
					BEGIN 
						RETURN 0
					END
				SET @count += 1
			END
		RETURN 1
	END

GO

GO
--09. Find Full Name

CREATE PROC Usp_GetHoldersFullName @fullName varchar(max) AS


GO
