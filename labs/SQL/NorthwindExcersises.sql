--SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country
--FROM Customers
--WHERE TOLOWER(City) = 'Paris' AND TOLOWER(City) = 'london'

--SELECT *
--FROM Products
--WHERE QuantityPerUnit LIKE '%bottle%'

--SELECT Products.*, Suppliers.CompanyName, Suppliers.Country
--FROM Products
--JOIN Suppliers
--ON Products.SupplierID = Suppliers.SupplierID
--WHERE QuantityPerUnit LIKE '%bottle%'

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


--SELECT CONCAT(ContactTitle, ' ', ContactName) AS fullname, City
--FROM Customers


