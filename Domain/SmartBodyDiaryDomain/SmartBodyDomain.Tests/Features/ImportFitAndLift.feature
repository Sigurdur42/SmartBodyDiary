Feature: Import Fit&Lift data

    Scenario: Import actual data from myself
        Given The file 'FitAndLift.2022-09-29.yaml' is imported from FitAndLift
        Then Loading the import data was successful
        Then This diary data is found
          | Day        | Weight | GymSession | NeatGoal | KcalGoal | MacroGoal | SleepGoal | ProteinGoal | Comment |
          | 22.06.2022 |        |            | Reached  |          |           | Reached   |             |         |
          | 23.05.2022 | 81.95  |            |          |          |           |           |             |         |
          | 22.05.2022 | 82.15  | Progress   | Reached  |          |           |           |             |         |
          | 21.03.2022 | 77.65  |            | Reached  | Missed   | Reached   | Reached   | Reached     |         |
          | 19.03.2022 | 78.05  |            | Reached  | Reached  | Reached   | Reached   | Reached     |         |