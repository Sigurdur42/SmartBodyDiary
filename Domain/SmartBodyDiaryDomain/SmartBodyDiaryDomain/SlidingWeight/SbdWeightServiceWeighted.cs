using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SbdWeightServiceWeighted : ISbdWeightService
{
    private readonly SlidingWeightRepository _slidingWeightRepository;

    public SbdWeightServiceWeighted(SlidingWeightRepository slidingWeightRepository)
    {
        _slidingWeightRepository = slidingWeightRepository;
    }

    public void Calculate(DiaryWeight[] weightData)
    {
        _slidingWeightRepository.Clear();

        // TODO: maxValues needs a useful logic
        var maxValues = 7;

        var sortedWeightData = weightData.OrderBy(_ => _.Day).ToArray();
        var singleValues = new List<decimal>();

        foreach (var item in sortedWeightData.Select(_ => new SlidingWeight(_.Day, _.Weight)))
        {
            singleValues.Add(item.Weight);

            while (singleValues.Count > maxValues)
            {
                singleValues.RemoveAt(0);
            }

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
            item.Sliding = Math.Round(calculatedWeight, 2, MidpointRounding.AwayFromZero);

            _slidingWeightRepository.AddOrUpdate(item);
        }
    }

    public SlidingWeight? GetWeight(DateOnly date)
        => _slidingWeightRepository.GetWeight(date);
}