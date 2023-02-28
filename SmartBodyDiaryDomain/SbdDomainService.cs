namespace SmartBodyDiaryDomain;

public class SbdDomainService
{
    private readonly SdbDateBasedRepository<DiaryWeight> _repository;

    public SbdDomainService(SdbDateBasedRepository<DiaryWeight> repository)
    {
        _repository = repository;
    }

    public void SetWeight(DateOnly date, decimal weight)
    {
        _repository.AddOrUpdate(new DiaryWeight(date, weight));
    }

    public decimal? GetWeight(DateOnly date)
    {
        return _repository.Get(date)?.Weight;
    }

    public void RemoveWeight(DateOnly date)
    {
        _repository.Remove(date);
    }

    public DiaryWeight[] GetAllWeightData()
    {
        return _repository.GetAllData();
    }
}