drop database if exists FlightSchool
go

create database FlightSchool
go

use FlightSchool
go

CREATE TABLE Student(
	StudentID INT NOT NULL IDENTITY PRIMARY KEY,
	First_Name VARCHAR(50) NULL,
	Last_Name VARCHAR(50) NULL,
	Age INT NULL,
	InstructorID INT NULL FOREIGN KEY REFERENCES Instructor(InstructorID)
);

CREATE TABLE Instructor(
	InstructorID INT NOT NULL IDENTITY PRIMARY KEY,
	First_Name VARCHAR(50) NULL,
	Last_Name VARCHAR(50) NULL,
	Age INT NULL
);

INSERT INTO Instructor (First_Name, Last_Name, Age) VALUES('Bobby', 'Jones', 36);

SELECT * FROM Instructor;