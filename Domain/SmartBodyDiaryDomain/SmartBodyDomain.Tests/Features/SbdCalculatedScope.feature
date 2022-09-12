Feature: SbdCalculatedScope - Verifies all kinds of scope calculations

    Background:
        Given The average sliding calculator is used
        Given These weight records are available
          | Day        | Weight |
          | 2020-08-18 | 82.5   |
          | 2020-08-25 | 87.7   |
        And The given data is set in the repository
        And The sliding weight has been calculated 

    Scenario: Calculate weekly scope when all data is present
        Given The scope shall be calculated from '18.08.2020' to '25.08.2020'
        Then The weight diff shall be '5.2' kg        

    Scenario: Calculate weekly scope when no data is present
        Given The scope shall be calculated from '18.08.2018' to '25.08.2018'
        Then The weight diff shall be '0' kg

    Scenario: Calculate weekly scope when a single data point is present
        Given The scope shall be calculated from '18.08.2018' to '18.08.2020'
        Then The weight diff shall be '0' kg