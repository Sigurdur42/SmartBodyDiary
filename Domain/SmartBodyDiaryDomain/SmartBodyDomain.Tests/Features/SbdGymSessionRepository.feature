Feature: SbdGymSessionRepository - Verifies gym session repo functionality

Background:
	Given An empty gym session repository is initialized
	
Scenario: Adding gym session
	Given A gym session is added at '01.10.2022' with status 'Progress'
	Then Exactly '1' gym session(s) is in the repository
	And The gym status on '01.10.2022' is 'Progress'
	
Scenario: Updating gym session
	Given A gym session is added at '02.10.2022' with status 'Progress'
	Then Exactly '1' gym session(s) is in the repository
	And A gym session is added at '02.10.2022' with status 'Normal'
	Then The gym status on '02.10.2022' is 'Normal'