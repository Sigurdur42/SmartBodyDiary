namespace SmartBodyDiaryDomain;

public class CalculatedScope
{
    public decimal WeightDiff { get; set; }
    public SlidingWeight[] Weights { get; internal set; } = Array.Empty<SlidingWeight>();
    public decimal WeightDiffSliding { get; internal set; }
}