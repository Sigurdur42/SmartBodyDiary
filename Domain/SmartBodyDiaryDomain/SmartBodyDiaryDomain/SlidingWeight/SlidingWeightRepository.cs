using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

internal class SlidingWeightRepository
{
    private readonly ConcurrentDictionary<DateOnly, SlidingWeight> _calculatedData = new();

    public void Clear()
    {
        _calculatedData.Clear();
    }

    public void AddOrUpdate(SlidingWeight item)
    {
        _calculatedData.AddOrUpdate(item.Day, item, (_, _) => item);
    }

    public SlidingWeight? GetWeight(DateOnly date)
    {
        return _calculatedData.TryGetValue(date, out var result) ? result : null;
    }
}