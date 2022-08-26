using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SbdWeightServiceAverage : ISbdWeightService
{
    private readonly SlidingWeightRepository _slidingWeightRepository;

    public SbdWeightServiceAverage(SlidingWeightRepository slidingWeightRepository)
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

            var divider = singleValues.Count;
            var total = singleValues.Sum();

            var calculatedWeight = total / divider;
            item.Sliding = Math.Round(calculatedWeight, 2, MidpointRounding.AwayFromZero);

            _slidingWeightRepository.AddOrUpdate(item);
        }
    }

    public SlidingWeight? GetWeight(DateOnly date)
        => _slidingWeightRepository.GetWeight(date);
}