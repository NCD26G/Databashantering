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
    ordernumber VARCHAR(15) NOT NULL UNIQUE,
    orderdate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    customer_id INTEGER NOT NULL REFERENCES customers(id)
    --CONSTRAINT fk_customers FOREIGN KEY(customer_id) REFERENCES customers(id) --ON DELETE CASCADE   
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
    price FLOAT NOT NULL,
    supplier_id INTEGER NOT NULL,
    CONSTRAINT fk_supplier FOREIGN KEY(supplier_id) REFERENCES suppliers(id)
);

CREATE TABLE orderitems(
    order_id INTEGER NOT NULL,
    product_id INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    price FLOAT NOT NULL,
    discount INTEGER NOT NULL DEFAULT 0,
    CONSTRAINT pk_orderitems PRIMARY KEY(order_id,product_id),
    CONSTRAINT fk_salesorder FOREIGN KEY(order_id) REFERENCES salesorders(id),
    CONSTRAINT fk_products FOREIGN KEY(product_id) REFERENCES products(id)
);

CREATE TABLE addresstypes(
    id SERIAL PRIMARY KEY,
    addresstype VARCHAR(40) NOT NULL UNIQUE
);

CREATE TABLE customeraddresses(
    customer_id INTEGER NOT NULL,
    address_id INTEGER NOT NULL,
    addresstype_id INTEGER NOT NULL,
    CONSTRAINT pk_custaddr PRIMARY KEY(customer_id,address_id,addresstype_id),
    CONSTRAINT fk_customer FOREIGN KEY(customer_id) REFERENCES customers(id),
    CONSTRAINT fk_address FOREIGN KEY(address_id) REFERENCES addresses(id),
    CONSTRAINT fk_addresstype FOREIGN KEY(addresstype_id) REFERENCES addresstypes(id)
);

CREATE TABLE supplieraddresses(
    supplier_id INTEGER NOT NULL,
    address_id INTEGER NOT NULL,
    addresstype_id INTEGER NOT NULL,
    CONSTRAINT pk_supplieraddr PRIMARY KEY(supplier_id,address_id,addresstype_id),
    CONSTRAINT fk_supplier FOREIGN KEY(supplier_id) REFERENCES suppliers(id),
    CONSTRAINT fk_address FOREIGN KEY(address_id) REFERENCES addresses(id),
    CONSTRAINT fk_addresstype FOREIGN KEY(addresstype_id) REFERENCES addresstypes(id)
);