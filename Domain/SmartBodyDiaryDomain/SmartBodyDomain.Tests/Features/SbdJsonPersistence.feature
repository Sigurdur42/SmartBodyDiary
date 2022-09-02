Feature: SbdJsonPersistence - Verify JSON persistence functionality	

Scenario: DiaryWeight - JSON can be written and read again
	Given The DiaryWeight JSON persistence is create
	When These DiaryWeight records shall be used
	  | Day        | Weight |
	  | 25.08.2022 | 83.00  |
	  | 26.08.2022 | 82.00  |
	  | 27.08.2022 | 85.00  |
	And DiaryWeight data is written to JSON
	And DiaryWeight data is read from JSON
	Then The previous existing weight records shall be read