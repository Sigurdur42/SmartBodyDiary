namespace SmartBodyDiaryDomain;

public class CalculatedScope
{
    public decimal WeightDiff { get; set; }
    public DiaryWeight[] Weights { get; internal set; } = Array.Empty<DiaryWeight>();
}