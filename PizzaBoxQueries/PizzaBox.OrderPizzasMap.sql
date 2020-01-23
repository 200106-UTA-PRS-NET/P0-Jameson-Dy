DROP TABLE IF EXISTS PizzaBox.OrderPizzasMap

CREATE TABLE PizzaBox.OrderPizzasMap (
	order_id	int	 FOREIGN KEY REFERENCES PizzaBox.Orders (order_id),
	pizza_id	int  FOREIGN KEY REFERENCES PizzaBox.Pizza (pizza_id),
	PRIMARY KEY(order_id, pizza_id)
)

ALTER TABLE PizzaBox.OrderPizzasMap
ADD quantity int DEFAULT 1

SELECT * FROM  PizzaBox.OrderPizzasMap