--CREATE DATABASE School

--USE School
--DDL
GO
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age > 5 AND Age < 100) NOT NULL,
	[Address] NVARCHAR(50),
	Phone CHAR(10)
)
GO
GO
CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK (Lessons >= 0) NOT NULL
)
GO
GO
CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id),
	Grade DECIMAL(15,2) CHECK (Grade >= 2 AND Grade <= 6) NOT NULL
)
GO
GO
CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)
GO
GO
CREATE TABLE StudentsExams
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK (Grade >= 2 AND Grade <= 6) NOT NULL

	PRIMARY KEY(StudentId,ExamId)
) 
GO
GO
CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)
GO
GO
CREATE TABLE StudentsTeachers
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

	PRIMARY KEY(StudentId,TeacherId)
)

GO
--DML 

--INSERT 02.
INSERT INTO Teachers
VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects
VALUES
('Geometry',	12),
('Health',	10),
('Drama',	7),
('Sports',	9)

--UPDATE 03.
--Make all grades 6.00, where the subject id is 1 or 2, if the grade is above or equal to 5.50

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE Grade >= 5.50
	AND SubjectId IN(1, 2)

--DELETE 04.
--Delete all teachers, whose phone number contains ‘72’.
DELETE FROM StudentsTeachers 
WHERE TeacherId IN ( 
	SELECT Id 
	FROM Teachers 
	WHERE Phone LIKE '%72%'
	)

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--05.Teen Students

--Select all students who are teenagers (their age is above or equal to 12). Order them by first name (alphabetically), then by last name (alphabetically). Select their first name, last name and their age.

SELECT s.FirstName , s.LastName ,s.Age
FROM Students AS s
WHERE s.Age >= 12
ORDER BY s.FirstName,s.LastName

--06.Cool Addresses

