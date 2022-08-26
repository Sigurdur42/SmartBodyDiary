namespace SmartBodyDiaryDomain;

public class SbdDomainService
{
    private readonly SbdMemoryRepository _memoryRepository;

    public SbdDomainService(SbdMemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }

    public void SetWeight(DateOnly date, decimal weight)
    {
        _memoryRepository.SetWeight(date, weight);
    }

    public decimal? GetWeight(DateOnly date)
        => _memoryRepository.GetWeight(date);
}