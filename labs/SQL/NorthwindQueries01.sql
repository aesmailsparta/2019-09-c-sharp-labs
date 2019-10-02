--SELECT TOP 5 * FROM Customers ORDER BY CustomerID DESC

--SELECT * FROM Products WHERE UnitsInStock < 10 AND Discontinued = 0 ORDER BY UnitsInStock DESC

----UPDATE Products SET UnitsInStock = 200 WHERE ProductID = 31
----SELECT * FROM Products WHERE UnitsInStock < 10 AND Discontinued = 0 ORDER BY UnitsInStock DESC

----SELECT Country FROM Customers ORDER BY Country
----SELECT DISTINCT Country FROM Customers ORDER BY Country

--SELECT * FROM Products
--SELECT * FROM Products WHERE ProductName LIKE '%ch%'
--SELECT * FROM Products WHERE ProductName LIKE 'ch%'

--SELECT * FROM Products WHERE ProductName NOT LIKE 'ch%'

--SELECT * FROM Employees WHERE Region IN ('wa', 'bc')

--SELECT * FROM Products WHERE UnitPrice BETWEEN 10 AND 20 ORDER BY UnitPrice ASC

--COUNT CITY COUNTRY AVG PRICE MIN PRICE MAX PRICE SUM OF UNITS IN STOCK

--SELECT COUNT(DISTINCT(City)) AS Citys, COUNT(DISTINCT(Country)) AS Countries FROM Customers

--SELECT Count(*) AS NumberOfProducts, AVG(UnitPrice) AS AveragePrice, MIN(UnitPrice) AS MinPrice, MAX(UnitPrice) AS MaxPrice FROM Products

--SELECT SUM(UnitsInStock) AS TotalStock FROM Products

--SELECT Products.ProductName, [Order Details].UnitPrice, [Order Details].Discount, 
--([Order Details].UnitPrice * (1 - [Order Details].Discount)) AS 'DiscountPrice', 
--([Order Details].UnitPrice * [Order Details].Quantity) AS OrderValueBD, 
--([Order Details].UnitPrice * [Order Details].Quantity) AS OrderValueAD
--FROM [Order Details]
--JOIN Products
--ON [Order Details].ProductID = Products.ProductID
--ORDER BY Products.ProductName


--SELECT SUM([Order Details].UnitPrice * [Order Details].Quantity) AS OrderValueBefore
--FROM [Order Details]

--SELECT SUM([Order Details].UnitPrice * (1 - [Order Details].Discount)) AS OrderValueAfterDiscount
--FROM [Order Details]

--SELECT SUM([Order Details].UnitPrice * [Order Details].Quantity) AS 'Gross Sales',
--SUM([Order Details].UnitPrice * [Order Details].Quantity * (1-[Order Details].Discount)) AS 'Net Sales',
--(SUM([Order Details].UnitPrice * [Order Details].Quantity) - SUM([Order Details].UnitPrice * [Order Details].Quantity  * (1 - [Order Details].Discount))) AS 'DiscountAmount'
--FROM [Order Details]

--PRINT('Hello');

--SELECT SupplierID, SUM(UnitsOnOrder) AS 'Total Units On Order'
--FROM Products
--GROUP BY SupplierID
--HAVING SUM(UnitsOnOrder) = 0
--ORDER BY 'Total Units On Order'

--SELECT SupplierID, SUM(UnitsOnOrder) AS 'Total Units On Order'
--FROM Products
--GROUP BY SupplierID
--HAVING SUM(UnitsOnOrder) > 0
--ORDER BY 'Total Units On Order'

SELECT * 
FROM Customers
WHERE CustomerID NOT IN
	(SELECT CustomerID
		FROM Orders)


