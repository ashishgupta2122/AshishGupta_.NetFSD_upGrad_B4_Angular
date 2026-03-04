CREATE DATABASE StoreDB;

Use StoreDB;

CREATE TABLE customers (
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50)
);

CREATE TABLE orders (
	order_id INT PRIMARY KEY,
	customer_id INT,
	order_date DATE,
	order_status INT,
	FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
	);

	INSERT INTO customers(customer_id, first_name, last_name) VALUES
	(1, 'Ashish', 'Gupta'),
	(2, 'Basu', 'Sharma'),
	(3, 'Priya', 'Singh'),
	(4, 'Rohit', 'Gupta');

	INSERT INTO orders(order_id, customer_id, order_date, order_status) VALUES
	(101, 1, '2024-01-10', 1),
(102, 2, '2024-01-12', 4),
(103, 3, '2024-01-15', 2),
(104, 4, '2024-01-18', 1),
(105, 1, '2024-01-20', 4);

SELECT 
	c.first_name, 
	c.last_name, 
	o.order_id, 
	o.order_date, 
	o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1 OR o.order_status = 4
ORDER BY o.order_date DESC;