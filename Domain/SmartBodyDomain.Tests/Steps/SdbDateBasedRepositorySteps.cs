using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SdbDateBasedRepositorySteps
{
    private readonly SbdScenarioContext _context;

    public SdbDateBasedRepositorySteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"The date based repository has been created for repo testing")]
    public void GivenTheDateBasedRepositoryHasBeenCreatedForRepoTesting()
    {
        _context.WeightRepository = new SdbDateBasedRepository<DiaryWeight>();
    }

    [Then(@"the value '(.*)' is added on '(.*)'")]
    [When(@"the value '(.*)' is added on '(.*)'")]
    public void WhenTheValueIsAddedOn(decimal value, DateOnly date)
    {
        _context.WeightRepository.AddOrUpdate(new DiaryWeight(date, value));
    }

    [Then(@"the repository must have '(.*)' record")]
    public void ThenTheRepositoryMustHaveRecord(int numberOfRecords)
    {
        var recordCount = _context.WeightRepository.Length;
        recordCount.Should().Be(numberOfRecords);
    }

    [Then(@"the value of '(.*)' must be '(.*)'")]
    public void ThenTheValueOfMustBe(DateOnly date, decimal value)
    {
        var found = _context.WeightRepository.Get(date)?.Weight;
        found.Should().Be(value);
    }

    [When(@"These repository records already exist")]
    public void WhenTheseRepositoryRecordsAlreadyExist(IEnumerable<DiaryWeight> existingData)
    {
        _context.WeightRepository.Clear();
        _context.WeightRepository.AddOrUpdateRange(existingData.ToList());
    }

    [Then(@"the value on '(.*)' is removed")]
    public void ThenTheValueOnIsRemoved(DateOnly day)
    {
        _context.WeightRepository.Remove(day);
    }

    [Then(@"the value of '(.*)' must not exist")]
    public void ThenTheValueOfMustNotExist(DateOnly day)
    {
        _context.WeightRepository.Get(day).Should().BeNull();
    }

    [Then(@"GetAllData returns '(.*)' records")]
    public void ThenGetAllDataReturnsRecords(int numberOfRecords)
    {
        var result = _context.WeightRepository.GetAllData();
        result.Length.Should().Be(numberOfRecords);
    }
}