using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdCalculatedScopeTests
{
    private readonly SbdScenarioContext _context;

    public SbdCalculatedScopeTests(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"The scope shall be calculated from '(.*)' to '(.*)'")]
    public void GivenTheScopeShallBeCalculatedFromTo(DateOnly startDate, DateOnly endDate)
    {
        var calculator = new ScopeCalculator(_context.WeightRepository);
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
}