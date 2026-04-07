CREATE DATABASE EcommDb;
USE EcommDb;

CREATE TABLE categories(
	category_id INT PRIMARY KEY,
	category_name VARCHAR(50)
	);

CREATE TABLE products (
	product_id INT PRIMARY KEY,
	product_name VARCHAR(100),
	category_id INT,
	model_year INT,
	list_price DECIMAL(10,2),

	FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO categories VALUES
(1, 'Mountain Bikes'),
(2, 'Road Bikes'),
(3, 'Electric Bikes');


INSERT INTO products VALUES
(1, 'Trek 820', 1,2017,379.99),
(2, 'Raleigh  Talus', 1,2018,499.99),
(3, 'Giant Escape', 2, 2017,399.99),
(4, 'Sepcialized Sirrus', 2, 2018,599.99),
(5, 'Electra Towniew', 3, 2019,799.99),
(6, 'Rad Power Bike', 3, 2020, 1299.99);

SELECT
CONCAT(product_name,' (',model_year,')') AS product_details, list_price,
(
SELECT AVG(p2.list_price)
FROM products p2
WHERE p2.category_id = p1.category_id
) AS category_avg_price,

list_price - (SELECT AVG(p3.list_price)
FROM products p3
WHERE p3.category_id = p1.category_id
) AS price_difference

FROM  products p1

WHERE list_price >
(
SELECT AVG(p4.list_price)
FROM products p4
WHERE p4.category_id = p1.category_id
);