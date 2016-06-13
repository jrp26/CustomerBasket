Feature: Basket
	So that Customers know how much a basket of items is going to cost
	I want to be able to test the basket is totally accurrately

Scenario: Add three items each with a quantity of 1 to the basket and total
	Given the basket has 1 bread, 1 butter and 1 milk
	When I total the basket
	Then the total should be £2.95
	
Scenario: Add two items, each with a quantity of 2 and total
	Given the basket has 2 butter and 2 bread
	When I total the basket
	Then the total should be £3.10

Scenario: Add one item with a quntity of 4 and total
	Given the basket has 4 milk
	When I total the basket
	Then the total should be £3.45

Scenario: Add a mix of items with a mix of quantities
	Given the basket has 2 butter, 1 bread and 8 milk
	When I total the basket
	Then the total should be £9.00
