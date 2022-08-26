using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;
using TechTalk.SpecFlow.Assist;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainServiceSteps
{
    private SbdRepository? memoryRepository;
    private SbdDomainService? service;

    [Then(@"The weight of '(.*)' is '(.*)'")]
    public void ThenTheWeightOfIs(DateOnly date, decimal weight)
    {
        var foundWeight = service!.GetWeight(date);
        foundWeight.Should().Be(weight);
    }

    [Then(@"There is only (.*) weight record in the repository")]
    [When(@"There is only (.*) weight record in the repository")]
    public void ThenThereIsOnlyWeightRecordInTheRepository(int numberOfRecords)
    {
        var found = memoryRepository!.GetWeightCount();
        found.Should().Be(numberOfRecords);
    }

    [Given(@"SbdDomainService is initialized with in-memory repository")]
    public void GivenSbdDomainServiceIsInitializedWithInMemoryRepository()
    {
        memoryRepository = new SbdRepository();
        service = new SbdDomainService(memoryRepository);
    }

    [Then(@"The daily weight '(.*)' is updated on '(.*)'")]
    [When(@"The daily weight '(.*)' is updated on '(.*)'")]
    [Then(@"The daily weight '(.*)' is added on '(.*)'")]
    [When(@"The daily weight '(.*)' is added on '(.*)'")]
    public void WhenTheDailyWeightIsAddedOn(decimal weight, DateOnly date)
    {
        service!.SetWeight(date, weight);
    }

    [When(@"These weight records already exist")]
    public void WhenTheseWeightRecordsAlreadyExist(IEnumerable<DiaryWeight> existingData)
    {
        foreach (var row in existingData)
        {
            service!.SetWeight(row.Day, row.Weight);
        }
    }

    [When(@"the weight for '(.*)' is removed")]
    public void WhenTheWeightForIsRemoved(string dayAsString)
    {
        service!.RemoveWeight(dayAsString.ToDateOnlyDE());
    }

    [Then(@"GetAllWeightData returns this")]
    public void ThenGetAllWeightDataReturnsThis(IEnumerable<DiaryWeight> expected)
    {
        var allData = service!.GetAllWeightData().ToDictionary(_ => _.Day);

        allData.Count.Should().Be(expected.Count(), because: "Both collections should have the same amount of records");
        foreach (var row in expected)
        {
            if (allData.TryGetValue(row.Day, out var found))
            {
                found.Weight.Should().Be(row.Weight, because: $"Wrong weight for day {row.Day}");
            }
            else
            {
                Assert.Fail($"Missing weight for date {row.Day}");
            }
        }
    }
}