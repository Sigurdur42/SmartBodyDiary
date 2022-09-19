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
	And This challenge record is to be used on '01.01.2022'
		| Property | value      |
		| Start    | 01.01.2022 |
		| End      | 31.03.2022 |
	And This body data is to be used on '01.01.2021'
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
	And These daily goals shall be used on '01.01.2022'
		| Goal    | Reached |
		| Neat    | Reached |
		| Sleep   | Unknown |
		| Macros  | Missed  |
		| Kcal    | Reached |
		| Protein | Unknown |

	And These daily goals shall be used on '01.02.2022'
		| Goal    | Reached |
		| Neat    | Reached |
		| Sleep   | Unknown |
		| Macros  | Missed  |
		| Kcal    | Reached |
		| Protein | Unknown |

	And The data is written to JSON
	And The data is read from JSON
	Then The previous existing weight records shall be read
	Then The previous existing gym session records shall be read
	Then The previous existing challenge record shall be read
	Then The previous existing body data record shall be read
	Then The previous existing daily goals record shall be read