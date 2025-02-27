Feature: SM001_3

A short summary of the feature

@tag1
Scenario: Access a simulation so that it can be completed correctly and finished
	Given Enter the system.
	When Enter the email credentials "testcase@gmail.com" and the password "testcase" admin account.
	And Click on the Login button.
	And Select the button to end a simulation.
	And Click on the finish simulation button.
	Then It should show a confirmation message.
