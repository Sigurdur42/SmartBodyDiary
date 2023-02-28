using System.Collections.Concurrent;

namespace SmartBodyDiaryDomain;

public class SdbDateBasedRepository<TDataType> where TDataType : IDateRecord, new()
{
    private readonly ConcurrentDictionary<DateOnly, TDataType> _data = new();
    public int Length => _data.Count;

    public void AddOrUpdate(TDataType record)
        => _data.AddOrUpdate(record.Day, record, (_, _) => record);

    public TDataType? Get(DateOnly date)
        => _data.TryGetValue(date, out var result) ? result : default;

    public void Clear() => _data.Clear();

    public void AddOrUpdateRange(IEnumerable<TDataType> records)
    {
        foreach (var record in records)
        {
            _data.AddOrUpdate(record.Day, record, (_, _) => record);
        }
    }

    public TDataType? Remove(DateOnly day)
    {
        return _data.TryRemove(day, out var result) ? result : default;
    }

    public TDataType[] GetAllData() => _data.Values.ToArray();
}