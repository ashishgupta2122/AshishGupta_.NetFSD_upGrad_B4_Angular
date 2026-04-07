CREATE DATABASE RetailSystem;

USE RetailSystem;

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    StockQuantity INT,
    Price DECIMAL(10,2)
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME DEFAULT GETDATE(),
    OrderStatus INT
);

CREATE TABLE Order_Items
(
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT,

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Products(ProductName,StockQuantity,Price)
VALUES
('Car Battery',20,5000),
('Engine Oil',40,800),
('Brake Pad',30,1200);

INSERT INTO Orders(OrderStatus)
VALUES(2);

INSERT INTO Order_Items(OrderID,ProductID,Quantity)
VALUES
(1,1,2),
(1,2,3);

CREATE PROCEDURE Cancel_Order
@OrderID INT
AS
BEGIN

BEGIN TRY

    
    BEGIN TRANSACTION;

    
    SAVE TRANSACTION BeforeStockRestore;


    UPDATE P
    SET P.StockQuantity = P.StockQuantity + OI.Quantity
    FROM Products P
    JOIN Order_Items OI
    ON P.ProductID = OI.ProductID
    WHERE OI.OrderID = @OrderID;

    UPDATE Orders
    SET OrderStatus = 3
    WHERE OrderID = @OrderID;

    COMMIT TRANSACTION;

    PRINT 'Order cancelled successfully and stock restored';

END TRY

BEGIN CATCH

    PRINT 'Error occurred while restoring stock';

    ROLLBACK TRANSACTION BeforeStockRestore;

    ROLLBACK TRANSACTION;

END CATCH

END;