using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Simple_BDD_Workshop.Features;

[Binding]
public sealed class StepDefinition1
{
    private Calculator _calculator = new Calculator();

    [Given(@"the first element is (.*)")]
    public void GivenTheFirstElementIs(int numberOne)
    {
        _calculator.FirstNumber = numberOne;
    }

    [Given(@"the second element is (.*)")]
    public void GivenTheSecondElementIs(int numberTwo)
    {
        _calculator.SecondNumber = numberTwo;
    }

    [When(@"the two elements are integers")]
    public void WhenTheTwoElementsAreIntegers()
    {
        Assert.IsTrue(_calculator.FirstNumber is int);
        Assert.IsTrue(_calculator.SecondNumber is int);
    }

    [When(@"the two elements are added")]
    public void WhenTheTwoElementsAreAdded()
    {
        _calculator.Add();
    }

    [Then(@"the addition type should be integer")]
    public void ThenTheAdditionTypeShouldBeInteger()
    {
        Assert.IsTrue(_calculator.Result is int);
    }

    [Then(@"the addition result should be equal to (.*)")]
    public void ThenTheAdditionResultShouldBeEqualTo(int expectedResult)
    {
        Assert.AreEqual(expectedResult, _calculator.Result);
    }
}