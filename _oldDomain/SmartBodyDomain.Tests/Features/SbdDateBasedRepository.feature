Feature: SdbDateBasedRepository - Verifies the functionality

Background:
	Given The date based repository has been created for repo testing

Scenario: Add a value to an empty repository
	When the value '42' is added on '01.05.2012'
	Then the repository must have '1' record
	And the value of '01.05.2012' must be '42'

Scenario: Add a value to filled repository
	When These repository records already exist
		| Day        | Weight |
		| 2020-08-25 | 87.5   |
		| 2020-08-26 | 87.9   |
		| 2020-08-27 | 87.7   |
		| 2020-08-28 | 87.6   |
		| 2020-08-29 | 87.2   |
		| 2020-08-30 | 87.4   |
		| 2020-08-31 | 87.5   |
		| 2020-09-01 | 88.7   |
		| 2020-09-02 | 87.7   |
		| 2020-09-03 | 87.2   |
		| 2020-09-04 | 87.0   |
		| 2020-09-05 | 86.4   |
		| 2020-09-06 | 86.3   |
		| 2020-09-07 | 86.9   |
		| 2020-09-08 | 86.6   |
		| 2020-09-09 | 86.5   |
		| 2020-09-10 | 86.6   |
		| 2020-09-11 | 87.1   |
		| 2020-09-12 | 86.6   |
		| 2020-09-13 | 86.8   |
		| 2020-09-14 | 88.0   |
		| 2020-09-15 | 86.4   |
		| 2020-09-16 | 86.0   |
		| 2020-09-17 | 86.4   |
		| 2020-09-18 | 85.9   |
	Then the repository must have '25' record
	And the value of '18.09.2020' must be '85.9'
	And the value '42' is added on '01.05.2012'
	Then the repository must have '26' record
	And the value of '01.05.2012' must be '42'

Scenario: Update a value to filled repository
	When These repository records already exist
		| Day        | Weight |
		| 2020-09-17 | 86.4   |
		| 2020-09-18 | 85.9   |
	Then the repository must have '2' record
	And the value of '18.09.2020' must be '85.9'
	And the value '42' is added on '17.09.2020'
	Then the repository must have '2' record
	And the value of '17.09.2020' must be '42'
        
Scenario: Remove an existing value to filled repository
	When These repository records already exist
		| Day        | Weight |
		| 2020-09-17 | 86.4   |
		| 2020-09-18 | 85.9   |
	Then the repository must have '2' record
	And the value of '18.09.2020' must be '85.9'
	And the value on '17.09.2020' is removed
	Then the repository must have '1' record
	And the value of '17.09.2020' must not exist

Scenario: Remove a non existing value to filled repository
	When These repository records already exist
		| Day        | Weight |
		| 2020-09-17 | 86.4   |
		| 2020-09-18 | 85.9   |
	Then the repository must have '2' record
	And the value of '18.09.2020' must be '85.9'
	And the value on '01.09.2020' is removed
	Then the repository must have '2' record
        
Scenario: GetAllData returns filled collection
	When These repository records already exist
		| Day        | Weight |
		| 2020-09-17 | 86.4   |
		| 2020-09-18 | 85.9   |
	Then GetAllData returns '2' records
        
Scenario: GetAllData on empty collection returns empty collection
	Then GetAllData returns '0' records
