DROP TABLE IF EXISTS PizzaBox.Orders

CREATE TABLE PizzaBox.Orders (
	order_id		int PRIMARY KEY IDENTITY(1,1),
	customer_id		int	FOREIGN KEY REFERENCES PizzaBox.Customers (customer_id),
	restaurant_id	int FOREIGN KEY REFERENCES PizzaBox.Restaurants (restaurant_id),
	total_price		money,
	order_date		datetime DEFAULT getdate(),
)

SELECT * FROM PizzaBox.Restaurants

SELECT * FROM PizzaBox.Orders
WHERE customer_id = 2

SELECT * FROM PizzaBox.OrderPizzasMap

DELETE PizzaBox.OrderPizzasMap
WHERE order_id = 3

DELETE PizzaBox.Orders
WHERE order_id = 3


SELECT C.first_name, O.order_id, R.restaurant_name
FROM  PizzaBox.Orders O, PizzaBox.Customers C, PizzaBox.Restaurants R
WHERE C.customer_id = O.customer_id AND R.restaurant_id = O.restaurant_id