DROP TRIGGER IF EXISTS PizzaBox.CalculatePizzaPrice

GO
CREATE TRIGGER PizzaBox.CalculatePizzaPrice
	ON PizzaBox.Pizza
	AFTER INSERT, UPDATE
AS
	--DECLARE @toppings_price money = (SELECT SUM(t.price) totalprice FROM PizzaBox.Toppings t
	--						JOIN PizzaBox.PizzaToppingsMap m ON t.topping_id = m.topping_id
	--						JOIN PizzaBox.Pizza p ON p.pizza_id = m.pizza_id)
BEGIN
	UPDATE PizzaBox.Pizza
	SET price_total = (
		SELECT (cr.price + sc.price + ch.price) * sz.price_multiplier
	)
	FROM Crust cr, Sauce sc, Cheese ch, Size sz, inserted i INNER JOIN Pizza ON i.pizza_id = i.pizza_id
END
