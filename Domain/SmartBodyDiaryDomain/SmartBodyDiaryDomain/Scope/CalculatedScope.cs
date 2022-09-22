namespace SmartBodyDiaryDomain;

public class CalculatedScope
{
    public decimal WeightDiff { get; set; }
    public decimal WeightDiffSliding { get; internal set; }
    public SlidingWeight[] Weights { get; internal set; } = Array.Empty<SlidingWeight>();
    public GymSession[] GymSessions { get; internal set; }= Array.Empty<GymSession>();
}