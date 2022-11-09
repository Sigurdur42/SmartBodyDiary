using FluentAssertions;
using SmartBodyDiaryDomain;
using SmartBodyDomain.Tests.Steps;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdChallengeSteps
{
    private readonly SbdScenarioContext _context;

    public SbdChallengeSteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"This challenge data is to be used on '(.*)'")]
    public void GivenThisChallengeDataIsToBeUsed(DateOnly day, Table table)
    {
        _context.Challenge = new Challenge(day);
        _context.Challenge.FillFromReflection(table);
    }

    [Given(@"An empty challenge repository has been initialized")]
    public void GivenAnEmptyChallengeRepositoryHasBeenInitialized()
    {
        _context.ChallengeRepository = new SdbDateBasedRepository<Challenge>();
    }

    [Given(@"the current challenge is added to the repository")]
    public void GivenTheCurrentChallengeIsAddedToTheRepository()
    {
        _context.ChallengeRepository.AddOrUpdate(_context.Challenge);
    }

    [Then(@"Exactly '(.*)' challenge record is in the repository")]
    public void ThenThenExactlyBodyDataRecordIsInTheRepository(int numberOfRecords)
    {
        var result = _context.ChallengeRepository.Length;
        result.Should().Be(numberOfRecords);
    }

    [Then(@"IsActive shall be '(.*)' on '(.*)'")]
    public void ThenIsActiveShallBeOn(bool isActive, DateOnly referenceDay)
    {
        var result = _context.Challenge.IsActive(referenceDay);
        result.Should().Be(isActive);
    }
}