CREATE DATABASE ProductDB;
USE ProductDB;

CREATE TABLE brands(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE categories(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant');

INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes');

INSERT INTO products VALUES
(1,'Trek X-Caliber',1,1,2023,800),
(2,'Giant ATX',2,1,2022,600),
(3,'Trek Domane',1,2,2023,1200);

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;