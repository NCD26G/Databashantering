INSERT INTO customers(
    firstname,
    lastname,
    email,
    phone
)VALUES(
    'Michael',
    'Gustavsson',
    'michael@mail.com',
    '070-1111111'
),(
    'Evert',
    'Ljusberg',
    'evert@mail.com',
    '070-2222222'
),(
    'Helena',
    'Pettersson',
    'helena@mail.com',
    NULL
);

INSERT INTO salesorders(
    ordernumber,
    customer_id
)VALUES(
    'A100-10',
    1
),(
    'A100-11',
    1
),(
    'A100-12',
    1
),(
    'A100-13',
    3
);

INSERT INTO suppliers(
    suppliername,
    email,
    phone
)VALUES(
    'Asics',
    'asics@mail.com',
    '010-3333333'
),
(
    'Nike',
    'nike@mail.com',
    '010-4444444'
),
(
    'CLN Athletics',
    'cln@mail.com',
    '010-6565656'
);

INSERT INTO products(
    itemnumber,
    productname,
    price,
    supplier_id
)VALUES(
    '1000',
    'Gel 27',
    1995,
    1
),(
    '1001',
    'Shorts 2-in-1',
    995,
    3
),(
    '1002',
    'Cumulus 25',
    1595,
    2
);

INSERT INTO orderitems(
   order_id,
   product_id,
   quantity,
   price 
)VALUES(
    1,
    1,
    1,
    1495
),(
    1,
    2,
    2,
    895
)

INSERT INTO orderitems(
   order_id,
   product_id,
   quantity,
   price 
)VALUES(
    4,
    3,
    1,
    1195
)

INSERT INTO addresstypes(
    addresstype
)VALUES(
    'Billing'
),(
    'Shipping'
),(
    'Office'
)

INSERT INTO cities(
    city
)VALUES(
    'Byn'
),(
    'Staden'
),(
    'Samhället'
)

INSERT INTO postalcodes(
    postalcode,
    city_id
)VALUES(
    '12345',
    1
),(
    '22233',
    2
),(
    '33344',
    3
)

INSERT INTO addresses(
    addressline,
    postalcode_id
)VALUES(
    'Byvägen 1',
    1
),(
    'Strandvägen 11',
    2
),(
    'Bergshöjden 111A',
    3
)

INSERT INTO customeraddresses(
    customer_id,
    address_id,
    addresstype_id
)VALUES(
    1,
    1,
    1
),(
    1,
    2,
    2
),(
    2,
    3,
    1
),(
    2,
    3,
    2
)

INSERT INTO addresses(
    addressline,
    postalcode,
    city
)VALUES(
    'Munkerödsvägen 15',
    '44432',
    'Stenungsund'
);

INSERT INTO supplieraddresses(
    supplier_id,
    address_id,
    addresstype_id
)VALUES(
    1,
    4,
    3
)