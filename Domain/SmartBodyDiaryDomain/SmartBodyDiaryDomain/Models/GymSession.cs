using SmartBodyDiaryDomain;

namespace SmartBodyDomain;

public enum GymProgress
{
    Normal = 0,
    Progress,
    Deload,
}

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