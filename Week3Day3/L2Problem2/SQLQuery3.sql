CREATE DATABASE InventoryDB;
USE InventoryDB;

CREATE TABLE products(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100)
);

CREATE TABLE stores(
	store_id INT PRIMARY KEY,
	store_name VARCHAR(100)
);

CREATE TABLE stocks(
	store_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY(store_id, product_id)
);

CREATE TABLE order_items(
	item_id INT PRIMARY KEY,
	product_id INT,
	quantity INT
);

INSERT INTO products VALUES
(1, 'Laptop'),
(2, 'Mobile');

INSERT INTO stores VALUES
(1, 'Delhi Store'),
(2, 'Mumbai Store');


INSERT INTO stocks VALUES
(1,1,10),
(1,2,5),
(2,1,8);

INSERT INTO order_items VALUES
(1,1,3),
(2,1,2),
(3,2,1);

SELECT
	p.product_name,
	s.store_name,
	st.quantity AS available_stock,
	SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name
