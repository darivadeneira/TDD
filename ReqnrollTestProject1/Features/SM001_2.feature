Feature: SM001_2

A short summary of the feature

@tag1
Scenario: Run a simulation to test the entry of votes
	Given Enter the system
	When Enter the email credentials "testcase@gmail.com" and the password "testcase" admin account
	And Click on the Login button
	And Select a created simulation
	And Click on the load simulation button
	Then It should show a confirmation message
