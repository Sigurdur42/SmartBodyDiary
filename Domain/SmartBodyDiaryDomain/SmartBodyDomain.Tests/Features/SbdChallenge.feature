Feature: SbdChallenge - Verify the challenge related functionality

    Background:
        Given An empty challenge repository has been initialized

    Scenario: Add a challenge record to the repository
        Given This challenge data is to be used on '01.01.2022'
          | Property | value          |
          | Title    | Test Challenge |

        And the current challenge is added to the repository
        Then Then Exactly '1' body data record is in the repository
        
        
    Scenario: IsActive is dynamically calculated
        Given This challenge data is to be used on '01.01.2022'
          | Property | value      |
          | Start    | 01.01.2022 |
          | End    | 31.03.2022 |
        
        Then IsActive shall be 'true' on '01.01.2022'
        And IsActive shall be 'true' on '31.03.2022'
        And IsActive shall be 'true' on '01.02.2022'
        
        And IsActive shall be 'false' on '01.04.2022'
        And IsActive shall be 'false' on '31.12.2021'