use Northwind
go

--****************
--***Question 1***
--****************

--1.1--

--SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country
--FROM Customers
--WHERE LOWER(City) = 'paris' OR LOWER(City) = 'london'


--1.2--

--SELECT *
--FROM Products
--WHERE QuantityPerUnit LIKE '%bottle%'

--1.3--

--SELECT Products.*, Suppliers.CompanyName, Suppliers.Country
--FROM Products
--JOIN Suppliers
--ON Products.SupplierID = Suppliers.SupplierID
--WHERE QuantityPerUnit LIKE '%bottle%'

--1.4--

--SELECT Categories.CategoryName, COUNT(Categories.CategoryName) AS 'Number Of Products'
--FROM Products
--JOIN Categories
--ON Products.CategoryID = Categories.CategoryID
--GROUP BY Categories.CategoryName
--ORDER BY [Number Of Products] DESC

--SELECT Categories.CategoryName
--FROM Products
--JOIN Categories
--ON Products.CategoryID = Categories.CategoryID
--WHERE Categories.CategoryName = 'Produce'

--1.5--

--SELECT CONCAT(TitleOfCourtesy, ' ', FirstName, ' ', LastName) AS fullname, City
--FROM Employees
--WHERE Country = 'UK';

--1.6--

--List Sales Totals for all Sales Regions 
--(via the Territories table using 4 joins) with a Sales Total greater than 1,000,000. 
--Use rounding or FORMAT to present the numbers.


--SELECT Region.RegionDescription FROM Territories
--JOIN Region
--ON Territories.RegionID = Region.RegionID
--Group By Region.RegionID



--1.7--

--SELECT COUNT(*) FROM Orders
--WHERE Freight > 100 AND (ShipCountry = 'USA' OR ShipCountry = 'UK');

--1.8--

--SELECT TOP 1 OrderID, Discount, ((UnitPrice * Quantity) * Discount) AS 'DiscountApplied' FROM [Order Details]
--ORDER BY 'DiscountApplied' DESC, Discount DESC


--****************
--***QUESTION 2***
--****************

--CREATE TABLE Spartan(
--	SpartanID INT NOT NULL IDENTITY PRIMARY KEY,
--	Title NVARCHAR(5) NULL,
--	First_Name NVARCHAR(50) NULL,
--	Last_Name NVARCHAR(50) NULL,
--	University NVARCHAR(150) NULL,
--	Course_Taken NVARCHAR(150) NULL,
--	Degree_Grade NVARCHAR(3) NULL,
--	Graduated_Date DATE NULL,
--	Graduated BIT NULL
--);




--SELECT Region.RegionID, Region.RegionDescription, SUM([Order Details].Quantity * [Order Details].UnitPrice) AS 'Total Sales'  
--FROM Territories
--INNER JOIN EmployeeTerritories
--ON Territories.TerritoryID = EmployeeTerritories.TerritoryID
--INNER JOIN Region
--ON Region.RegionID = Territories.RegionID
--INNER JOIN Orders
--ON EmployeeTerritories.EmployeeID = Orders.EmployeeID
--INNER JOIN [Order Details]
--ON Orders.OrderID = [Order Details].OrderID
--GROUP BY Region.RegionID, Region.RegionDescription
--HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice) > 1000000;

--SELECT Employees.EmployeeID, CONCAT(Employees.FirstName, ' ', Employees.LastName) AS EmployeeName, CONCAT(Managers.FirstName, ' ', Managers.LastName) AS ReportTo
--FROM Employees
--INNER JOIN Employees AS Managers
--ON Employees.ReportsTo = Managers.EmployeeID

--SELECT Suppliers.SupplierID, Suppliers.CompanyName, ROUND(SUM([Order Details].Quantity * [Order Details].UnitPrice * (1-[Order Details].Discount)), 0) AS 'TotalSales(Including Discount)'
--FROM [Order Details]
--JOIN Products
--ON [Order Details].ProductID = Products.ProductID
--JOIN Suppliers
--ON Products.SupplierID = Suppliers.SupplierID
--GROUP BY Suppliers.SupplierID, Suppliers.CompanyName
--HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice * (1-[Order Details].Discount)) > 10000
--ORDER BY 'TotalSales(Including Discount)' ASC

--SELECT TOP 10
--FROM Customers
--JOIN 

