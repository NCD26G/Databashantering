SELECT * FROM suppliers;

INSERT INTO suppliers("suppliername")
VALUES('Nike');

INSERT INTO products("itemnumber","productname",price,supplier_id)
VALUES('1020','Test produkt', -100,1);

INSERT INTO products(itemnumber,productname,price,supplier_id)
VALUES('1020','Test produkt', 100,1)

INSERT INTO products(itemnumber,productname,price,supplier_id)
VALUES('1021','Test produkt', 100,2)

SELECT * FROM products

INSERT INTO customers(firstname,lastname,email)
VALUES
    ('Michael','Gustavsson','michael@mail.com'),
    ('Emma','Olsson','emma@mail.com');

SELECT * FROM customers;

INSERT INTO addresstypes(addresstype)
VALUES('Billing'),('Delivery'),('Office')

SELECT * FROM addresstypes;

INSERT INTO cities(city)VALUES('Stenungsund'),('Göteborg'),('Kungälv');

SELECT * FROM cities;

INSERT INTO postalcodes(postalcode,city_id)VALUES('44431',1),('44432',3),('44445',1);

SELECT * FROM postalcodes INNER JOIN cities
    ON postalcodes.city_id = cities.id;
INSERT INTO addresses(addressline,postalcode_id,addresstype_id)VALUES('Strandvägen 1',1,1),('Storgatan 10',1,2),('Hjälmaregaten 14',2,1);

SELECT * FROM addresses INNER JOIN postalcodes
    ON addresses.postalcode_id = postalcodes.id INNER JOIN cities
    ON postalcodes.city_id = cities.id INNER JOIN addresstypes
    ON addresses.addresstype_id = addresstypes.id;

INSERT INTO customeraddresses(customer_id,address_id)
VALUES
(1,1),
(1,3),
(2,1)

INSERT INTO supplieraddresses(supplier_id,address_id)
VALUES
(1,1)

SELECT * FROM supplieraddresses;

SELECT * FROM customeraddresses INNER JOIN customers
    ON customers.id = customeraddresses.customer_id INNER JOIN addresses
    ON addresses.id = customeraddresses.address_id INNER JOIN postalcodes
    ON addresses.postalcode_id = postalcodes.id INNER JOIN cities
    ON postalcodes.city_id = cities.id;

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
VALUES(1,2,1,995);

INSERT INTO orderitems(order_id,product_id,quantity,price)
VALUES(2,1,1,2995),(2,2,2,1595);

SELECT * FROM orderitems INNER JOIN salesorders
    ON orderitems.order_id = salesorders.id INNER JOIN customers
    ON salesorders.customer_id = customers.id;

SELECT * FROM orderitems INNER JOIN salesorders
    ON orderitems.order_id = salesorders.id INNER JOIN products
    ON orderitems.product_id = products.id