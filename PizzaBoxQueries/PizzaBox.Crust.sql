DROP TABLE IF EXISTS PizzaBox.Crust

CREATE TABLE PizzaBox.Crust (
	crust_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	crust_name	varchar(30)	NOT NULL UNIQUE,
	price		money NOT NULL
)


INSERT INTO PizzaBox.Crust (crust_name, price)
VALUES ('hand tossed', 0.70)

INSERT INTO PizzaBox.Crust (crust_name, price)
VALUES ('original', 0.90)

INSERT INTO PizzaBox.Crust (crust_name, price)
VALUES ('thin', 0.70)

INSERT INTO PizzaBox.Crust (crust_name, price)
VALUES ('stuffed', 1.20)

INSERT INTO PizzaBox.Crust (crust_name, price)
VALUES ('cardboard', 0.20)

SELECT * FROM  PizzaBox.Crust
SELECT * FROM PizzaBox.Pizza

SELECT * FROM PizzaBox.Crust cr, PizzaBox.Pizza p
WHERE p.crust_id = cr.crust_id AND p.pizza_id = 9