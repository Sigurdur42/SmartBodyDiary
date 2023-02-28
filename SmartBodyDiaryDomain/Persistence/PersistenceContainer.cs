namespace SmartBodyDiaryDomain;

public class PersistenceContainer
{
    public DiaryWeight[] Weights { get; set; } = Array.Empty<DiaryWeight>();
    public GymSession[] GymSessions { get; set; } = Array.Empty<GymSession>();
    public Challenge[] Challenges { get; set; } = Array.Empty<Challenge>();
    public BodyMeasurement[] BodyData { get; set; } = Array.Empty<BodyMeasurement>();
    public DailyGoals[] DailyGoals { get; set; } = Array.Empty<DailyGoals>();
}