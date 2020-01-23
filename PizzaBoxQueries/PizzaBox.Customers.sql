DROP TABLE IF EXISTS PizzaBox.Customers

CREATE TABLE PizzaBox.Customers (
	customer_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	first_name	varchar(50) NOT NULL,
	last_name	varchar(50) NOT NULL,
	username	varchar(20)	NOT NULL UNIQUE CHECK (LEN(username) > 7),
	password	varchar(20)	NOT NULL CHECK (LEN(password) > 7),
)

DELETE FROM PizzaBox.Customers

INSERT INTO PizzaBox.Customers (first_name, last_name, username, password)
VALUES ('jameson', 'dy', 'dyjameson' ,'password')

SELECT * FROM PizzaBox.Customers