Feature: ReqAPI resource, free website to test API
	

@CreateUser
Scenario: Create user
	Given user data: <name> and <job>
	And post request
	When post user
	Then I get correct response code <code>
	Examples: 
	| code |
	| 201  |
	
@GetUser
Scenario: Get single user info
	Given user <id>
	And get request
	When I execute get request
	Then I get correct data <email> <first_name> <last_name>
	Examples: 
	| id | email                  | first_name | last_name |
	| 2  | janet.weaver@reqres.in | Janet      | Weaver    |
 
 @DeleteUser
 Scenario: Delete single user
	Given user <id>
	And get delete request
	When I execute delete request
	Then I get correct response code <code>
	Examples: 
	| id | code |
	| 2  | 204  |