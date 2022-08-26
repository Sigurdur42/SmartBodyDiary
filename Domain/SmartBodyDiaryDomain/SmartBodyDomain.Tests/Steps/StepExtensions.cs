﻿using System.Globalization;

namespace SmartBodyDomain.Tests.Steps;

public static class StepExtensions
{
    public static readonly CultureInfo German = new CultureInfo("de-DE");
    public static readonly CultureInfo English = new CultureInfo("en-US");

    public static DateOnly ToDateOnlyDE(this string input)
    {
        return DateOnly.Parse(input, German, DateTimeStyles.None);
    }
}