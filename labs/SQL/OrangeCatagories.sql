use master
go

drop database if exists OrangesDB
go

create database OrangesDB
go

use OrangesDB
go

create table Categories(
CategoryID INT NOT NULL IDENTITY PRIMARY KEY,
CategoryName NVARCHAR(50) NULL
)

create table Orange(
OrangeID INT NOT NULL IDENTITY PRIMARY KEY,
OrangeName NVARCHAR(50) NULL,
DateHarvested DATE NULL,
IsLuxuryGrade BIT NULL,
CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
)


create table Batch(
BatchID INT NOT NULL IDENTITY PRIMARY KEY,
OrangeID INT NULL FOREIGN KEY REFERENCES Orange(OrangeID),
Quantity INT NULL,
DispatchDate DATE NULL
)


/*PopulateCategoryTableFirst*/
INSERT INTO Categories VALUES('clementines');
INSERT INTO Categories VALUES('reds');
INSERT INTO Categories VALUES('easy peelers');

INSERT INTO Orange VALUES('Clementine','2019-09-07', 0 , '1');
INSERT INTO Orange VALUES('Blood Orange','2019-09-17', 1 ,'3');
INSERT INTO Orange VALUES('Tangerine','2019-09-12', 1 ,'2');
INSERT INTO Orange VALUES('Celmentine','2018-12-25', 0 ,'1');

INSERT INTO Batch VALUES(1, 100 ,GETDATE());
INSERT INTO Batch VALUES(2, 100 ,GETDATE());
INSERT INTO Batch VALUES(3, 100 ,GETDATE());
INSERT INTO Batch VALUES(4, 50 , '2019-08-01');



SELECT * FROM Orange

SELECT OrangeID, OrangeName, CategoryName FROM Orange 
INNER JOIN Categories
ON Orange.CategoryID = Categories.CategoryID

SELECT OrangeID, OrangeName, CategoryName, DateHarvested, DATEADD(d,90, DateHarvested) AS 'ExpiryDate'
FROM Orange 
INNER JOIN Categories
ON Orange.CategoryID = Categories.CategoryID

SELECT *, DATEDIFF(d,Orange.DateHarvested, GETDATE()) AS 'SinceHarvest', IIF(DATEDIFF(d,Orange.DateHarvested, GETDATE()) > 90, 1, 0) AS "isExpired"
FROM Batch
INNER JOIN Orange
ON Orange.OrangeID = Batch.OrangeID


UPDATE Categories SET CategoryName = 'red' WHERE CategoryID = 2

SELECT * FROM Categories

INSERT INTO Orange VALUES('Dummy','2018-12-25', 0 ,'1');
SELECT * FROM Orange
DELETE FROM Orange WHERE OrangeID = 5
SELECT * FROM Orange

