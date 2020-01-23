DROP TABLE IF EXISTS PizzaBox.PizzaToppingsMap

CREATE TABLE PizzaBox.PizzaToppingsMap (
	pizza_id			int	NOT NULL FOREIGN KEY REFERENCES PizzaBox.Pizza (pizza_id),
	topping_id			int NOT NULL FOREIGN KEY REFERENCES PizzaBox.Toppings (topping_id),
	PRIMARY KEY(pizza_id, topping_id)
)

INSERT INTO PizzaBox.PizzaToppingsMap (pizza_id, topping_id)
VALUES (9, 8)
INSERT INTO PizzaBox.PizzaToppingsMap (pizza_id, topping_id)
VALUES (9, 7)

SELECT p.pizza_id, p.pizza_name,  t.topping_name FROM PizzaBox.Pizza p, PizzaBox.Toppings t, PizzaBox.PizzaToppingsMap pt 
WHERE p.pizza_id = pt.pizza_id AND pt.topping_id = t.topping_id

SELECT * FROM PizzaBox.Restaurants
INSERT INTO PizzaBox.RestaurantPizzasMap (restaurant_id, pizza_id)
VALUES (3, 9)

SELECT *
FROM PizzaBox.Restaurants r, PizzaBox.RestaurantPizzasMap rp, PizzaBox.Pizza p
WHERE r.restaurant_id = rp.restaurant_id AND rp.pizza_id = p.pizza_id AND r.restaurant_id = 3

SELECT SUM(t.price)
FROM PizzaBox.Pizza p, PizzaBox.PizzaToppingsMap pt, PizzaBox.Toppings t
WHERE p.pizza_id = pt.pizza_id AND pt.topping_id = t.topping_id AND p.pizza_id = 9

-- add pizza to restaurant --
SELECT * FROM PizzaBox.Restaurants
INSERT INTO PizzaBox.RestaurantPizzasMap (restaurant_id, pizza_id)
VALUES (3, 9)

SELECT * FROM PizzaBox.Pizza
SELECT * FROM PizzaBox.RestaurantPizzasMap
SELECT * FROM PizzaBox.Toppings
SELECT * FROM  PizzaBox.PizzaToppingsMap
--! add pizza to restaurant --