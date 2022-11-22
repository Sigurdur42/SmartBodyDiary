using FluentAssertions;
using SmartBodyDiaryDomain.Import;
using SmartBodyDomain.Tests.Steps;

namespace SmartBodyDomain.Tests;

[Binding]
public class ImportFitAndLiftSteps
{
    private readonly SbdScenarioContext _context;

    public ImportFitAndLiftSteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Then(@"This diary data is found")]
    public void ThenThisDiaryDataIsFound(Table table)
    {
        foreach (var row in table.Rows)
        {
            var expectedWeight = row["Weight"];
            var expectedGym = row["GymSession"];
            var expectedNeat = row["NeatGoal"];
            var expectedKcal = row["KcalGoal"];
            var expectedMacro = row["MacroGoal"];
            var expectedSleep = row["SleepGoal"];
            var expectedProtein = row["ProteinGoal"];

            var date = row["Day"].ToDateOnlyDE();

            var weightRecord = _context.FitAndLiftImportResult.Weights.FindByDate(date, !string.IsNullOrWhiteSpace(expectedWeight));
            weightRecord?.Weight.Should().Be(expectedWeight.ToDecimalDE(), $"Day: {date}");

            var gymRecord = _context.FitAndLiftImportResult.GymSessions.FindByDate(date, !string.IsNullOrWhiteSpace(expectedGym));
            gymRecord?.Progress.Should().Be(expectedGym.ToGymProgress(), $"Day: {date}");

            var anyGoalExpected = !string.IsNullOrWhiteSpace(expectedNeat) || !string.IsNullOrWhiteSpace(expectedKcal) || !string.IsNullOrWhiteSpace(expectedMacro) || !string.IsNullOrWhiteSpace(expectedKcal) || !string.IsNullOrWhiteSpace(expectedSleep);
            var goalRecord = _context.FitAndLiftImportResult.DailyGoals.FindByDate(date, anyGoalExpected);
            if (goalRecord != null)
            {
                goalRecord.Neat.Should().Be(expectedNeat.ToGoal(), $"Day: {date} Neat");
                goalRecord.Kcal.Should().Be(expectedKcal.ToGoal(), $"Day: {date} Kcal");
                goalRecord.Macros.Should().Be(expectedMacro.ToGoal(), $"Day: {date} Macros");
                goalRecord.Sleep.Should().Be(expectedSleep.ToGoal(), $"Day: {date} Sleep");
                goalRecord.Protein.Should().Be(expectedProtein.ToGoal(), $"Day: {date} Protein");
            }
        }
    }

    [Given(@"The file '(.*)' is imported from FitAndLift")]
    public void GivenTheFileIsImportedFromFitAndLift(string fileName)
    {
        var inputFile = Path.Combine("TestData", fileName);
        File.Exists(inputFile).Should().BeTrue($"The test file '{fileName}' should exists on hard disc");

        var importer = new FitAndLiftImport();
        _context.FitAndLiftImportResult = importer.Import(new FileInfo(inputFile));
    }

    [Then(@"Loading the import data was successful")]
    public void ThenLoadingTheImportDataWasSuccessful()
    {
        _context.FitAndLiftImportResult.Success.Should().BeTrue();
    }

    [Then(@"This challenge data is found")]
    public void ThenThisChallengeDataIsFound(Table table)
    {
        foreach (var row in table.Rows)
        {
            var expectedTitle = row["Title"];
            var expectedStart = row["Start"];
            var expectedEnd = row["End"];

            var date = row["Day"].ToDateOnlyDE();

            var challengeRecord = _context.FitAndLiftImportResult.Challenges.FindByDate(date, !string.IsNullOrWhiteSpace(expectedStart));
            challengeRecord?.Start.Should().Be(expectedStart.ToDateOnlyDE(), $"Day: {date}");
            challengeRecord?.End.Should().Be(expectedEnd.ToDateOnlyDE(), $"Day: {date}");
            challengeRecord?.Title.Should().Be(expectedTitle, $"Day: {date}");
        }
    }

    [Then(@"This body data is found")]
    public void ThenThisBodyDataIsFound(Table table)
    {
        foreach (var row in table.Rows)
        {
            var expectedLeftArm = row["LeftArm"];
            var expectedRightArm = row["RightArm"];
            var expectedLeftLeg = row["LeftLeg"];
            var expectedRightLeg = row["RightLeg"];
            var expectedShoulder = row["Shoulder"];
            var expectedChest = row["Chest"];
            var expectedBelly = row["Belly"];
            var expectedBellyPlus5 = row["BellyPlus5"];
            var expectedBellyMinus5 = row["BellyMinus5"];
            var expectedHip = row["Hip"];

            var date = row["Day"].ToDateOnlyDE();

            var body = _context.FitAndLiftImportResult.BodyData.FindByDate(date, true);
            body?.Belly.Should().Be(expectedBelly.ToInvariantDE(), $"Day: {date}");
            body?.BellyPlus5.Should().Be(expectedBellyPlus5.ToInvariantDE(), $"Day: {date}");
            body?.BellyMinus5.Should().Be(expectedBellyMinus5.ToInvariantDE(), $"Day: {date}");
            body?.LeftArm.Should().Be(expectedLeftArm.ToInvariantDE(), $"Day: {date}");
            body?.RightArm.Should().Be(expectedRightArm.ToInvariantDE(), $"Day: {date}");
            body?.LeftLeg.Should().Be(expectedLeftLeg.ToInvariantDE(), $"Day: {date}");
            body?.RightLeg.Should().Be(expectedRightLeg.ToInvariantDE(), $"Day: {date}");
            body?.Shoulder.Should().Be(expectedShoulder.ToInvariantDE(), $"Day: {date}");
            body?.Chest.Should().Be(expectedChest.ToInvariantDE(), $"Day: {date}");
            body?.Hip.Should().Be(expectedHip.ToInvariantDE(), $"Day: {date}");
        }
    }
}