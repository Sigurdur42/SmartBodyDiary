Feature: SbdCalculatedScope - Verifies all kinds of scope calculations

    Background:
        Given The average sliding calculator is used
        Given These weight records are available
          | Day        | Weight | Comment         |
          | 2020-08-18 | 82.5   | Start of week 1 |
          | 2020-08-19 | 83.5   |                 |
          | 2020-08-20 | 83.5   |                 |
          | 2020-08-21 | 84.5   |                 |
          | 2020-08-22 | 81.5   |                 |
          | 2020-08-24 | 85.2   |                 |
          | 2020-08-25 | 87.7   | End of week 1   |
          | 2020-08-30 | 87.7   |                 |
          | 2020-09-01 | 87.7   |                 |
        Given These gym sessions are available
          | Day        | GymProgress | Comment         |
          | 2020-08-18 | Normal      | Start of week 1 |
          | 2020-08-19 | Progress    |                 |
          | 2020-08-20 | Progress    |                 |
          | 2020-08-26 | Progress    | Not in week 1   |
        And These daily goals shall be used
          | Day        | Neat    | Sleep   | Macros | Kcal    | Protein | Comment      |
          | 18.08.2020 | Reached | Unknown | Missed | Reached | Missed  | Start week 1 |
          | 25.08.2020 | Reached | Unknown | Missed | Reached | Reached | End week 1   |
        And The given data is set in the repository
        And The sliding weight has been calculated

    Scenario: Calculate weekly scope when all data is present
        Given The scope shall be calculated from '18.08.2020' to '25.08.2020'
        Then The weight diff shall be '5.2' kg
        Then The sliding weight diff shall be '1.56' kg
        And There must be '7' weight records in scope result
        And There must be '3' gym sessions in scope result
        And There must be this daily goal summary
          | Neat | Sleep | Macros | Kcal | Protein |
          | 2/0  | 0/0   | 0/2    | 2/0  | 1/1     |

    Scenario: Calculate weekly scope when no data is present
        Given The scope shall be calculated from '18.08.2018' to '25.08.2018'
        Then The weight diff shall be '0' kg
        Then The sliding weight diff shall be '0' kg
        And There must be '0' weight records in scope result
        And There must be '0' gym sessions in scope result
        And There must be this daily goal summary
          | Neat | Sleep | Macros | Kcal | Protein |
          | 0/0  | 0/0   | 0/0    | 0/0  | 0/0     |

    Scenario: Calculate weekly scope when a single data point is present
        Given The scope shall be calculated from '18.08.2018' to '18.08.2020'
        Then The weight diff shall be '0' kg
        Then The sliding weight diff shall be '0' kg
        And There must be '1' weight records in scope result
        And There must be '1' gym sessions in scope result
        And There must be this daily goal summary
          | Neat | Sleep | Macros | Kcal | Protein |
          | 1/0  | 0/0   | 0/1    | 1/0  | 0/1     |