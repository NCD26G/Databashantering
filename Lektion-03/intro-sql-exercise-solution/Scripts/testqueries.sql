SELECT * FROM customers INNER JOIN salesorders ON customers.id = salesorders.customer_id;
SELECT * FROM salesorders;
SELECT * FROM customers;
SELECT * FROM addresses;
SELECT * FROM addresstypes;
SELECT * FROM products;
SELECT * FROM suppliers;
SELECT * FROM orderitems;

SELECT
    ordernumber,
    orderdate,
    --firstname || ' '  || lastname,
    firstname,
    lastname,
    customers.email,
    productname,
    suppliername,
    quantity,
    orderitems.price,
    discount,
    quantity * orderitems.price AS linesum
FROM salesorders INNER JOIN orderitems
    ON salesorders.id = orderitems.order_id INNER JOIN products
    ON orderitems.product_id = products.id INNER JOIN suppliers
    ON products.supplier_id = suppliers.id INNER JOIN customers
    ON salesorders.customer_id = customers.id;

-- Detta är ett annat sätt att hantera vilka kolumner som ska användas i kopplingar
-- respektive kolumner
SELECT
    ordernumber,
    orderdate,
    --firstname || ' '  || lastname,
    firstname,
    lastname,
    c.email,
    productname,
    suppliername,
    quantity,
    od.price,
    discount,
    quantity * od.price AS linesum
FROM salesorders AS o INNER JOIN orderitems AS od
    ON o.id = od.order_id INNER JOIN products AS p
    ON od.product_id = p.id INNER JOIN suppliers AS s
    ON p.supplier_id = s.id INNER JOIN customers AS c
    ON o.customer_id = c.id;


SELECT
    firstname,
    lastname,
    addressline,
    postalcode,
    city,
    addresstype
FROM customers INNER JOIN customeraddresses
    ON customers.id = customeraddresses.customer_id INNER JOIN addresses
    ON customeraddresses.address_id = addresses.id INNER JOIN addresstypes
    ON customeraddresses.addresstype_id = addresstypes.id;


SELECT
    suppliername,
    email,
    phone,
    addressline,
    postalcode,
    city
FROM suppliers INNER JOIN supplieraddresses
    ON suppliers.id = supplieraddresses.supplier_id INNER JOIN addresses
    ON supplieraddresses.address_id = addresses.id;

-- ALTER SEQUENCE customers_id_seq RESTART WITH 1