using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

public class SbdRepository
{
    private readonly ConcurrentDictionary<DateOnly, decimal> _weights = new();

    public void SetWeight(DateOnly date, decimal weight)
        => _weights.AddOrUpdate(date, weight, (_, _) => weight);

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

    public void RemoveWeight(DateOnly date)
        => _weights.TryRemove(date, out var _);

    public DiaryWeight[] GetAllWeightData()
    {
        return _weights
            .Select(_ => new DiaryWeight(_.Key, _.Value))
            .OrderBy(_=>_.Day)
            .ToArray();
    }
}