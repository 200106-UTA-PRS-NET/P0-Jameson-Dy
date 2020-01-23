DROP TABLE IF EXISTS PizzaBox.Size

CREATE TABLE PizzaBox.Size (
	size_id			int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	size			varchar(30)	NOT NULL UNIQUE,
	price_multiplier float
)

EXEC sp_rename 'PizzaBox.Size.size', 'size_name' 


INSERT INTO PizzaBox.Size (size, price_multiplier)
VALUES ('personal', 0.8)

INSERT INTO PizzaBox.Size (size, price_multiplier)
VALUES ('medium', 1.0)

INSERT INTO PizzaBox.Size (size, price_multiplier)
VALUES ('large', 1.50)

INSERT INTO PizzaBox.Size (size, price_multiplier)
VALUES ('xtra large', 2.10)

SELECT * FROM  PizzaBox.Size