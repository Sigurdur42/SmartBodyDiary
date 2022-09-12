namespace SmartBodyDiaryDomain;

internal abstract class SbdWeightServiceBase : ISbdWeightService
{
    private readonly SlidingWeightRepository _slidingWeightRepository;

    protected SbdWeightServiceBase(SlidingWeightRepository slidingWeightRepository)
    {
        _slidingWeightRepository = slidingWeightRepository;
    }

    public void Calculate(DiaryWeight[] weightData, int rangeToConsider)
    {
        _slidingWeightRepository.Clear();

        var sortedWeightData = weightData.OrderBy(_ => _.Day).ToArray();
        var singleValues = new List<decimal>();

        foreach (var item in sortedWeightData.Select(_ => new SlidingWeight(_.Day, _.Weight)))
        {
            singleValues.Add(item.Weight);
            while (singleValues.Count > rangeToConsider)
                singleValues.RemoveAt(0);

            item.Sliding = Math.Round(CalculateSingleValue(singleValues), 6, MidpointRounding.AwayFromZero);

            _slidingWeightRepository.AddOrUpdate(item);
        }
    }

    public SlidingWeight? GetWeight(DateOnly date)
    {
        return _slidingWeightRepository.Get(date);
    }

    protected abstract decimal CalculateSingleValue(List<decimal> singleValues);
}