namespace SmartBodyDiaryDomain;

public class ScopeCalculator
{
    private readonly SdbDateBasedRepository<DiaryWeight> _weightRepository;

    public ScopeCalculator(
        SdbDateBasedRepository<DiaryWeight> weightRepository)
    {
        _weightRepository = weightRepository;
    }
    public CalculatedScope Calculate(DateOnly startDate, DateOnly endDate)
    {
        var result =  new CalculatedScope();
        
        var all = _weightRepository.GetAllData();
        var data = all
            .Where(_ => _.Day >= startDate && _.Day <= endDate)
            .OrderBy(_=>_.Day)
            .ToArray();

            result.WeightDiff = data.Length < 2
                ? 0.00m
                : data.Last().Weight - data.First().Weight;

            return result;
    }
}