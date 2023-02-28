namespace SmartBodyDiaryDomain;

public class DailyGoalsSummary
{
    public DailyGoalsSummary()
    {
    }

    public DailyGoalsSummary(IEnumerable<DailyGoals> goals, int targetDays)
    {
        foreach (var goal in goals)
        {
            Assign(Kcal, goal.Kcal, targetDays);
            Assign(Neat, goal.Neat, targetDays);
            Assign(Sleep, goal.Sleep, targetDays);
            Assign(Protein, goal.Protein, targetDays);
            Assign(Macros, goal.Macros, targetDays);
        }
    }

    public SingleGoalSummary Kcal { get; init; } = new();
    public SingleGoalSummary Neat { get; init; } = new();
    public SingleGoalSummary Sleep { get; init; } = new();
    public SingleGoalSummary Protein { get; init; } = new();
    public SingleGoalSummary Macros { get; init; } = new();

    public override bool Equals(object? obj)
    {
        if (obj is DailyGoalsSummary rhs)
        {
            return Kcal.Equals(rhs.Kcal)
                   && Neat.Equals(rhs.Neat)
                   && Sleep.Equals(rhs.Sleep)
                   && Protein.Equals(rhs.Protein)
                   && Macros.Equals(rhs.Macros);
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Kcal, Neat, Sleep, Protein, Macros);
    }

    private static void Assign(SingleGoalSummary target, Goal goal, int targetDays)
    {
        target.Target = targetDays;
        target.Missed += goal == Goal.Missed ? 1 : 0;
        target.Reached += goal == Goal.Reached ? 1 : 0;
    }
}