using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SbdWeightServiceWeighted : SbdWeightServiceBase
{
    public SbdWeightServiceWeighted(SlidingWeightRepository slidingWeightRepository)
        : base(slidingWeightRepository)
    {
    }

    protected override decimal CalculateSingleValue(List<decimal> singleValues)
    {
        // Now calculate weighted average (See https://tradistats.com/gleitender-gewichteter-durchschnitt/)
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