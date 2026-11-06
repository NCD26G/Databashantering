SELECT
    products.id,
    itemnumber,
    productname,
    price,
    suppliername
FROM products INNER JOIN suppliers
    ON products.supplier_id = suppliers.id