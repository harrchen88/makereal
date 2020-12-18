Feature: guestsearchbyname

Scenario: Search based on the first name
	Given a search bar is at the bookings app home page
	When the user enters "jus" as the first name into the search bar
	Then guest names starting with "jus" are shown on the home page