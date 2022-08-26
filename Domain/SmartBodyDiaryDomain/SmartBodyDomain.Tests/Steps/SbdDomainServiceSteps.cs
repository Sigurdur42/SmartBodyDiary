using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainServiceSteps
{
    private SbdMemoryRepository? memoryRepository;
    private SbdDomainService? service;

    [Then(@"The weight of '(.*)' is '(.*)'")]
    public void ThenTheWeightOfIs(string dateAsString, decimal weight)
    {
        var date = dateAsString.ToDateOnlyDE();
        var foundWeight = service!.GetWeight(date);
        foundWeight.Should().Be(weight);
    }

    [Then(@"There is only (.*) weight record in the repository")]
    public void ThenThereIsOnlyWeightRecordInTheRepository(int numberOfRecords)
    {
        var found = memoryRepository!.GetWeightCount();
        found.Should().Be(numberOfRecords);
    }

    [Given(@"SbdDomainService is initialized with in-memory repository")]
    public void GivenSbdDomainServiceIsInitializedWithInMemoryRepository()
    {
        memoryRepository = new SbdMemoryRepository();
        service = new SbdDomainService(memoryRepository);
    }

    [When(@"The daily weight '(.*)' is added on '(.*)'")]
    public void WhenTheDailyWeightIsAddedOn(decimal weight, string dateAsString)
    {
        var date = dateAsString.ToDateOnlyDE();
        service!.SetWeight(date, weight);
    }
}