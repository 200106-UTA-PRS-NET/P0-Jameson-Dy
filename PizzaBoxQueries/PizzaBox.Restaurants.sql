DROP TABLE IF EXISTS PizzaBox.Restaurants

CREATE TABLE PizzaBox.Restaurants (
	restaurant_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	restaurant_name	varchar(50) NOT NULL UNIQUE,
	restaurant_markup	money DEFAULT 0,
)

UPDATE PizzaBox.Restaurants
SET restaurant_name = 'Burger Joint'
WHERE restaurant_name = 'burger joint'


INSERT INTO PizzaBox.Restaurants (restaurant_name, restaurant_markup)
VALUES ('mama johns', 1.0)

INSERT INTO PizzaBox.Restaurants (restaurant_name, restaurant_markup)
VALUES ('no sauce', 2.50)

INSERT INTO PizzaBox.Restaurants (restaurant_name, restaurant_markup)
VALUES ('fred''s palace', 3.0)

INSERT INTO PizzaBox.Restaurants (restaurant_name, restaurant_markup)
VALUES ('burger joint', 1.50)

SELECT * FROM PizzaBox.Restaurants
SELECT * FROM PizzaBox.RestaurantPizzasMap
SELECT * FROM PizzaBox.Pizza