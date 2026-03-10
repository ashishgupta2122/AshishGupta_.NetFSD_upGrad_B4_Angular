CREATE DATABASE OrderManagementDB;
USE OrderManagementDB;

CREATE TABLE orders 
(
	order_id INT PRIMARY KEY IDENTITY(1,1),
	customer_name VARCHAR(100),
	order_status INT,
	shipped_date DATE
);

INSERT INTO orders(customer_name, order_status, shipped_date)
VALUES ('Rahul',1,NULL),('Amit', 2, NULL),('Neha',3,'2026-03-10');

SELECT * FROM orders;

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY 

	IF EXISTS
	(
		SELECT 1
		FROM inserted
		WHERE order_status = 4
		AND shipped_date IS NULL
	)

	BEGIN
		THROW 50002, 'Order cannot be completed without shipped_ date', 1;
	END
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION;

	DECLARE @ErrorMessage NVARCHAR(4000);
	SET @ErrorMessage = ERROR_MESSAGE();

	RAISERROR(@ErrorMessage,16,1);

END CATCH

END;

UPDATE orders
SET order_status = 4
WHERE order_id = 1;

UPDATE orders
SET shipped_date = '2026-03-11',
order_status = 4
WHERE order_id = 1;

SELECT * FROM orders;