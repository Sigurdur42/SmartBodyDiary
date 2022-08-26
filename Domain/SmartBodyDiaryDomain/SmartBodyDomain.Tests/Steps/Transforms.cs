using System.Globalization;
using SmartBodyDiaryDomain;
using TechTalk.SpecFlow.Assist;

namespace SmartBodyDomain.Tests.Steps;

[Binding]
public class Transforms
{
    [StepArgumentTransformation]
    public DateOnly DateOnlyTransform(string date)
        => date.ToDateOnlyDE();

    [StepArgumentTransformation]
    public IEnumerable<DiaryWeight> DiaryWeightTransformTable(Table table)
    {
        var result = 
            (from row in table.Rows let date = row[0].ToDateOnlyDE() 
             select new DiaryWeight(date, Decimal.Parse(row[1], NumberStyles.Any, StepExtensions.English)))
            .ToList();

        return result.OrderBy(_ => _.Day).ToArray();
    }
}