Feature: SbdJsonPersistence - Verify JSON persistence functionality

    Scenario: JSON can be written and read again
        Given The DiaryWeight JSON persistence is create
        When These DiaryWeight records shall be used
          | Day        | Weight |
          | 25.08.2022 | 83.00  |
          | 26.08.2022 | 82.00  |
          | 27.08.2022 | 85.00  |
        And These GymSession records shall be used
          | Day        | Progress |
          | 25.08.2022 | Normal   |
          | 26.08.2022 | Progress |
          | 27.08.2022 | Deload   |
        And The data is written to JSON
        And The data is read from JSON
        Then The previous existing weight records shall be read
        Then The previous existing gym session records shall be read