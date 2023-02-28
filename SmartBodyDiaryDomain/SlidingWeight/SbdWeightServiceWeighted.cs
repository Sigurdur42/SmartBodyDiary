namespace SmartBodyDiaryDomain;

/// <summary>
/// This class implements the weighted sliding weight algorythm.
/// <br/> See https://tradistats.com/gleitender-gewichteter-durchschnitt/ for algorythm description.
/// </summary>
internal class SbdWeightServiceWeighted : SbdWeightServiceBase
{
    public SbdWeightServiceWeighted(SlidingWeightRepository slidingWeightRepository)
        : base(slidingWeightRepository)
    {
    }

    protected override decimal CalculateSingleValue(List<decimal> singleValues)
    {
        var index = 1;

        var total = 0m;
        var divider = 0;
        foreach (var part in singleValues)
        {
            total += index * part;
            divider += index;
            ++index;
        }

        var calculatedWeight = total / divider;
        return Math.Round(calculatedWeight, 2, MidpointRounding.AwayFromZero);
    }
}