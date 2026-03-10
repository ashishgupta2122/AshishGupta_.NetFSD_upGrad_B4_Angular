CREATE DATABASE AutoRetailDB;
USE AutoRetailDB;

CREATE TABLE Products 
(
	ProductID INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(100),
	StockQuantity INT NOT NULL,
	Price DECIMAL(10,2)
);

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	OrderDate DATETIME DEFAULT GETDATE()
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

INSERT INTO Products(ProductName, StockQuantity, Price)
VALUES('Car Battery', 20, 5000),('Engine Oil', 50, 800),('Brake Pad', 30, 1200);


CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

	IF EXISTS (
		SELECT 1
		FROM Products p
		JOIN inserted i ON p.ProductID = i.ProductID
		WHERE p.StockQuantity < i.Quantity
	)
	BEGIN
		RAISERROR('Stock is insufficient',16,1);
		ROLLBACK TRANSACTION;
		RETURN;
	END

	UPDATE p
	SET p.StockQuantity = p.StockQuantity - i.Quantity
	FROM Products p
	JOIN inserted i
	ON p.ProductID = i.ProductID;

END;

BEGIN TRANSACTION
BEGIN TRY

	INSERT INTO Orders DEFAULT VALUES;

	DECLARE @OrderID INT;
	SET @OrderID = SCOPE_IDENTITY();

	INSERT INTO Order_Items(OrderID, ProductID, Quantity) VALUES
	(@OrderID, 1, 2), (@OrderID, 2, 5);

	COMMIT TRANSACTION;
	PRINT 'Order placed Successfully';

END TRY

BEGIN CATCH

	ROLLBACK TRANSACTION;
	PRINT 'Order failed due to insufficient stock';

END CATCH;


BEGIN TRANSACTION

INSERT INTO Orders DEFAULT VALUES;

DECLARE @OrderID INT;
SET @OrderID = SCOPE_IDENTITY();

INSERT INTO Order_Items(OrderID, ProductID, Quantity)
VALUES(@OrderID, 1, 3);

COMMIT;

BEGIN TRANSACTION

INSERT INTO Orders DEFAULT VALUES;

DECLARE @OrderID INT;
SET @OrderID = SCOPE_IDENTITY();

INSERT INTO Order_Items(OrderID, ProductID, Quantity)
VALUES (@OrderID, 1, 100);

COMMIT;

SELECT * FROM Products;