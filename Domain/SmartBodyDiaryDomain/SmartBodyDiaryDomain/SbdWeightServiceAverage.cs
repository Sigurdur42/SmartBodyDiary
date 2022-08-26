using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

public class SbdWeightServiceAverage: ISbdWeightService
{
    private ConcurrentDictionary<DateOnly, AverageWeight> _calculatedData = new();

    public void Calculate(DiaryWeight[] weightData)
    {
        _calculatedData.Clear();

        // TODO: maxValues needs a useful logic
        var maxValues = 7;

        var sortedWeightData = weightData.OrderBy(_ => _.Day).ToArray();
        var singleValues = new List<decimal>();

        foreach (var item in sortedWeightData.Select(_ => new AverageWeight(_.Day, _.Weight)))
        {
            singleValues.Add(item.Weight);
            while (singleValues.Count > maxValues)
            {
                singleValues.RemoveAt(0);
            }

            var divider = singleValues.Count;
            var total = singleValues.Sum();

            var calculatedWeight = total / divider;
            item.Average = Math.Round(calculatedWeight, 2, MidpointRounding.AwayFromZero);

            _calculatedData.AddOrUpdate(item.Day, item, (_, _) => item);
        }
    }

    public AverageWeight? GetWeight(DateOnly date)
    {
        if (_calculatedData.TryGetValue(date, out var result))
        {
            return result;
        }

        return null;
    }
}