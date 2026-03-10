CREATE DATABASE StoreRevenueDB;
USE StoreRevenueDB;

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
)

CREATE TABLE orders
(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_status INT
);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_name VARCHAR(100),
    price DECIMAL(10,2),
    quantity INT,
    discount DECIMAL(5,2)
);

INSERT INTO stores VALUES
(1,'Delhi Store'),
(2,'Mumbai Store');

INSERT INTO orders (store_id, order_status) VALUES
(1,4),
(1,4),
(2,4),
(2,2);

INSERT INTO order_items (order_id, product_name, price, quantity, discount)
VALUES
(1,'Laptop',50000,1,2000),
(1,'Mouse',500,2,50),
(2,'Keyboard',1500,1,100),
(3,'Monitor',10000,1,500);

CREATE TABLE #RevenueTemp
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(10,2)
);

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(10,2)

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;

BEGIN TRY

BEGIN TRANSACTION;

OPEN order_cursor;

FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @revenue =
    SUM((price * quantity) - discount)
    FROM order_items
    WHERE order_id = @order_id;

    INSERT INTO #RevenueTemp(order_id, store_id, revenue)
    VALUES(@order_id, @store_id, @revenue);

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

END

CLOSE order_cursor;
DEALLOCATE order_cursor;

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

DECLARE @ErrorMessage NVARCHAR(4000);
SET @ErrorMessage = ERROR_MESSAGE();

RAISERROR(@ErrorMessage,16,1);

END CATCH;

SELECT 
s.store_id,
s.store_name,
SUM(r.revenue) AS total_revenue
FROM #RevenueTemp r
JOIN stores s
ON r.store_id = s.store_id
GROUP BY s.store_id, s.store_name;