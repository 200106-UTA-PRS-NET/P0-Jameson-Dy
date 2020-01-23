DROP TABLE IF EXISTS PizzaBox.Pizza

CREATE TABLE PizzaBox.Pizza (
	pizza_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	crust_id	int NOT NULL CONSTRAINT FK_Pizza_Crust FOREIGN KEY (crust_id) REFERENCES PizzaBox.Crust (crust_id),
	sauce_id	int NOT NULL CONSTRAINT FK_Pizza_Sauce FOREIGN KEY (sauce_id) REFERENCES PizzaBox.Sauce (sauce_id),
	cheese_id	int NOT NULL CONSTRAINT FK_Pizza_Cheese FOREIGN KEY (cheese_id) REFERENCES PizzaBox.Cheese (cheese_id),
	size_id		int NOT NULL CONSTRAINT FK_Pizza_Size FOREIGN KEY (size_id) REFERENCES PizzaBox.Size (size_id),
	price_total	money DEFAULT 0
)

UPDATE PizzaBox.Pizza
SET size_id = 2
WHERE pizza_id = 9

SELECT * FROM PizzaBox.Pizza


DELETE FROM PizzaBox.Pizza WHERE pizza_id > 0

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id)
VALUES (1, 1, 1 ,1)

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id)
VALUES (1, 5, 3, 3)

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id)
VALUES (2,4, 2 ,2)

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id)
VALUES (2,3, 2 ,3)

SELECT p.pizza_id, ch.price cheeseP, cr.price crustP, sc.price sauceP, sz.price_multiplier sizeP, p.price_total
FROM  PizzaBox.Pizza p, PizzaBox.Cheese ch, PizzaBox.Crust cr, PizzaBox.Sauce sc, PizzaBox.Size sz
WHERE p.cheese_id = ch.cheese_id AND p.crust_id = cr.crust_id AND p.sauce_id = sc.sauce_id AND p.size_id = sz.size_id

SELECT p.pizza_id, ch.cheese_name cheeseP, cr.crust_name, sc.sauce_name, sz.size, p.price_total
FROM  PizzaBox.Pizza p, PizzaBox.Cheese ch, PizzaBox.Crust cr, PizzaBox.Sauce sc, PizzaBox.Size sz
WHERE p.cheese_id = ch.cheese_id AND p.crust_id = cr.crust_id AND p.sauce_id = sc.sauce_id AND p.size_id = sz.size_id

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id, pizza_name)
VALUES (5, 5, 4, 4, 'The Blessed Abomination')

INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id, pizza_name)
VALUES (2, 1, 1, 2, 'Classic Pepperoni')



SELECT * FROM PizzaBox.Crust
SELECT * FROM PizzaBox.Sauce
SELECT * FROM PizzaBox.Cheese
SELECT * FROM PizzaBox.Size

SELECT * FROM PizzaBox.Pizza