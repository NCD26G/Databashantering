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
    'A100-11',
    1
);

UPDATE salesorders SET customer_id = 3 WHERE id = 1;

INSERT INTO salesorders(
    ordernumber,
    customer_id
)VALUES(
    'A100-10',
    1
),(
    'A100-11',
    3
),(
    'A100-12',
    1
)