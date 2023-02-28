using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainSlidingWeightSteps
{
    private readonly SbdScenarioContext _context;

    private Exception? _lastException;

    public SbdDomainSlidingWeightSteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"the sliding weight is calculated considering '(.*)' records")]
    public void GivenTheAverageWeightIsCalculated(int rangeToConsider)
    {
        try
        {
            _context.AverageWeightService!.Calculate(_context.AvailableWeights.ToArray(), rangeToConsider);
        }
        catch (Exception error)
        {
            _lastException = error;
            throw;
        }
    }

    [Given(@"The average sliding calculator is used")]
    public void GivenSbdAverageWeightServiceExists()
    {
        _context.AverageWeightService = new SbdWeightServiceAverage(_context.SlidingWeightRepository);
    }

    [Given(@"These weight records are available")]
    public void GivenTheseWeightRecordsAreAvailable(IEnumerable<DiaryWeight> existingData)
    {
        _context.AvailableWeights = existingData.ToList();
    }

    [Then(@"The sliding weight for '(.*)' is '(.*)'")]
    public void ThenTheAverageWeightForIs(DateOnly date, decimal averageWeight)
    {
        var foundWeight = _context.AverageWeightService!.GetWeight(date);
        foundWeight?.SlidingRounded.Should().Be(averageWeight);
    }

    [Then(@"No weight calculation exception occurred")]
    public void ThenNoWeightCalculationExceptionOccurred()
    {
        _lastException.Should().BeNull();
    }

    [Given(@"The weighted sliding calculator is used")]
    public void GivenTheWeightedSlidingCalculatorIsUsed()
    {
        _context.AverageWeightService = new SbdWeightServiceWeighted(_context.SlidingWeightRepository);
    }
}