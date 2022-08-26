namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainServiceSteps
{
    [Then(@"The weight of (.*) is (.*)")]
    public void ThenTheWeightOfIs(string p0, decimal p1)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"There is only (.*) weight record in the repository")]
    public void ThenThereIsOnlyWeightRecordInTheRepository(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"SbdDomainService is initialized with in-memory repository")]
    public void GivenSbdDomainServiceIsInitializedWithInMemoryRepository()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"The daily weight (.*) is added on (.*)")]
    public void WhenTheDailyWeightIsAddedOn(decimal p0, string p1)
    {
        ScenarioContext.StepIsPending();
    }
}