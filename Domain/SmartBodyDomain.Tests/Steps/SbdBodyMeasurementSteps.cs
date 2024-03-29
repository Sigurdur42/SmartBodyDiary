﻿using FluentAssertions;
using SmartBodyDiaryDomain;
using SmartBodyDomain.Tests.Steps;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdBodyMeasurementRepositorySteps
{
    private readonly SbdScenarioContext _context;

    private SdbDateBasedRepository<BodyMeasurement> _repository = new();

    private BodyMeasurement _dataToUse = new BodyMeasurement();

    public SbdBodyMeasurementRepositorySteps(SbdScenarioContext context)
    {
        this._context = context;
    }
    [Given(@"An empty body measurement repository has been initialized")]
    public void GivenAnEmptyBodyMeasurementRepositoryHasBeenInitialized()
    {
        _repository = new SdbDateBasedRepository<BodyMeasurement>();
    }

    [Given(@"The measured body data is added to the repository")]
    public void GivenTheMeasureDataIsAddedToTheRepository()
    {
        _repository.AddOrUpdate(_dataToUse);
    }

    [Then(@"Exactly '(.*)' body data record is in the repository")]
    public void ThenExactlyBodyDataRecordIsInTheRepository(int numberOfRecords)
    {
        var result = _repository.Length;
        result.Should().Be(numberOfRecords);
    }

    [Given(@"This data has been measured at '(.*)'")]
    public void GivenThisDataHasBeenMeasuredAt(DateOnly day, Table table)
    {
        _dataToUse = CreateFromTable(day, table);
    }

    private BodyMeasurement CreateFromTable(DateOnly day, Table table)
    {
        var result = new BodyMeasurement(day);
        result.FillFromReflection(table);
        return result;
    }
}