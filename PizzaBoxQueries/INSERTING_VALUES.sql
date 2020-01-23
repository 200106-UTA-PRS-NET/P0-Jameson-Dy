-- add pizza --
INSERT INTO PizzaBox.Pizza (crust_id, sauce_id, cheese_id, size_id, pizza_name)
VALUES (3, 6, 5, 2, 'Ice is Nice')

SELECT * FROM PizzaBox.Pizza
SELECT * FROM PizzaBox.Crust
SELECT * FROM PizzaBox.Sauce
SELECT * FROM PizzaBox.Cheese
SELECT * FROM PizzaBox.Size
--! add pizza --

-- add toppings to pizza --
INSERT INTO PizzaBox.PizzaToppingsMap (pizza_id, topping_id)
VALUES (13, 8)

SELECT * FROM PizzaBox.Pizza
SELECT * FROM PizzaBox.Toppings
SELECT * FROM PizzaBox.PizzaToppingsMap
SELECT p.pizza_name, t.topping_name
FROM PizzaBox.Pizza p, PizzaBox.Toppings t, PizzaBox.PizzaToppingsMap pt
WHERE p.pizza_id=pt.pizza_id AND t.topping_id=pt.topping_id
--! add toppings to pizza --


-- add pizza to restaurant --
SELECT * FROM PizzaBox.Restaurants
INSERT INTO PizzaBox.RestaurantPizzasMap (restaurant_id, pizza_id)
VALUES (3, 13)

SELECT * FROM PizzaBox.Restaurants
SELECT * FROM PizzaBox.Pizza
SELECT * FROM PizzaBox.RestaurantPizzasMap
SELECT r.restaurant_name, p.pizza_name
FROM PizzaBox.Pizza p, PizzaBox.Restaurants r, PizzaBox.RestaurantPizzasMap rp
WHERE p.pizza_id=rp.pizza_id AND r.restaurant_id=rp.restaurant_id
--! add pizza to restaurant --

-- calculate pizza toppings price (ignore) -
SELECT SUM(t.price)
FROM PizzaBox.Pizza p, PizzaBox.PizzaToppingsMap pt, PizzaBox.Toppings t
WHERE p.pizza_id = pt.pizza_id AND pt.topping_id = t.topping_id AND p.pizza_id = 9

SELECT ch.price + cr.price + sc.price
FROM PizzaBox.Pizza p, PizzaBox.Cheese ch, PizzaBox.Crust cr, PizzaBox.Sauce sc, PizzaBox.Size sz
WHERE p.cheese_id = ch.cheese_id AND p.crust_id = cr.crust_id AND p.sauce_id = sc.sauce_id AND p.size_id = sz.size_id AND p.pizza_id = 9

SELECT sz.price_multiplier
FROM PizzaBox.Pizza p, PizzaBox.Size sz
WHERE p.size_id = sz.size_id AND p.pizza_id = 9
--! calculate pizza toppings price -

-- add customer & restaurant to order --
INSERT INTO PizzaBox.Orders (customer_id, restaurant_id)
VALUES (2, 7)

SELECT * FROM PizzaBox.Customers
SELECT * FROM PizzaBox.Restaurants
SELECT c.username, r.restaurant_name FROM PizzaBox.Orders o, PizzaBox.Customers c, PizzaBox.Restaurants r
WHERE c.customer_id=o.customer_id AND r.restaurant_id=o.restaurant_id

--! add customer & restaurant to order --
-- add pizza to order --
INSERT INTO PizzaBox.OrderPizzasMap (order_id, pizza_id)
VALUES (3, 10)

SELECT * FROM PizzaBox.Pizza 
SELECT * FROM PizzaBox.Orders
SELECT o.order_id, c.username, r.restaurant_name FROM PizzaBox.Orders o, PizzaBox.Customers c, PizzaBox.Restaurants r
WHERE c.customer_id=o.customer_id AND r.restaurant_id=o.restaurant_id
SELECT * FROM PizzaBox.OrderPizzasMap
--! add pizza to order --

SELECT * FROM PizzaBox.Orders