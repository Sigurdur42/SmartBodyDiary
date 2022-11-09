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
        Then This challenge data is found
          | Day        | Title                  | Start      | End        | Comment |
          | 29.08.2021 | 90 Tage (Melanie)      | 29.08.2021 | 27.11.2021 |         |
          | 31.12.2021 | Meine dritte Challenge | 31.12.2021 | 31.03.2022 |         |
        Then This body data is found
          | Day        | LeftArm | RightArm | LeftLeg | RightLeg | Shoulder | Chest | Belly | BellyPlus5 | BellyMinus5 | Hip |
          | 25.09.2022 | 33      | 34.5     | 57      | 59       | 118      | 104   | 94.5  | 90         | 94.5        | 97  |