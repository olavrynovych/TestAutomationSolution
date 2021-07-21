Feature: Login
	

@Login
Scenario: Login scenario
	Given website
	And login and password <username> <pass>
	When login with params
	Then login is successfull url is ccorrect <url>
	Examples: 
		| username                | pass         | url                                      |
		| standard_user           | secret_sauce | https://www.saucedemo.com/inventory.html |
		| locked_out_user         | secret_sauce | https://www.saucedemo.com/ |
		| problem_user            | secret_sauce | https://www.saucedemo.com/inventory.html |
		| performance_glitch_user | secret_sauce | https://www.saucedemo.com/inventory.html |
