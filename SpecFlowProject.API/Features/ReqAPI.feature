Feature: ReqAPI
	

@mytag
Scenario: Create user
	Given user data: <name> and <job>
	And post request
	When post user
	Then I get correct response code


Scenario: Get single user info
	Given user <id>
	And get request
	When I execute get request
	Then I get correct data <email> <first_name> <last_name>
	Examples: 
	| id | email                  | first_name | last_name |
	| 2  | janet.weaver@reqres.in | Janet      | Weaver    |
       