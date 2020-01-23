DROP TABLE IF EXISTS PizzaBox.Sauce

CREATE TABLE PizzaBox.Sauce (
	sauce_id	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	sauce_name	varchar(30)	NOT NULL UNIQUE,
	price		money NOT NULL
)


INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('tomato classic', 2.00)

INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('white garlic', 2.00)

INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('barbeque', 2.00)

INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('buffalo', 2.10)

INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('water', 1.00)

INSERT INTO PizzaBox.Sauce (sauce_name, price)
VALUES ('none', 0)

SELECT * FROM  PizzaBox.Sauce