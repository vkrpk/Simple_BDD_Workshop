Feature: CalculatorAdd
Simple calculator to add two numbers

Scenario: Verify two entries and add them if they are numbers
Given the first element is 50
And the second element is 70
When the two elements are integers
And the two elements are added
Then the addition type should be integer
And the addition result should be equal to 120

Scenario: Verify two variables inputs and add them if they are numbers
Given the first element is <numberOne>
And the second element is <numberTwo>
When the two elements are integers
And the two elements are added
Then the addition type should be integer
And the addition result should be equal to <expectedResult>
    Examples:
    | numberOne | numberTwo | expectedResult |
    | 1         | 2         | 3              |
    | 10        | 20        | 30             |
    | 12        | 245       | 257            |