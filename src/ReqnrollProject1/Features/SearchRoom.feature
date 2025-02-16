Feature: Check room availability

A simple set of scenarios for searching for an available hotel room on specified dates

# Features are software features that we want to create in code. 
# Feature files are our BDD executable specification.

Rule: Only rooms that are available on the selected dates should be offered to guests
# Rules represent business rules that should be implemented. 
# Rules group together sevreal scenarios that illustate the rule. 

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
	And the following bookings already exist:
	| RoomNo | GuestNo  | CheckInDate	| CheckOutDate |
	| 101    | 2001		| 17/05/2025	| 20/05/2025 |
	| 103    | 2023		| 14/05/2025	| 20/05/2025 |
	
	And the user specifies a checkIn date of "17/05/2025"
	And the user specifies a checkOut date of "18/05/2025"
	
	# When - describes an event or action. Usually the person interaction with the system.
	# Consider it like Act in TDD.
	When the user submits the search request

	# Then - describes the expected outcome. Consider it like Assert in TDD.
	Then the user should be informed that the available rooms are:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 102    | Single | 1            | €140          |
	| 104    | Double | 3            | €180          |
	| 105    | Double | 3            | €180          |
	| 106    | Suite  | 4            | €250          |
	
	But the user should not be offered the following rooms:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 101    | Single | 1            | €140          |
	| 103    | Double | 2            | €180          |