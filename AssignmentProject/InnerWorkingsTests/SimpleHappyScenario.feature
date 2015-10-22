Feature: SimpleHappyScenario
	Just to fullfill basic reqs.

@mytag
Scenario: Process Job
	Given the following items in the job
	| Name  | Price | IsTaxable | marginType |
	| item1 | 125   | true      | base       |
	| item2 | 100   | true      | extra      |
	And following tax is '7'
	And BaseMargin is '11'
	And ExtraMargin is '5'
	When I process job
	Then the result should be as bellow
	| output         |
	| item1: xxxx.xx |
	| item2: xxxx.xx |