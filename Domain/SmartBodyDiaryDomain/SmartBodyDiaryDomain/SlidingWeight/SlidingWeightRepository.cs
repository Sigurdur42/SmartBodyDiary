using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SlidingWeightRepository
{
    private readonly ConcurrentDictionary<DateOnly, AverageWeight> _calculatedData = new();

    public void Clear() => _calculatedData.Clear();

    public void AddOrUpdate(AverageWeight item)
        => _calculatedData.AddOrUpdate(item.Day, item, (_, _) => item);

    public AverageWeight? GetWeight(DateOnly date)
    {
        return _calculatedData.TryGetValue(date, out var result) ? result : null;
    }
}