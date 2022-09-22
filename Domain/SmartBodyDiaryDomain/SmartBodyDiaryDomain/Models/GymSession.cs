using System.Diagnostics;

namespace SmartBodyDiaryDomain;

public enum GymProgress
{
    Normal = 0,
    Progress,
    Deload,
}

[DebuggerDisplay("{Day} - {Progress}")]
public class GymSession : IDateRecord
{
    public GymSession()
    {
    }

    public GymSession(DateOnly day)
    {
        Day = day;
    }

    public DateOnly Day { get; init; }

    public GymProgress Progress { get; set; }
}