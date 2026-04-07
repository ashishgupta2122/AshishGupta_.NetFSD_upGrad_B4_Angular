CREATE DATABASE EcommDb;

USE EcommDb;

CREATE TABLE customers (
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(50),
	last_name VARCHAR(50)
);

CREATE TABLE orders (
	order_id INT PRIMARY KEY,
	customer_id INT,
	order_date DATE,

	FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE order_items (
	order_item_id INT PRIMARY KEY,
	order_id INT,
	quantity INT,
	list_price DECIMAL(10,2),
	discount DECIMAL(10,2),

	FOREIGN KEY (order_id) REFERENCES orders(order_id)
	);

INSERT INTO customers VALUES
(1, 'Ashish', 'Gupta'),
(2, 'Rahul', 'Sharma'),
(3, 'Aman', 'Singh'),
(4, 'Priya', 'Verma');

INSERT INTO orders VALUES
(1,1, '2024-01-10'),
(2,2, '2024-02-15'),
(3,1, '2024-03-20');

SELECT
CONCAT(c.first_name,' ',c.last_name) AS full_name,

(
SELECT SUM(oi.quantity * oi.list_price - oi.discount)
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.customer_id = c.customer_id
) AS total_order_value,

CASE

WHEN
(
SELECT SUM(oi.quantity * oi.list_price - oi.discount)
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.customer_id = c.customer_id
) > 10000

THEN 'Premium'

WHEN
(
SELECT SUM(oi.quantity * oi.list_price - oi.discount)
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.customer_id = c.customer_id
) BETWEEN 5000 AND 10000

THEN 'Regular'

ELSE 'Basic'

END AS customer_category

FROM customers c

WHERE c.customer_id IN
(
SELECT customer_id FROM orders
)

UNION

SELECT
CONCAT(first_name,' ',last_name),
NULL,
'NO Orders'

FROM customers

WHERE customer_id NOT IN
(
SELECT customer_id FROM orders
);