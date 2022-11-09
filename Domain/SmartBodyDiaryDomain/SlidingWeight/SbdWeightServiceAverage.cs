namespace SmartBodyDiaryDomain;

/// <summary>
/// This class implements this simple average sliding weight algorythm where every day of the range has an
/// equal weight in the calculation.
/// </summary>
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