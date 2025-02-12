Feature: Search for a hotel room

A simple set of scenarios for searching for a hotel room

Rule: The CheckIn date should be before the CheckOut date

@mytag
Scenario: User enters valid dates
	Given the hotel has the following hotel rooms:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 101    | Single | 1            | €140          |
	| 102    | Single | 1            | €140          |
	| 103    | Double | 2            | €180          |
	| 104    | Double | 3            | €180          |
	| 105    | Double | 3            | €180          |
	| 106    | Suite  | 4            | €250          |
	And a user wants to books a hotel room with a checkIn date of "17/05/2025" 
	And a checkOut date of "19/05/2025"
	And selects 2 adults
	And 1 child
	
	When the user searches for a hotel room
	Then the user should be informed that the available rooms are:
	| RoomNo | Type   | MaxOccupancy | PricePerNight |
	| 104    | Double | 3            | €180          |
	| 105    | Double | 3            | €180          |
	| 106    | Suite  | 4            | €250          |