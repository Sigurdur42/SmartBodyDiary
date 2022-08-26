Feature: Tests the weight related public interface of SbdDomainService

# Background: SbdDomainService is initialized with in-memory repository

    Scenario: Add first daily weight
        Given SbdDomainService is initialized with in-memory repository
        When The daily weight '85.8' is added on '26.08.2022'
        Then There is only 1 weight record in the repository
        And The weight of '26.08.2022' is '85.8'

    Scenario: Add multiple weights
        Given SbdDomainService is initialized with in-memory repository
        When The daily weight '85.8' is added on '26.08.2022'
        Then There is only 1 weight record in the repository
        And The weight of '26.08.2022' is '85.8'
        And The daily weight '85.8' is added on '25.08.2022'
        Then The weight of '25.08.2022' is '85.8'
        And The daily weight '87.8' is added on '24.08.2022'
        Then The weight of '24.08.2022' is '87.8'
        Then There is only 3 weight record in the repository

    Scenario: Update existing weights
        Given SbdDomainService is initialized with in-memory repository
        When The daily weight '85.8' is added on '26.08.2022'
        And The daily weight '85.8' is added on '25.08.2022'
        And The daily weight '88.8' is added on '24.08.2022'
        And The daily weight '90.0' is updated on '26.08.2022'
        Then The weight of '26.08.2022' is '90.0'
        And There is only 3 weight record in the repository

    Scenario: Remove an existing weight
        Given SbdDomainService is initialized with in-memory repository        
        When These weight records already exist
          | Day        | Weight |
          | 25.08.2022 | 83.00  |
          | 26.08.2022 | 82.00  |
          | 27.08.2022 | 85.00  |
        And the weight for '26.08.2022' is removed
        And There is only 2 weight record in the repository
        
    Scenario: Remove an non existing weight
        Given SbdDomainService is initialized with in-memory repository        
        When These weight records already exist
          | Day        | Weight |
          | 25.08.2022 | 83.00  |
          | 26.08.2022 | 82.00  |
          | 27.08.2022 | 85.00  |
        And the weight for '01.08.2022' is removed
        And There is only 3 weight record in the repository
        