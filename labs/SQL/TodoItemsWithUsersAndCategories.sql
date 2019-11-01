use master
go

drop database if exists ToDoItemsDatabase
go

create database ToDoItemsDatabase
go

use ToDoItemsDatabase
go

CREATE TABLE Users(
	UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(50) NULL
)

CREATE TABLE Categories(
	CategoryID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CategoryName NVARCHAR(50) NULL
)

CREATE TABLE ToDoItems (
	ToDoItemID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Item VARCHAR(50) NULL,
	DateDue DATE NULL,
	Done BIT NULL,
	UserID INT NULL FOREIGN KEY REFERENCES Users(UserID),
	CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
)

INSERT INTO Users VALUES ('Bob')
INSERT INTO Users VALUES ('Rachel')
INSERT INTO Users VALUES ('Norris')


INSERT INTO Categories VALUES ('Main')
INSERT INTO Categories VALUES ('Secondary')


INSERT INTO ToDoItems VALUES ('First Task', '2019-08-07', 0, 1, 1)
INSERT INTO ToDoItems VALUES ('Second Task', '2019-08-07', 0, 2, 2)
INSERT INTO ToDoItems VALUES ('Third Task', '2019-08-07', 0, 1, 2)

SELECT * FROM ToDoItems