--SELECT Employees.FirstName, Employees.EmployeeID, COUNT(Orders.OrderID) FROM Orders 
--JOIN Employees
--ON Orders.EmployeeID = Employees.EmployeeID
--GROUP BY Employees.EmployeeID, Employees.FirstName
--ORDER BY COUNT(Orders.OrderID)

--SELECT Categories.CategoryID, Categories.CategoryName, COUNT(Categories.CategoryName) AS 'Number Of Products'
--FROM Products
--JOIN Categories
--ON Products.CategoryID = Categories.CategoryID
--GROUP BY Categories.CategoryID, Categories.CategoryName
--ORDER BY [Number Of Products] DESC

--SELECT * FROM Products WHERE UnitsInStock > 100

----SELECT Products.*, Suppliers.CompanyName, Suppliers.Country
----FROM Products
----JOIN Suppliers
----ON Products.SupplierID = Suppliers.SupplierID
----WHERE QuantityPerUnit LIKE '%bottle%'

--SELECT Suppliers.SupplierID, Suppliers.CompanyName, ROUND(SUM([Order Details].Quantity * [Order Details].UnitPrice * (1-[Order Details].Discount)), 0) AS 'TotalSales(Including Discount)'
--FROM [Order Details]
--JOIN Products
--ON [Order Details].ProductID = Products.ProductID
--JOIN Suppliers
--ON Products.SupplierID = Suppliers.SupplierID
--GROUP BY Suppliers.SupplierID, Suppliers.CompanyName
--HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice * (1-[Order Details].Discount)) > 10000
--ORDER BY 'TotalSales(Including Discount)' ASC

--SELECT Region.RegionID, Region.RegionDescription, SUM(([Order Details].Quantity * [Order Details].UnitPrice) * (1-[Order Details].Discount)) AS 'Total Sales'  
--FROM Territories
--INNER JOIN EmployeeTerritories
--ON Territories.TerritoryID = EmployeeTerritories.TerritoryID
--INNER JOIN Region
--ON Region.RegionID = Territories.RegionID
--INNER JOIN Orders
--ON EmployeeTerritories.EmployeeID = Orders.EmployeeID
--INNER JOIN [Order Details]
--ON Orders.OrderID = [Order Details].OrderID
--GROUP BY Region.RegionID, Region.RegionDescription
--HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice) > 1000000;

--SELECT TOP 10 Orders.OrderID, Orders.ShippedDate, Customers.ContactName, FORMAT(SUM([Order Details].UnitPrice * [Order Details].Quantity *(1-[Order Details].Discount)), 'c') AS 'TotalSpent' 
--FROM [Order Details]
--JOIN Orders
--ON Orders.OrderID = [Order Details].OrderID
--JOIN Customers
--ON Orders.CustomerID = Customers.CustomerID
--GROUP BY Customers.ContactName,Orders.OrderID, Orders.ShippedDate
--HAVING Orders.ShippedDate > DATEADD(y,-1,MAX(Orders.ShippedDate))
--ORDER BY SUM([Order Details].UnitPrice * [Order Details].Quantity *(1-[Order Details].Discount)) DESC

--SELECT TOP 10 Orders.ShippedDate, Customers.ContactName, FORMAT(SUM([Order Details].UnitPrice * [Order Details].Quantity *(1-[Order Details].Discount)), 'c') AS 'TotalSpent' 
--FROM [Order Details]
--JOIN Orders
--ON Orders.OrderID = [Order Details].OrderID
--JOIN Customers
--ON Orders.CustomerID = Customers.CustomerID
--GROUP BY Customers.ContactName, Orders.ShippedDate
--HAVING Orders.ShippedDate > DATEADD(y,-1,MAX(Orders.ShippedDate))
--ORDER BY SUM([Order Details].UnitPrice * [Order Details].Quantity *(1-[Order Details].Discount)) DESC


--------3.4--------
--SELECT FORMAT(ShippedDate, 'MMM') AS 'ShippedMonth',FORMAT(ShippedDate, 'yyyy') AS 'ShippedYear', AVG(DATEDIFF(d, OrderDate, ShippedDate)) AS 'Average Ship Time'
--FROM Orders 
--GROUP BY FORMAT(ShippedDate, 'yyyy'), FORMAT(ShippedDate, 'MMM')
--ORDER BY 'ShippedYear', 'ShippedMonth'

