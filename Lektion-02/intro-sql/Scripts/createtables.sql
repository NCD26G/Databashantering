-- Active: 1793866568593@@ep-raspy-wind-za96p6xr-pooler.c-2.eu-west-2.aws.neon.tech@5432@runstoredb
CREATE TABLE customers(
    id SERIAL PRIMARY KEY,
    firstname VARCHAR(20) NOT NULL,
    lastname VARCHAR(40) NOT NULL,
    email VARCHAR(128) NOT NULL UNIQUE,
    phone VARCHAR(15) NULL
);

CREATE TABLE addresses(
    id SERIAL PRIMARY KEY,
    addressline VARCHAR(60),
    postalcode CHAR(5),
    city VARCHAR(40)
);

CREATE TABLE salesorders(
    id SERIAL PRIMARY KEY,
    ordernumber VARCHAR(15) NOT NULL,
    orderdate TIMESTAMP
);

CREATE TABLE suppliers(
    id SERIAL PRIMARY KEY,
    suppliername VARCHAR(80) NOT NULL UNIQUE,
    email VARCHAR(128) NOT NULL,
    phone VARCHAR(15) NOT NULL
);

CREATE TABLE products(
    id SERIAL PRIMARY KEY,
    itemnumber VARCHAR(15) NOT NULL UNIQUE,
    productname VARCHAR(80) NOT NULL,
    description VARCHAR(2048) NULL,
    imageurl VARCHAR(128) NULL,
    price FLOAT NOT NULL
);
