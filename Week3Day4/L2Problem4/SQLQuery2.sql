CREATE DATABASE OrderMaintenanceDB;
USE OrderMaintenanceDB;

CREATE TABLE customers (
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50)
	);

CREATE TABLE orders (
	order_id INT PRIMARY KEY,
	customer_id INT,
	order_date DATE,
	required_date DATE,
	shipped_date DATE,
	order_status INT,
	FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
	);

CREATE TABLE archived_orders (
	order_id INT,
	customer_id INT,
	order_date DATE,
	required_date DATE,
	shipped_data DATE,
	order_status INT
	);

INSERT INTO customers VALUES
(1,'Rahul','Sharma'),
(2,'Amit','Verma'),
(3,'Neha','Singh');

INSERT INTO orders VALUES
(101,1,'2024-01-10','2024-01-20','2024-01-18',2),
(102,1,'2024-02-01','2024-02-10','2024-02-12',2),
(103,2,'2023-01-05','2023-01-15','2023-01-10',3),
(104,2,'2023-02-10','2023-02-20','2023-02-22',3),
(105,3,'2024-03-01','2024-03-10','2024-03-08',2);

INSERT INTO archived_orders
SELECT * FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

SELECT * FROM archived_orders;

DELETE FROM orders
WHERE order_id IN
(
    SELECT order_id
    FROM archived_orders
);

SELECT customer_id
FROM customers
WHERE customer_id IN
(
    SELECT customer_id
    FROM orders
    GROUP BY customer_id
    HAVING COUNT(*) =
    SUM(CASE WHEN order_status = 2 THEN 1 ELSE 0 END)
);

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay_days
FROM orders;

SELECT 
order_id,
order_date,
required_date,
shipped_date,

CASE 
    WHEN shipped_date > required_date 
    THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status

FROM orders;

SELECT 
order_id,
customer_id,
order_date,
required_date,
shipped_date,

DATEDIFF(DAY, order_date, shipped_date) AS processing_delay,

CASE 
    WHEN shipped_date > required_date 
    THEN 'Delayed'
    ELSE 'On Time'
END AS order_status_result

FROM orders;