USE master
go

DROP database if exists FlightSchool
go

CREATE database FlightSchool
go

USE FlightSchool
go

CREATE TABLE Instructor(
	InstructorID INT NOT NULL IDENTITY PRIMARY KEY,
	First_Name NVARCHAR(50) NULL,
	Last_Name NVARCHAR(50) NULL,
	DOB DATE NULL,
	JoinedOn DATE NULL,
	License BIT NULL
)
go

CREATE TABLE Student(
	StudentID INT NOT NULL IDENTITY PRIMARY KEY,
	First_Name NVARCHAR(50) NULL,
	Last_Name NVARCHAR(50) NULL,
	DOB DATE NULL,
	InstructorID INT FOREIGN KEY REFERENCES Instructor(InstructorID)
)
go

CREATE TABLE Helicopters(
	HelicopterID INT NOT NULL IDENTITY PRIMARY KEY,
	ModelNumber NVARCHAR(50) NOT NULL,
	InstructorID INT FOREIGN KEY REFERENCES Instructor(InstructorID)
)
go

--CREATE INSTRUCTORS--
INSERT INTO Instructor VALUES('Gary', 'Walker', '1978-07-03', '2014-07-03',1);
INSERT INTO Instructor VALUES('Joe', 'Bloggs', '1993-04-23', '2010-04-23',1);
INSERT INTO Instructor VALUES('Raj', 'Patel', '1984-03-17', '2014-03-17',1);
INSERT INTO Instructor VALUES('Jack', 'Brigs', '1992-09-28', '2018-09-28',1);

--CREATE STUDENTS--
INSERT INTO Student VALUES('Jenny', 'Marlow', '1992-09-28',2);
INSERT INTO Student VALUES('Lee', 'Lemon', '1992-09-28',3);
INSERT INTO Student VALUES('Bolly', 'Wood', '1992-09-28',3);
INSERT INTO Student VALUES('Riley', 'Holland', '1992-09-28',2);
INSERT INTO Student VALUES('Jimmy', 'Bob', '1992-09-28',1);
INSERT INTO Student VALUES('Biggy', 'Smalls', '1992-09-28',1);
INSERT INTO Student VALUES('Diamond', 'Jack', '1992-09-28',1);
INSERT INTO Student VALUES('Ruby', 'Rose', '1992-09-28',4);
INSERT INTO Student VALUES('Charlie', 'Williams', '1992-09-28',4);
INSERT INTO Student VALUES('Otto', 'Vlom', '1992-09-28',4);
INSERT INTO Student VALUES('Hellen', 'Lops', '1992-09-28',1);
INSERT INTO Student VALUES('Timmy', 'Jackson', '1992-09-28',2);
INSERT INTO Student VALUES('Edward', 'Chills', '1992-09-28',1);
INSERT INTO Student VALUES('Norbert', 'Derine', '1992-09-28',4);
INSERT INTO Student VALUES('Leonard', 'Richards', '1992-09-28',3);

--CREATE HELICOPTERS--

INSERT INTO Helicopters VALUES('H482RTF', 3);
INSERT INTO Helicopters VALUES('H992RTF', 2);
INSERT INTO Helicopters VALUES('H029RTF', 4);
INSERT INTO Helicopters VALUES('H329RTF', 1);

SELECT * 
FROM Student
INNER JOIN Instructor 
ON Student.InstructorID = Instructor.InstructorID
INNER JOIN Helicopters 
ON Student.InstructorID = Helicopters.InstructorID


SELECT First_Name, Last_Name, DATEDIFF(d, JoinedOn, GETDATE()) AS "DaysSinceJoined"
FROM Instructor
ORDER BY DaysSinceJoined DESC


SELECT First_Name, Last_Name, DATEADD(d,7,GETDATE()) AS "RedoLicence"
FROM Instructor
ORDER BY First_Name ASC

UPDATE Student SET InstructorID=2 WHERE StudentID=2

DELETE FROM Student WHERE StudentID = 15

SELECT * FROM Student

SELECT * FROM Student WHERE First_Name LIKE 'B%'