using FluentAssertions;
using Microsoft.VisualBasic;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainSlidingWeightSteps
{
    private List<DiaryWeight> _availableWeights = new();
    private ISbdWeightService? _averageWeightService;
    private Exception? _lastException;

    [Given(@"the sliding weight is calculated")]
    public void GivenTheAverageWeightIsCalculated()
    {
        try
        {
            _averageWeightService!.Calculate(_availableWeights.ToArray());
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
        _averageWeightService = new SbdWeightServiceAverage();
    }

    [Given(@"These weight records are available")]
    public void GivenTheseWeightRecordsAreAvailable(IEnumerable<DiaryWeight> existingData)
        => _availableWeights = existingData.ToList();

    [Then(@"The sliding weight for '(.*)' is '(.*)'")]
    public void ThenTheAverageWeightForIs(DateOnly date, decimal averageWeight)
    {
        var foundWeight = _averageWeightService!.GetWeight(date);
        foundWeight?.AverageRounded.Should().Be(averageWeight);
    }

    [Then(@"No weight calculation exception occurred")]
    public void ThenNoWeightCalculationExceptionOccurred()
    {
        _lastException.Should().BeNull();
    }

    [Given(@"The weighted sliding calculator is used")]
    public void GivenTheWeightedSlidingCalculatorIsUsed()
    {
        _averageWeightService = new SbdWeightServiceWeighted();
    }
}