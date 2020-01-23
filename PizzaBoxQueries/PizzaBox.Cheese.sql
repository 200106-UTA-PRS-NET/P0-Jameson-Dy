DROP TABLE IF EXISTS PizzaBox.Cheese

CREATE TABLE PizzaBox.Cheese(
	cheese_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cheese_name	varchar(30)	NOT NULL UNIQUE,
	price		money NOT NULL
)


INSERT INTO PizzaBox.Cheese (cheese_name, price)
VALUES ('mozzarella', 2.00)

INSERT INTO PizzaBox.Cheese (cheese_name, price)
VALUES ('provolone', 2.40)

INSERT INTO PizzaBox.Cheese (cheese_name, price)
VALUES ('ricotta', 1.90)

INSERT INTO PizzaBox.Cheese (cheese_name, price)
VALUES ('blue', 1.80)

INSERT INTO PizzaBox.Cheese (cheese_name, price)
VALUES ('none', 0)

SELECT * FROM  PizzaBox.Cheese