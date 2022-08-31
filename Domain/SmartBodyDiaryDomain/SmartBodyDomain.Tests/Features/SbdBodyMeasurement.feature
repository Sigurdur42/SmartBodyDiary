Feature: SbdBodyMeasurementRepository - Verifies body measurement functionality

    Background:
        Given An empty body measurement repository has been initialized

    Scenario: Add body data to repository
        Given This data has been measured at '01.01.2021'
          | Area        | Length |
          | LeftArm     | 33.00  |
          | RightArm    | 33.00  |
          | LeftLeg     | 33.00  |
          | RightLeg    | 33.00  |
          | Shoulder    | 33.00  |
          | Chest       | 33.00  |
          | Belly       | 33.00  |
          | BellyPlus5  | 33.00  |
          | BellyMinus5 | 33.00  |
          | Hip         | 33.00  |          

        And the measure data is added to the repository
        Then Exactly '1' body data record is in the repository