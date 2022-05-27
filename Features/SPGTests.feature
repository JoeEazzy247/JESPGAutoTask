Feature: SPGTests

@mytag
Scenario: SPG Test 1
#Test to ensure that when i click Run button i can see Hello World in the output window
	Given I am on .NET Fiddle page
	When I click Run button
	Then output window has value 'Hello World'


Scenario Outline: SPG Test 2
#Test to ensure that if name starts with A,B,C,D,E i am able to search for NUnit and add package 3.12.0 and validate the version
#Test that if name does not start with the mentiond letters throw an exception which should not stop the test rather get printed in console
	Given I am on .NET Fiddle page
	When I search for 'NUnit' if <Names>,<version> start with letter 'A,B,C,D,E' 
	Then Selected package is '<package>'
	Examples: 
	| Names  | package | version |
	| Absa   | NUnit   | 3.12.0  |
	| Ekeleme| NUnit   | 3.12.0  |
	#| Joseph |         |         |
	

Scenario Outline: SPG Test 3
#Test to ensure that if name starts with F,G,H,I,J,K i am able to search for NUnit and add package 3.12.0 and validate the version
#Test that if name does not start with the mentiond letters throw an exception which should not stop the test rather get printed in console
	Given I am on .NET Fiddle page
	And  I click 'Share' if <Names> start with letter 'F,G,H,I,J,K' 
	Then i verify that link starts with 'https://dotnetfiddle.net/'
	Examples: 
	| Names  |
	| George |
	| Joseph |
	| King   |
	#|        |


Scenario Outline: SPG Test 4
#Test to ensure that if name starts with L,M,N,O,P i am able to click the collaps icon
#Test that if name does not start with the mentiond letters throw an exception which should not stop the test rather get printed in console
	Given I am on .NET Fiddle page
	And  I click '>' if <Names> start with letter 'L,M,N,O,P' 
	Then I verify Options panel is hidden
	Examples: 
	| Names  |
	| Lanre  |
	| Mathew |
	| Nina   |


Scenario Outline: SPG Test 5
#Test to ensure that if name starts with L,M,N,O,P i am able to click the collaps icon
#Test that if name does not start with the mentiond letters throw an exception which should not stop the test rather get printed in console
	Given I am on .NET Fiddle page
	And  I click 'Save' if <Names> start with letter 'Q,R,S,T,U' 
	Then i verify that 'login' window appeared
	Examples: 
	| Names  |
	| Queen  |
	| Sarah  |
	| Tina   |


Scenario Outline: SPG Test 6
#Test to ensure that if name starts with V,W,X,Y,Z i am able to click Getting Started button and verify Back To Editor button is displayed
#Test that if name does not start with the mentiond letters throw an exception which should not stop the test rather get printed in console
	Given I am on .NET Fiddle page
	And  I click 'Getting Started' if <Names> start with letter 'V,W,X,Y,Z' 
	Then i verify that 'Back To Editor' window appeared
	Examples: 
	| Names  |
	| Vicky  |
	| Wisdom |
	| Zina   |