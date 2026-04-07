CREATE DATABASE StockManagementDB;
USE StockManagementDB;

CREATE TABLE stocks
(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100),
	quantity INT
);

CREATE TABLE order_items 
(
	order_item_id INT IDENTITY(1,1) PRIMARY KEY,
	product_id INT,
	ordered_quantity INT
);

INSERT INTO stocks (product_id, product_name, quantity)
VALUES (1, 'Laptop', 50),(2, 'Mouse', 100), (3, 'Keyborad', 75);

SELECT * FROM stocks;


CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN

BEGIN TRY
	IF EXISTS (
		SELECT 1
		FROM inserted i
		JOIN stocks s
		ON i.product_id = s.product_id
		WHERE s.quantity < i.ordered_quantity
	)
	BEGIN
		THROW 50001, 'Insufficient Stock Available', 1;
	END
		UPDATE s
		SET s.quantity = s.quantity - i.ordered_quantity
		FROM stocks s
		JOIN inserted i
		ON s.product_id = i.product_id;

END TRY 

BEGIN CATCH
	ROLLBACK TRANSACTION

	DECLARE @ErrorMessage NVARCHAR(4000);
	SET @ErrorMessage = ERROR_MESSAGE();

	RAISERROR(@ErrorMessage,16,1);

END CATCH

END;

INSERT INTO order_items(product_id, ordered_quantity)
VALUES(1,5);

SELECT * FROM stocks;

INSERT INTO order_items(product_id, ordered_quantity)
VALUES(1,500);

SELECT * FROM stocks;

SELECT * FROM order_items;