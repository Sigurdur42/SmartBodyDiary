using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

public class SbdMemoryRepository
{
    private readonly ConcurrentDictionary<DateOnly, decimal> _weights = new();

    public void SetWeight(DateOnly date, decimal weight)
    {
        _weights.AddOrUpdate(date, weight, (_, _) => weight);
    }

    public decimal? GetWeight(DateOnly date)
    {
        if (_weights.TryGetValue(date, out var result))
        {
            return result;
        }

        return null;
    }

    public int GetWeightCount()
        => _weights.Count;
}