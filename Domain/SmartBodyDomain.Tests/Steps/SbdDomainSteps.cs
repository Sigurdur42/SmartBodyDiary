using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainSteps
{
    private SbdDomainService? _service;
    private SdbDateBasedRepository<DiaryWeight>? memoryRepository;

    [Then(@"The weight of '(.*)' is '(.*)'")]
    public void ThenTheWeightOfIs(DateOnly date, decimal weight)
    {
        var foundWeight = _service!.GetWeight(date);
        foundWeight.Should().Be(weight);
    }

    [Then(@"There is only (.*) weight record in the repository")]
    [When(@"There is only (.*) weight record in the repository")]
    public void ThenThereIsOnlyWeightRecordInTheRepository(int numberOfRecords)
    {
        var found = memoryRepository!.Length;
        found.Should().Be(numberOfRecords);
    }

    [Given(@"SbdDomainService is initialized with in-memory repository")]
    public void GivenSbdDomainServiceIsInitializedWithInMemoryRepository()
    {
        memoryRepository = new SdbDateBasedRepository<DiaryWeight>();
        _service = new SbdDomainService(memoryRepository);
    }

    [Then(@"The daily weight '(.*)' is updated on '(.*)'")]
    [When(@"The daily weight '(.*)' is updated on '(.*)'")]
    [Then(@"The daily weight '(.*)' is added on '(.*)'")]
    [When(@"The daily weight '(.*)' is added on '(.*)'")]
    public void WhenTheDailyWeightIsAddedOn(decimal weight, DateOnly date)
    {
        _service!.SetWeight(date, weight);
    }

    [Given(@"These weight records already exist")]
    [When(@"These weight records already exist")]
    public void WhenTheseWeightRecordsAlreadyExist(IEnumerable<DiaryWeight> existingData)
    {
        foreach (var row in existingData)
            _service!.SetWeight(row.Day, row.Weight);
    }

    [When(@"the weight for '(.*)' is removed")]
    public void WhenTheWeightForIsRemoved(string dayAsString)
    {
        _service!.RemoveWeight(dayAsString.ToDateOnlyDE());
    }

    [Then(@"GetAllWeightData returns this")]
    public void ThenGetAllWeightDataReturnsThis(IEnumerable<DiaryWeight> expected)
    {
        var allData = _service!.GetAllWeightData().ToDictionary(_ => _.Day);

        allData.Count.Should().Be(expected.Count(), "Both collections should have the same amount of records");
        foreach (var row in expected)
            if (allData.TryGetValue(row.Day, out var found))
                found.Weight.Should().Be(row.Weight, $"Wrong weight for day {row.Day}");
            else
                Assert.Fail($"Missing weight for date {row.Day}");
    }

    [Then(@"The weight of '(.*)' does not exist")]
    public void ThenTheWeightOfDoesNotExist(DateOnly date)
    {
        var found = _service!.GetWeight(date);
        found.Should().BeNull("There hould be no weight for this date");
    }
}