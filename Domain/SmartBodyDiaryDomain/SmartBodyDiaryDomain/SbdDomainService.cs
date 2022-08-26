namespace SmartBodyDiaryDomain;

public class SbdDomainService
{
    private readonly SbdRepository _repository;

    public SbdDomainService(SbdRepository repository)
    {
        _repository = repository;
    }

    public void SetWeight(DateOnly date, decimal weight)
    {
        _repository.SetWeight(date, weight);
    }

    public decimal? GetWeight(DateOnly date)
        => _repository.GetWeight(date);

    public void RemoveWeight(DateOnly date)
        => _repository.RemoveWeight(date);

    public DiaryWeight[] GetAllWeightData()
        => _repository.GetAllWeightData();
}