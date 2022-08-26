using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainServiceSteps
{
    private SbdRepository? memoryRepository;
    private SbdDomainService? service;

    [Then(@"The weight of '(.*)' is '(.*)'")]
    public void ThenTheWeightOfIs(string dateAsString, decimal weight)
    {
        var date = dateAsString.ToDateOnlyDE();
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
    public void WhenTheDailyWeightIsAddedOn(decimal weight, string dateAsString)
    {
        var date = dateAsString.ToDateOnlyDE();
        service!.SetWeight(date, weight);
    }

    [When(@"These weight records already exist")]
    public void WhenTheseWeightRecordsAlreadyExist(Table table)
    {
        foreach (var row in table.Rows)
        {
            var date = row[0].ToDateOnlyDE();
            service!.SetWeight(date, Decimal.Parse(row[1], StepExtensions.German));
        }
    }

    [When(@"the weight for '(.*)' is removed")]
    public void WhenTheWeightForIsRemoved(string dayAsString)
    {
        service!.RemoveWeight(dayAsString.ToDateOnlyDE());
    }
}