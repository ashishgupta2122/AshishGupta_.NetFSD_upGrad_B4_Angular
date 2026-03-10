CREATE DATABASE RetailStoreDB;
GO

USE RetailStoreDB;
GO


CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    StoreID INT,
    OrderDate DATE,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Discount DECIMAL(5,2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


INSERT INTO Stores VALUES
(1,'Lucknow Store'),
(2,'Delhi Store'),
(3,'Mumbai Store');

INSERT INTO Products VALUES
(101,'Laptop',50000),
(102,'Mobile',20000),
(103,'Keyboard',1000),
(104,'Mouse',500),
(105,'Monitor',8000);

INSERT INTO Orders VALUES
(1,1,'2025-01-10'),
(2,2,'2025-01-12'),
(3,1,'2025-01-15'),
(4,3,'2025-01-18');

INSERT INTO OrderDetails VALUES
(1,1,101,1,10),
(2,1,103,2,5),
(3,2,102,1,15),
(4,3,104,3,0),
(5,4,105,2,8);


CREATE PROCEDURE sp_GetTotalSalesPerStore
@StoreID INT
AS
BEGIN

SELECT 
s.StoreID,
s.StoreName,
SUM(p.Price * od.Quantity) AS TotalSales

FROM Orders o
JOIN Stores s ON o.StoreID = s.StoreID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID

WHERE s.StoreID = @StoreID

GROUP BY s.StoreID, s.StoreName;

END;

EXEC sp_GetTotalSalesPerStore 1;



CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN

SELECT 
OrderID,
StoreID,
OrderDate

FROM Orders

WHERE OrderDate BETWEEN @StartDate AND @EndDate

ORDER BY OrderDate;

END;

EXEC sp_GetOrdersByDateRange '2025-01-01','2025-01-20';


CREATE FUNCTION fn_CalculateDiscountPrice
(
@Price DECIMAL(10,2),
@Quantity INT,
@Discount DECIMAL(5,2)
)

RETURNS DECIMAL(10,2)

AS
BEGIN

DECLARE @Total DECIMAL(10,2)

SET @Total = ISNULL(@Price,0) * ISNULL(@Quantity,0)

SET @Total = @Total - (@Total * ISNULL(@Discount,0) / 100)

RETURN @Total

END;


SELECT dbo.fn_CalculateDiscountPrice(1000,2,10) AS FinalPrice;


CREATE FUNCTION fn_TopSellingProducts()

RETURNS TABLE

AS

RETURN
(
SELECT TOP 5
p.ProductID,
p.ProductName,
SUM(od.Quantity) AS TotalSold

FROM OrderDetails od
JOIN Products p ON od.ProductID = p.ProductID

GROUP BY p.ProductID, p.ProductName

ORDER BY TotalSold DESC
);



SELECT * FROM fn_TopSellingProducts();


SELECT 
p.ProductName,
od.Quantity,
p.Price,
od.Discount,

dbo.fn_CalculateDiscountPrice
(
p.Price,
od.Quantity,
od.Discount
) AS FinalPrice

FROM OrderDetails od
JOIN Products p
ON od.ProductID = p.ProductID;