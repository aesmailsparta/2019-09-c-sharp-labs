create database MiniBank
go

select 'Here is a comment'

use MiniBank
go

CREATE TABLE Customer(
	CustomerID INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NULL,
	PhoneNumber VARCHAR(16) NULL,
	Email VARCHAR(150) NULL,
	PIN VARCHAR(20) NULL
);

CREATE TABLE Account(
	AccountID INT NOT NULL IDENTITY PRIMARY KEY,
	CustomerID INT NULL,
	AccountNumber VARCHAR(50) NULL,
	Amount INT NULL
);

CREATE TABLE Bank_Transaction(
	TransactionID INT NOT NULL IDENTITY PRIMARY KEY,
	AccountID INT NULL,
	Amount INT NULL,
	TransactionType INT
);
