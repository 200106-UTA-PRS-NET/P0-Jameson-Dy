DROP TABLE IF EXISTS PizzaBox.Toppings

CREATE TABLE PizzaBox.Toppings (
	topping_id		int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	topping_name	varchar(30)	NOT NULL UNIQUE,
	price			money NOT NULL
)


INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('pepperoni', 2.50)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('sausage', 2.50)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('onions', 1.80)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('garlic', 1.70)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('bacon', 2.50)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('chicken', 2.50)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('extra cheese', 2.00)

INSERT INTO PizzaBox.Toppings (topping_name, price)
VALUES ('ice shavings', 1.00)

SELECT 
FROM PizzaBox

SELECT * FROM PizzaBox.Pizza WHERE pizza_id=9
SELECT * FROM PizzaBox.Crust
SELECT * FROM PizzaBox.Sauce
SELECT * FROM PizzaBox.Cheese
SELECT * FROM PizzaBox.Size

SELECT * FROM  PizzaBox.Toppings
SELECT * FROM PizzaBox.PizzaToppingsMap mp, PizzaBox.Toppings t
WHERE mp.topping_id = t.topping_id
SELECT * FROM PizzaBox.Restaurants