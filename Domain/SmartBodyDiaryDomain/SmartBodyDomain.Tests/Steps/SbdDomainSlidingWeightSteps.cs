using FluentAssertions;
using Microsoft.VisualBasic;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class SbdDomainSlidingWeightSteps
{
    private List<DiaryWeight> _availableWeights = new();
    private SbdAverageWeightService? _averageWeightService = new();
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

    [Given(@"SbdAverageWeightService exists")]
    public void GivenSbdAverageWeightServiceExists()
    {
        _averageWeightService = new();
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
}