--Select all full names from students, whose address text contains ‘road’.
--Order them by first name (alphabetically), then by last name (alphabetically), then by address text (alphabetically

SELECT s.FirstName + ' ' + ISNULL(s.MiddleName,'') + ' ' + s.LastName AS [Full Name],
		s.[Address] AS [Address]
FROM Students AS s
WHERE s.[Address] LIKE '%road%'
ORDER BY s.FirstName,s.LastName,s.[Address]

--07. 42 Phones

--Select students with middle names whose phones starts with 42. Select their first name, address and phone number. Order them by first name alphabetically.

SELECT s.FirstName,s.[Address],s.Phone,s.MiddleName
FROM Students AS s
WHERE s.Phone LIKE '42%' AND s.MiddleName IS NOT NULL
ORDER BY s.FirstName

--08. Students Teachers

--Select all students and the count of teachers each one has.
SELECT S.FirstName
	,S.LastName
	,COUNT(St.TeacherId) AS [TeachersCount]
FROM Students AS S
		JOIN 
		StudentsTeachers AS St
		ON St.StudentId = S.Id
		GROUP BY S.FirstName,S.LastName

--09. Subjects with Students

--Select all teachers’ full names and the subjects they teach with the count of lessons in each. Finally select the count of students each teacher has. Order them by students count descending, full name (ascending) and subjects (ascending).

SELECT T.FirstName + ' ' + T.LastName AS [FullName]
	,Sub.[Name] + '-' + CAST(sub.Lessons AS VARCHAR(10)) AS Subjects
	,count(S.Id) AS Students
FROM Teachers AS T
		JOIN 
		Subjects AS Sub
		ON Sub.Id = T.SubjectId
			JOIN 
			StudentsTeachers AS ST
			ON ST.TeacherId = T.Id
				JOIN 
				Students AS S
				ON S.Id = St.StudentId
		GROUP BY T.FirstName,T.LastName,Sub.Name,sub.Lessons
		ORDER BY Students DESC,FullName, Subjects

--10.Students to Go

--Find all students, who have not attended an exam. Select their full name (first name + last name).
--Order the results by full name (ascending).

SELECT CONCAT_WS(' ',S.FirstName,S.LastName) AS [Full Name]
FROM Students AS s
		LEFT JOIN 
		StudentsExams AS se
		ON se.StudentId = s.Id
WHERE se.Grade IS NULL
ORDER BY [Full Name]

--11.Busiest Teachers

--Find top 10 teachers with most students they teach. Select their first name, last name and the amount of students they have. Order them by students count (descending), then by first name (ascending), then by last name (ascending).

SELECT TOP(10) T.FirstName
	,T.LastName
	,count(St.StudentId) AS [StudentsCount]
FROM Teachers AS T
		JOIN 
		StudentsTeachers AS St
		ON St.TeacherId = T.Id
GROUP BY T.FirstName,T.LastName
ORDER BY StudentsCount DESC,T.FirstName,T.LastName

--12.Top Students

--Find top 10 students, who have highest average grades from the exams.
--Format the grade, two symbols after the decimal point.
--Order them by grade (descending), then by first name (ascending), then by last name (ascending)

SELECT TOP(10) s.FirstName,s.LastName ,FORMAT(AVG(se.Grade),'0.00') AS [Grade]
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id	
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC,s.FirstName,s.LastName

--13. Second Highest Grade

--14. Not So In The Studying

--Find all students who don’t have any subjects. Select their full name. The full name is combination of first name, middle name and last name. Order the result by full name
--NOTE: If the middle name is null you have to concatenate the first name and last name separated with single space

SELECT (s.FirstName + ' ' + ISNULL(s.MiddleName + ' ','') + s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

--16. Average Grade per Subject

--Find the average grade for each subject. Select the subject name and the average grade. 
--Sort them by subject id (ascending).

SELECT sub.[Name],AVG(ss.Grade) AS [AverageGrade]
FROM Subjects AS sub
JOIN StudentsSubjects AS ss ON ss.SubjectId = sub.Id
GROUP BY sub.[Name],sub.Id
ORDER BY sub.Id

--17.Exams Information

--Divide the year in 4 quarters using the exam dates. For each quarter get the subject name and the count of students who took the exam with grade more or equal to 4.00. If the date is missing, replace it with “TBA”. Order them by quarter ascending.

SELECT q.[Quarter],q.SubjectName,COUNT(q.StudentId) AS StudentsCount
FROM(
	SELECT s.[Name] AS [SubjectName],se.StudentId,
			 CASE
			 WHEN DATEPART(MONTH, Date) BETWEEN 1 AND 3 THEN 'Q1'
			 WHEN DATEPART(MONTH, Date) BETWEEN 4 AND 6 THEN 'Q2'
			 WHEN DATEPART(MONTH, Date) BETWEEN 7 AND 9 THEN 'Q3'
			 WHEN DATEPART(MONTH, Date) BETWEEN 10 AND 12 THEN 'Q4'
			 WHEN Date IS NULL THEN 'TBA'
			 END AS [Quarter]
	FROM Exams as e
	JOIN Subjects AS s ON s.Id = e.SubjectId
	JOIN StudentsExams AS se ON se.ExamId = e.Id
	WHERE se.Grade >= 4.00
)AS q
GROUP BY q.[Quarter],q.SubjectName
ORDER BY q.[Quarter]

--Programmability

--18. Exam Grades
GO
CREATE FUNCTION udf_ExamGradesToUpdate(@StudentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(50) AS
BEGIN
	DECLARE @currentMINGrade DECIMAL(15,2) = @grade
	DECLARE @targetMAXGrade DECIMAL(15,2) = @grade + 0.50

	DECLARE @isStudentExists INT = (SELECT TOP(1) StudentId FROM StudentsExams AS st WHERE @StudentId = st.StudentId)

	DECLARE @studentFirstName NVARCHAR(30) = (SELECT TOP(1) s.FirstName FROM Students AS s WHERE s.Id = @StudentId)

	DECLARE @countGrades INT = (SELECT count(se.Grade) FROM StudentsExams AS se WHERE @StudentId = se.StudentId
	 AND se.Grade > @currentMINGrade 
	 AND se.Grade < @targetMAXGrade)

	 DECLARE @count NVARCHAR(10) = CAST(@countGrades AS NVARCHAR(10))

	IF @currentMINGrade > 6.00
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	IF @isStudentExists IS NULL
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	RETURN 'You have to update ' + @count + ' grades for the student ' + @studentFirstName
END
GO

--19.Exclude from school
GO
CREATE PROC usp_ExcludeFromSchool @StudentId INT
AS
BEGIN
	DECLARE @isStudentExists INT = 
	(SELECT TOP(1) st.StudentId FROM StudentsTeachers AS st WHERE @StudentId = st.StudentId)

	IF (@isStudentExists IS NULL)
	BEGIN
		RAISERROR('This school has no student with the provided id!',16,1)
		RETURN
	END

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM Students 
	WHERE Id = @StudentId

END
GO

--20.Deleted Student
GO
CREATE TABLE ExcludedStudents
(
	StudentId INT,
	StudentName NVARCHAR(50)
)
GO

GO
CREATE TRIGGER tr_StudentsDelete ON Students
INSTEAD OF DELETE
AS
INSERT INTO ExcludedStudents(StudentId, StudentName)
		SELECT Id, FirstName + ' ' + LastName FROM deleted
GO



















