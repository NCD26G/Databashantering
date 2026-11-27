INSERT INTO customers(firstname,lastname,email)
VALUES
    ('Michael','Gustavsson','michael@mail.com'),
    ('Emma','Olsson','emma@mail.com');

INSERT INTO customers(firstname,lastname,email)
VALUES
    ('Bertil','Persson','bertil@mail.com'),
    ('Susanne','Eriksson','susanne@mail.com'),
    ('Nils','Westerberg','nils@mail.com');

SELECT * FROM customers;

INSERT INTO addresstypes(addresstype)
VALUES('Billing'),('Delivery'),('Office')

SELECT * FROM addresstypes;

INSERT INTO cities(city)VALUES('Stenungsund'),('Göteborg'),('Kungälv');

SELECT * FROM cities;

INSERT INTO postalcodes(postalcode,city_id)VALUES('44431',1),('44432',3),('44445',1);

SELECT * FROM postalcodes INNER JOIN cities
    ON postalcodes.city_id = cities.id;

INSERT INTO addresses(addressline,postalcode_id,addresstype_id)
    VALUES
        ('Strandvägen 1',1,2),
        ('Storgatan 10',1,2),
        ('Hjälmaregaten 14',3,2),
        ('Lasarettsvägen 1',3,2),
        ('Ytterbyvägen 10',2,2);

SELECT * FROM addresses INNER JOIN postalcodes
    ON addresses.postalcode_id = postalcodes.id INNER JOIN cities
    ON postalcodes.city_id = cities.id INNER JOIN addresstypes
    ON addresses.addresstype_id = addresstypes.id;

INSERT INTO customeraddresses(customer_id,address_id)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5)

