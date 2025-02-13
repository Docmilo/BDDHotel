Feature: Check room availability

A simple set of scenarios for searching for a hotel room

# Features are software features that we want to create in code. 
# Feature files are our BDD executable specification.

Rule: The CheckIn date should be before the CheckOut date
# Rules represent business rules that should be implemented. 
# Rules group together sevreal scenarios that illustate the rule. 

@mytag
Scenario: User enters valid dates
# Example: User enters valid dates
# Screnarios / examples are concrete examples that illustrate the rule.
# Scenarios contain a list of steps

	# Given - describes the initial context of the system, like Arrange in TDD.
	Given the hotel has the following hotel rooms:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 101    | Single | 1            | €140          |
	| 102    | Single | 1            | €140          |
	| 103    | Double | 2            | €180          |
	| 104    | Double | 3            | €180          |
	| 105    | Double | 3            | €180          |
	| 106    | Suite  | 4            | €250          |
	# And can be used instead of writing successive Given's, When's or Then's
	And a user wants to books a hotel room with a checkIn date of "17/05/2025" 
	And a checkOut date of "19/05/2025"
	And selects 2 adults
	And 1 child
	
	# When - describes an event or action. Usually the person interaction with the system.
	# Consider it like Act in TDD.
	When the user searches for a hotel room

	# Then - describes the expected outcome. Consider it like Assert in TDD.
	Then the user should be informed that the available rooms are:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 104    | Double | 3            | €180          |
	| 105    | Double | 3            | €180          |
	| 106    | Suite  | 4            | €250          |
	
	But the user should not be offered the following rooms:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 101    | Single | 1            | €140          |
	| 102    | Single | 1            | €140          |
	| 103    | Double | 2            | €180          |