Feature: Specify dates

A simple set of scenarios for searching for a hotel room

# Features are software features that we want to create in code. 
# Feature files are our BDD executable specification.

Rule: The CheckIn date should be before the CheckOut date
# Rules represent business rules that should be implemented. 
# Rules group together sevreal scenarios that illustate the rule. 

@mytag
Scenario: User enters a checkout date that is before a valid checkin date
# Example: User enters valid dates
# Screnarios / examples are concrete examples that illustrate the rule.
# Scenarios contain a list of steps

	# Given - describes the initial context of the system, like Arrange in TDD.
	Given the user is on the hotel booking page

	# When - describes an event or action. Usually the person interaction with the system.
	# Consider it like Act in TDD.
	When the user specifies a checkIn date of "17/05/2025"
	And the user specifies a checkOut date of "16/05/2025"
	And the user submits the search request

	# And can be used instead of writing successive Given's, When's or Then's

	# Then - describes the expected outcome. Consider it like Assert in TDD.
	Then generate the error message "Check-out date must be after check-in date."
	And disable the search
	

@mytag
Scenario: User enters a checkout date that is after a valid checkin date
	Given the user is on the hotel booking page
	When the user specifies a checkIn date of "17/05/2025"
	And the user specifies a checkOut date of "18/05/2025"
	And the user submits the search request
	Then enable the search