DROP TABLE IF EXISTS PizzaBox.RestaurantPizzasMap

CREATE TABLE PizzaBox.RestaurantPizzasMap (
	restaurant_id	int	NOT NULL FOREIGN KEY REFERENCES PizzaBox.Restaurants (restaurant_id),
	pizza_id		int NOT NULL FOREIGN KEY REFERENCES PizzaBox.Pizza (pizza_id),
	PRIMARY KEY(restaurant_id, pizza_id)
)


SELECT * FROM PizzaBox.RestaurantPizzasMap