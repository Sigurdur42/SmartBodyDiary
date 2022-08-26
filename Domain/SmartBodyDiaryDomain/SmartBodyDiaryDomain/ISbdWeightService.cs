namespace SmartBodyDiaryDomain;

public interface ISbdWeightService
{
    void Calculate(DiaryWeight[] weightData);
    AverageWeight? GetWeight(DateOnly date);
}