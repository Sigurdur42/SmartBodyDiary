using SmartBodyDomain;

namespace SmartBodyDiaryDomain.Import;

public class ImportResult
{
    public bool Success { get; set; }

    public DiaryWeight[] Weights { get; set; } = Array.Empty<DiaryWeight>();
    public GymSession[] GymSessions { get; set; } = Array.Empty<GymSession>();
    public DailyGoals[] DailyGoals { get; set; } = Array.Empty<DailyGoals>();
}