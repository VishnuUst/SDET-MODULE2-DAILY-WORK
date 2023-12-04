Feature: Search

@Product_Search
Scenario Outline: Search for products
	Given User will be on the Homepage
	When User will types the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext |
	| water      |
	| java       |
	| hairgrass  |
