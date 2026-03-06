CREATE DATABASE StorePerformanceDB;

USE StorePerformanceDB;

CREATE TABLE stores (
	store_id INT PRIMARY KEY,
	store_name VARCHAR(100)
	);

CREATE TABLE products (
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100),
	list_price DECIMAL(10,2)
);

CREATE TABLE orders (
	order_id INT PRIMARY KEY,
	store_id INT,
	order_date DATE,
	FOREIGN KEY (store_id) REFERENCES stores(store_id)
	);

CREATE TABLE order_items (
	item_id INT PRIMARY KEY,
	order_id INT,
	product_id INT,
	quantity INT,
	discount DECIMAL(10,2),
	FOREIGN KEY (order_id) REFERENCES orders(order_id),
	FOREIGN KEY (product_id) REFERENCES products(product_id)
	);

CREATE TABLE stocks (
	store_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY (store_id, product_id),
	 FOREIGN KEY (store_id) REFERENCES stores(store_id),
	FOREIGN KEY (product_id) REFERENCES products(product_id)
	);

INSERT INTO stores VALUES
(1, 'Delhi Store'),
(2, 'Mumbai Store'),
(3, 'Lucknow Store');

INSERT INTO products VALUES
(101, 'laptop', 60000),
(102, 'Mobile', 20000),
(103,'Tablet',15000),
(104,'Headphones',3000);

INSERT INTO orders VALUES
(1,1,'2026-03-01'),
(2,2,'2026-03-02'),
(3,3,'2026-03-03');

INSERT INTO order_items VALUES
(1,1,101,2,1000),
(2,1,102,3,500),
(3,2,101,1,500),
(4,2,104,5,200),
(5,3,103,4,300);

INSERT INTO stocks VALUES
(1,101,0),
(1,102,10),
(2,101,0),
(2,104,8),
(3,103,0);

SELECT * FROM (
	SELECT s.store_name,
	p.product_name,
	SUM(oi.quantity) AS total_quantity_sold
	FROM order_items oi
	JOIN orders o ON oi.order_id = o.order_id
	JOIN stores s ON o.store_id = s.store_id
    JOIN products p ON oi.product_id = p.product_id
    GROUP BY s.store_name, p.product_name
	) AS SoldProducts;


SELECT product_id
FROM order_items

INTERSECT

SELECT product_id
FROM stocks
WHERE quantity > 0;

SELECT product_id
FROM order_items

EXCEPT

SELECT product_id
FROM stocks
WHERE quantity > 0;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * p.list_price) - oi.discount) AS total_revenue
FROM order_items oi
JOIN orders o ON oi.order_id = o.order_id
JOIN stores s ON o.store_id = s.store_id
JOIN products p ON oi.product_id = p.product_id
JOIN stocks st ON st.product_id = p.product_id 
               AND st.store_id = s.store_id
WHERE st.quantity = 0
GROUP BY s.store_name, p.product_name;

UPDATE stocks
SET quantity = 0
WHERE product_id = 104;

SELECT * FROM stocks;