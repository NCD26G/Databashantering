SELECT * FROM suppliers;

INSERT INTO suppliers("suppliername")
VALUES('Nike');

INSERT INTO products("itemnumber","productname",price,supplier_id)
VALUES('1020','Test produkt', -100,1)

INSERT INTO Customers("firstname","lastname","email")
VALUES
('Michael','Gustavsson','michael@mail.com'),
('Emma','Olsson','emma@mail.com');

SELECT * FROM customers;

INSERT INTO salesorders("ordernumber","customer_id")
VALUES
('1000',1),
('1001',1),
('1002',1);

INSERT INTO salesorders("ordernumber","customer_id")
VALUES
('1003',2),
('1004',2);

SELECT ordernumber,orderdate,firstname,lastname,email FROM salesorders INNER JOIN customers
    ON salesorders.customer_id = customers.id;

INSERT INTO "Address"("AddressLine","CustomerId")
VALUES('Gatan 1',1),('Gatan 2',1)

SELECT * FROM "Address"

SELECT * FROM customers INNER JOIN "Address"
ON customers.id = "Address"."CustomerId"
