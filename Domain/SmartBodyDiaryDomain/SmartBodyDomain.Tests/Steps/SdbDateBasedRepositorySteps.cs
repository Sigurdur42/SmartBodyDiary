using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SdbDateBasedRepositorySteps
{
    private SdbDateBasedRepository<DiaryWeight> _repository = new();

    [Given(@"The date based repository has been created for repo testing")]
    public void GivenTheDateBasedRepositoryHasBeenCreatedForRepoTesting()
    {
        _repository = new SdbDateBasedRepository<DiaryWeight>();
    }

    [Then(@"the value '(.*)' is added on '(.*)'")]
    [When(@"the value '(.*)' is added on '(.*)'")]
    public void WhenTheValueIsAddedOn(decimal value, DateOnly date)
    {
        _repository.AddOrUpdate(date, new DiaryWeight(date, value));
    }

    [Then(@"the repository must have '(.*)' record")]
    public void ThenTheRepositoryMustHaveRecord(int numberOfRecords)
    {
        var recordCount = _repository.Length;
        recordCount.Should().Be(numberOfRecords);
    }

    [Then(@"the value of '(.*)' must be '(.*)'")]
    public void ThenTheValueOfMustBe(DateOnly date, decimal value)
    {
        var found = _repository.Get(date)?.Weight;
        found.Should().Be(value);
    }

    [When(@"These repository records already exist")]
    public void WhenTheseRepositoryRecordsAlreadyExist(IEnumerable<DiaryWeight> existingData)
    {
        _repository.Clear();
        _repository.AddOrUpdateRange(existingData.ToList());
    }

    [Then(@"the value on '(.*)' is removed")]
    public void ThenTheValueOnIsRemoved(DateOnly day)
    {
        _repository.Remove(day);
    }

    [Then(@"the value of '(.*)' must not exist")]
    public void ThenTheValueOfMustNotExist(DateOnly day)
    {
        _repository.Get(day).Should().BeNull();
    }

    [Then(@"GetAllData returns '(.*)' records")]
    public void ThenGetAllDataReturnsRecords(int numberOfRecords)
    {
        var result = _repository.GetAllData();
        result.Length.Should().Be(numberOfRecords);
    }
}