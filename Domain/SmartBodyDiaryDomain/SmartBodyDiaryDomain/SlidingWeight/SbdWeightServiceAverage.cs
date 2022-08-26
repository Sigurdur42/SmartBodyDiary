using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SbdWeightServiceAverage : SbdWeightServiceBase
{
    public SbdWeightServiceAverage(SlidingWeightRepository slidingWeightRepository) 
        : base(slidingWeightRepository)
    {
    }

    protected override decimal CalculateSingleValue(List<decimal> singleValues)
    {
        var divider = singleValues.Count;
        var total = singleValues.Sum();

        var calculatedWeight = total / divider;
        return calculatedWeight;
    }
}