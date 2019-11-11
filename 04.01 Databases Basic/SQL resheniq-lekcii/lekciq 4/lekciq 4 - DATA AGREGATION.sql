SELECT 
	COUNT(*) AS 'Records Count'
FROM	
	WizzardDeposits

SELECT 
	MAX(WizzardDeposits.MagicWandSize) AS 'LongestMagicWand'
FROM
	WizzardDeposits

SELECT 
	DepositGroup,
	MAX(MagicWandSize ) AS 'LongestMagicWand' 
FROM
	WizzardDeposits
GROUP BY 
	DepositGroup

GO

SELECT TOP(2) DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC


SELECT
	DepositGroup
	,MagicWandCreator AS MagicWandCreator
	,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

SELECT AgeGroupTable.AgeGroup, COUNT(AgeGroupTable.AgeGroup)
FROM(
	SELECT 
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits
) AS AgeGroupTable 
GROUP BY AgeGroupTable.AgeGroup

SELECT LEFT(FirstName,1) AS 'FirstLetter'
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)


SELECT DepositGroup, IsDepositExpired ,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC , IsDepositExpired

USE SoftUni

SELECT DepartmentID,SUM(Salary) as TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


SELECT DepartmentID ,MIN(Salary) as MinimumSalary
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID	


SELECT * INTO NewTableOfEmployees
FROM Employees
WHERE Salary > 30000

DELETE FROM NewTableOfEmployees
WHERE ManagerID = 42

UPDATE NewTableOfEmployees
SET Salary += 5000
WHERE NewTableOfEmployees.DepartmentID = 1

SELECT DepartmentId, AVG(Salary)
FROM NewTableOfEmployees
GROUP BY DepartmentID

SELECT DepartmentID, MAX(Salary) AS 'MaxSalary'
FROM Employees
GROUP BY DepartmentID
HAVING (MAX(Salary) NOT BETWEEN 30000 AND 70000)
ORDER BY DepartmentID

SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL










