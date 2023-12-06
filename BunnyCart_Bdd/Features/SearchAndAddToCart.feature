Feature: SearchAndAddToCart

A short summary of the feature

@Search_And_Add_To_Cart(Order=1)
Scenario: 01 Search for products
	Given User will be on the Homepage
	When User will types the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'
	* The heading should have '<searchtext>'
	* Title should have '<searchtext>'	
	When User select a '<productNo>'
	Then Product page is loaded
Examples: 
	| searchtext | productNo |
	| water      | 1         |
	| java       | 2         |

#@Search_And_Add_To_Cart(Order=2)
#Scenario Outline:	02 Select a particular product
	#When User select a '<productNo>'
	#Then Product page is loaded
#Examples: 
	##| productNo |
	#| 1         |


