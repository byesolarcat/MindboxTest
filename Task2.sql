SELECT p.Name, c.Name
FROM Products AS p
LEFT JOIN Categories AS c
	ON p.CategoryId = c.Id;