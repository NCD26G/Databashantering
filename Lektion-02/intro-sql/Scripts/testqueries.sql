SELECT
    *
FROM customers INNER JOIN salesorders
    ON customers.id = salesorders.customer_id;

DELETE FROM salesorders WHERE id = 1;
DELETE FROM customers WHERE id = 1;

SELECT * FROM salesorders;
SELECT * FROM customers;