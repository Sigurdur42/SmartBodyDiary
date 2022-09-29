using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain;
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
            weightRecord?.Weight.Should().Be(expectedWeight.ToDecimalDE(),$"Day: {date}");

            var gymRecord = _context.FitAndLiftImportResult.GymSessions.FindByDate(date, !string.IsNullOrWhiteSpace(expectedGym));
            gymRecord?.Progress.Should().Be(expectedGym.ToGymProgress(), $"Day: {date}");

            var anyGoalExpected = !string.IsNullOrWhiteSpace(expectedNeat) || !string.IsNullOrWhiteSpace(expectedKcal) || !string.IsNullOrWhiteSpace(expectedMacro) || !string.IsNullOrWhiteSpace(expectedKcal) || !string.IsNullOrWhiteSpace(expectedSleep); 
            var goalRecord = _context.FitAndLiftImportResult.DailyGoals.FindByDate(date, anyGoalExpected);
            if (goalRecord != null)
            {
                goalRecord.Neat.Should().Be(expectedNeat.ToGoal(),$"Day: {date} Neat");
                goalRecord.Kcal.Should().Be(expectedKcal.ToGoal(),$"Day: {date} Kcal");
                goalRecord.Macros.Should().Be(expectedMacro.ToGoal(),$"Day: {date} Macros");
                goalRecord.Sleep.Should().Be(expectedSleep.ToGoal(),$"Day: {date} Sleep");
                goalRecord.Protein.Should().Be(expectedProtein.ToGoal(),$"Day: {date} Protein");
            }

            // TODO: body weight
            // TODO: Challenge
            // TODO: Settings
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
}