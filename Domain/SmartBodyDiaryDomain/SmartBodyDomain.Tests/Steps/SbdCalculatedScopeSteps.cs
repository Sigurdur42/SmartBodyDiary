using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdCalculatedScopeSteps
{
    private readonly SbdScenarioContext _context;

    public SbdCalculatedScopeSteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"The scope shall be calculated from '(.*)' to '(.*)'")]
    public void GivenTheScopeShallBeCalculatedFromTo(DateOnly startDate, DateOnly endDate)
    {
        var calculator = new ScopeCalculator(
            _context.SlidingWeightRepository,
            _context.GymSessionRepository);
        
        _context.LastCalculatedScope = calculator.Calculate(startDate, endDate);
    }

    [Then(@"The weight diff shall be '(.*)' kg")]
    public void ThenTheWeightDiffShallBeKg(decimal weightDiff)
    {
        _context.LastCalculatedScope.WeightDiff.Should().Be(weightDiff);
    }

    [Given(@"The given data is set in the repository")]
    public void GivenTheGivenDataIsSetInTheRepository()
    {
        _context.WeightRepository.Clear();
        _context.WeightRepository.AddOrUpdateRange(_context.AvailableWeights);
    }

    [Given(@"The sliding weight has been calculated")]
    public void GivenTheSlidingWeightHasBeenCalculated()
    {
        _context.AverageWeightService!.Calculate(_context.AvailableWeights.ToArray(), 7);
    }

    [Then(@"There must be '([^']*)' weight records in scope result")]
    public void ThenThereMustBeWeightRecordsInScopeResult(int numberOfRecords)
    {
        _context.LastCalculatedScope.Weights.Length.Should().Be(numberOfRecords);
    }

    [Then(@"The sliding weight diff shall be '([^']*)' kg")]
    public void ThenTheSlidingWeightDiffShallBeKg(decimal slidingWeightDiff)
    {
        _context.LastCalculatedScope.WeightDiffSliding.Should().Be(slidingWeightDiff);
    }

    [Then(@"There must be '([^']*)' gym sessions in scope result")]
    public void AndThereMustbeXGymSessions(int numberOfGymSessions)
    {
        _context.LastCalculatedScope.GymSessions.Length.Should().Be(numberOfGymSessions);
    }
}