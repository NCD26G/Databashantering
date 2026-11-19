SELECT * FROM suppliers;

INSERT INTO suppliers("suppliername")
VALUES('Nike');

INSERT INTO products("itemnumber","productname",price,supplier_id)
VALUES('1020','Test produkt', -100,1)

INSERT INTO customers(firstname,lastname,email)
VALUES
    ('Michael','Gustavsson','michael@mail.com'),
    ('Emma','Olsson','emma@mail.com');

SELECT * FROM customers;

INSERT INTO addresses("addressline")VALUES('Strandvägen 1'),('Storgatan 10'),('Hjälmaregaten 14');
SELECT * FROM addresses

INSERT INTO customeraddresses(customer_id,address_id)
VALUES
(1,1),
(1,3),
(2,1)

SELECT * FROM customeraddresses INNER JOIN customers
    ON customers.id = customeraddresses.customer_id INNER JOIN addresses
    ON addresses.id = customeraddresses.address_id;

INSERT INTO salesorders("ordernumber","customer_id")
VALUES
('1000',1),
('1001',1),
('1002',1),
('1003',2),
('1004',2);

SELECT * FROM salesorders;

SELECT ordernumber,orderdate,firstname,lastname,email FROM salesorders INNER JOIN customers
    ON salesorders.customer_id = customers.id;

INSERT INTO orderitems(order_id,product_id,quantity,price)
VALUES(1,2,1,995)

SELECT * FROM orderitems INNER JOIN salesorders
    ON orderitems.order_id = salesorders.id INNER JOIN customers
    ON salesorders.customer_id = customers.id;

SELECT * FROM orderitems INNER JOIN salesorders
    ON orderitems.order_id = salesorders.id INNER JOIN products
    ON orderitems.product_id = products.id