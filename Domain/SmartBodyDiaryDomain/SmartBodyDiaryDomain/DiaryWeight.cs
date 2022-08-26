﻿namespace SmartBodyDiaryDomain;

public class DiaryWeight : IDateRecord
{
    public DiaryWeight() {}

    public DiaryWeight(DateOnly day, decimal weight)
    {
        Day = day;
        Weight = weight;
    }
    public DateOnly Day { get; init; }
    public decimal Weight { get; init; }
}