﻿using System.Diagnostics;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain
{
    public enum Goal
    {
        Unknown = 0,
        Reached,
        Missed,
    }

    [DebuggerDisplay("{Day} - Kcal:{Kcal} Macros:{Macros} Protein:{Protein} Neat:{Neat} Sleep:{Sleep}")]
    public class DailyGoals : IDateRecord
    {
        public DailyGoals()
        {
        }

        public DailyGoals(DateOnly day)
        {
            Day = day;
        }

        public DateOnly Day { get; init; }
        public Goal Kcal { get; set; } = Goal.Unknown;
        public Goal Macros { get; set; } = Goal.Unknown;
        public Goal Protein { get; set; } = Goal.Unknown;
        public Goal Neat { get; set; } = Goal.Unknown;
        public Goal Sleep { get; set; } = Goal.Unknown;

        public bool AllUnknown
            => Kcal == Goal.Unknown && Macros == Goal.Unknown
                                    && Protein == Goal.Unknown && Neat == Goal.Unknown
                                    && Sleep == Goal.Unknown;
    }
}