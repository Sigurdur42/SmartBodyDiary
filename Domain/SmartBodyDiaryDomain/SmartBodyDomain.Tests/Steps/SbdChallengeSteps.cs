using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;
using SmartBodyDomain.Tests.Steps;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdChallengeSteps
{
    private SdbDateBasedRepository<Challenge> _repository = new();
    private Challenge _challenge = new();
    
    [Given(@"This challenge data is to be used on '(.*)'")]
    public void GivenThisChallengeDataIsToBeUsed(DateOnly day, Table table)
    {
        _challenge = new Challenge(day);
        _challenge.FillFromReflection(table);
    }

    [Given(@"An empty challenge repository has been initialized")]
    public void GivenAnEmptyChallengeRepositoryHasBeenInitialized()
    {
        _repository = new SdbDateBasedRepository<Challenge>();
    }

    [Given(@"the current challenge is added to the repository")]
    public void GivenTheCurrentChallengeIsAddedToTheRepository()
    {
        _repository.AddOrUpdate(_challenge);
    }

    [Then(@"Then Exactly '(.*)' body data record is in the repository")]
    public void ThenThenExactlyBodyDataRecordIsInTheRepository(int numberOfRecords)
    {
        var result = _repository.Length;
        result.Should().Be(numberOfRecords);
    }

    [Then(@"IsActive shall be '(.*)' on '(.*)'")]
    public void ThenIsActiveShallBeOn(bool isActive, DateOnly referenceDay)
    {
        var result = _challenge.IsActive(referenceDay);
        result.Should().Be(isActive);
    }
}

