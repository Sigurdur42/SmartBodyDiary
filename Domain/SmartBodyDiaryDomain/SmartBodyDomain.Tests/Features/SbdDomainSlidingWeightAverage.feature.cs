﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SmartBodyDomain.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify the calculation of average sliding weight data")]
    public partial class VerifyTheCalculationOfAverageSlidingWeightDataFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "SbdDomainSlidingWeightAverage.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Verify the calculation of average sliding weight data", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
    #line hidden
#line 4
        testRunner.Given("The average sliding calculator is used", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Day",
                        "Weight"});
            table6.AddRow(new string[] {
                        "2020-08-25",
                        "87.5"});
            table6.AddRow(new string[] {
                        "2020-08-26",
                        "87.9"});
            table6.AddRow(new string[] {
                        "2020-08-27",
                        "87.7"});
            table6.AddRow(new string[] {
                        "2020-08-28",
                        "87.6"});
            table6.AddRow(new string[] {
                        "2020-08-29",
                        "87.2"});
            table6.AddRow(new string[] {
                        "2020-08-30",
                        "87.4"});
            table6.AddRow(new string[] {
                        "2020-08-31",
                        "87.5"});
            table6.AddRow(new string[] {
                        "2020-09-01",
                        "88.7"});
            table6.AddRow(new string[] {
                        "2020-09-02",
                        "87.7"});
            table6.AddRow(new string[] {
                        "2020-09-03",
                        "87.2"});
            table6.AddRow(new string[] {
                        "2020-09-04",
                        "87.0"});
            table6.AddRow(new string[] {
                        "2020-09-05",
                        "86.4"});
            table6.AddRow(new string[] {
                        "2020-09-06",
                        "86.3"});
            table6.AddRow(new string[] {
                        "2020-09-07",
                        "86.9"});
            table6.AddRow(new string[] {
                        "2020-09-08",
                        "86.6"});
            table6.AddRow(new string[] {
                        "2020-09-09",
                        "86.5"});
            table6.AddRow(new string[] {
                        "2020-09-10",
                        "86.6"});
            table6.AddRow(new string[] {
                        "2020-09-11",
                        "87.1"});
            table6.AddRow(new string[] {
                        "2020-09-12",
                        "86.6"});
            table6.AddRow(new string[] {
                        "2020-09-13",
                        "86.8"});
            table6.AddRow(new string[] {
                        "2020-09-14",
                        "88.0"});
            table6.AddRow(new string[] {
                        "2020-09-15",
                        "86.4"});
            table6.AddRow(new string[] {
                        "2020-09-16",
                        "86.0"});
            table6.AddRow(new string[] {
                        "2020-09-17",
                        "86.4"});
            table6.AddRow(new string[] {
                        "2020-09-18",
                        "85.9"});
            table6.AddRow(new string[] {
                        "2020-09-19",
                        "86.7"});
            table6.AddRow(new string[] {
                        "2020-09-20",
                        "86.2"});
            table6.AddRow(new string[] {
                        "2020-09-21",
                        "85.7"});
            table6.AddRow(new string[] {
                        "2020-09-22",
                        "86.6"});
            table6.AddRow(new string[] {
                        "2020-09-23",
                        "86.5"});
            table6.AddRow(new string[] {
                        "2020-09-24",
                        "86.1"});
            table6.AddRow(new string[] {
                        "2020-09-25",
                        "85.6"});
            table6.AddRow(new string[] {
                        "2020-09-28",
                        "85.5"});
            table6.AddRow(new string[] {
                        "2020-09-30",
                        "85.5"});
            table6.AddRow(new string[] {
                        "2020-10-01",
                        "85.3"});
            table6.AddRow(new string[] {
                        "2020-10-02",
                        "84.9"});
            table6.AddRow(new string[] {
                        "2020-10-03",
                        "84.3"});
            table6.AddRow(new string[] {
                        "2020-10-05",
                        "85.6"});
            table6.AddRow(new string[] {
                        "2020-10-06",
                        "85.3"});
            table6.AddRow(new string[] {
                        "2020-10-07",
                        "85.8"});
            table6.AddRow(new string[] {
                        "2020-10-08",
                        "85.8"});
            table6.AddRow(new string[] {
                        "2020-10-09",
                        "85.7"});
            table6.AddRow(new string[] {
                        "2020-10-10",
                        "84.7"});
            table6.AddRow(new string[] {
                        "2020-10-11",
                        "84.5"});
            table6.AddRow(new string[] {
                        "2020-10-12",
                        "85.0"});
            table6.AddRow(new string[] {
                        "2020-10-13",
                        "85.4"});
            table6.AddRow(new string[] {
                        "2020-10-15",
                        "84.1"});
            table6.AddRow(new string[] {
                        "2020-10-16",
                        "85.6"});
            table6.AddRow(new string[] {
                        "2020-10-17",
                        "84.4"});
            table6.AddRow(new string[] {
                        "2020-10-18",
                        "84.3"});
            table6.AddRow(new string[] {
                        "2020-10-20",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2020-10-21",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2020-10-22",
                        "84.1"});
            table6.AddRow(new string[] {
                        "2020-10-23",
                        "84.1"});
            table6.AddRow(new string[] {
                        "2020-10-25",
                        "83.4"});
            table6.AddRow(new string[] {
                        "2020-10-26",
                        "83.3"});
            table6.AddRow(new string[] {
                        "2020-10-27",
                        "83.7"});
            table6.AddRow(new string[] {
                        "2020-10-28",
                        "83.7"});
            table6.AddRow(new string[] {
                        "2020-10-29",
                        "84.4"});
            table6.AddRow(new string[] {
                        "2020-10-30",
                        "84.0"});
            table6.AddRow(new string[] {
                        "2020-11-01",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2020-11-03",
                        "83.2"});
            table6.AddRow(new string[] {
                        "2020-11-04",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2020-11-05",
                        "83.3"});
            table6.AddRow(new string[] {
                        "2020-11-06",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2020-11-07",
                        "83.3"});
            table6.AddRow(new string[] {
                        "2020-11-08",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2020-11-09",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2020-11-10",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2020-11-12",
                        "82.9"});
            table6.AddRow(new string[] {
                        "2020-11-13",
                        "82.7"});
            table6.AddRow(new string[] {
                        "2020-11-14",
                        "83.1"});
            table6.AddRow(new string[] {
                        "2020-11-16",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2020-11-17",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2020-11-18",
                        "82.2"});
            table6.AddRow(new string[] {
                        "2020-11-19",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2020-11-20",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2020-11-22",
                        "83.0"});
            table6.AddRow(new string[] {
                        "2020-11-23",
                        "82.9"});
            table6.AddRow(new string[] {
                        "2020-11-24",
                        "83.1"});
            table6.AddRow(new string[] {
                        "2020-11-26",
                        "82.9"});
            table6.AddRow(new string[] {
                        "2020-11-27",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2020-11-28",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2020-11-29",
                        "83.9"});
            table6.AddRow(new string[] {
                        "2020-12-01",
                        "83.5"});
            table6.AddRow(new string[] {
                        "2020-12-02",
                        "82.7"});
            table6.AddRow(new string[] {
                        "2020-12-04",
                        "83.3"});
            table6.AddRow(new string[] {
                        "2020-12-07",
                        "83.3"});
            table6.AddRow(new string[] {
                        "2020-12-09",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2020-12-10",
                        "83.5"});
            table6.AddRow(new string[] {
                        "2020-12-11",
                        "83.9"});
            table6.AddRow(new string[] {
                        "2020-12-12",
                        "84.0"});
            table6.AddRow(new string[] {
                        "2020-12-15",
                        "83.4"});
            table6.AddRow(new string[] {
                        "2020-12-18",
                        "84.6"});
            table6.AddRow(new string[] {
                        "2020-12-27",
                        "85.4"});
            table6.AddRow(new string[] {
                        "2020-12-29",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-01-01",
                        "85.1"});
            table6.AddRow(new string[] {
                        "2021-01-02",
                        "85.2"});
            table6.AddRow(new string[] {
                        "2021-01-03",
                        "84.0"});
            table6.AddRow(new string[] {
                        "2021-01-04",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-01-05",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-01-06",
                        "84.1"});
            table6.AddRow(new string[] {
                        "2021-01-08",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2021-01-09",
                        "84.6"});
            table6.AddRow(new string[] {
                        "2021-01-10",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-01-11",
                        "83.9"});
            table6.AddRow(new string[] {
                        "2021-01-12",
                        "83.6"});
            table6.AddRow(new string[] {
                        "2021-01-13",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2021-01-14",
                        "84.0"});
            table6.AddRow(new string[] {
                        "2021-01-18",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-01-25",
                        "83.9"});
            table6.AddRow(new string[] {
                        "2021-01-29",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-02-09",
                        "85.6"});
            table6.AddRow(new string[] {
                        "2021-02-10",
                        "84.2"});
            table6.AddRow(new string[] {
                        "2021-04-24",
                        "83.8"});
            table6.AddRow(new string[] {
                        "2021-04-26",
                        "84.3"});
            table6.AddRow(new string[] {
                        "2021-04-27",
                        "83.2"});
            table6.AddRow(new string[] {
                        "2021-04-30",
                        "83.9"});
            table6.AddRow(new string[] {
                        "2021-05-01",
                        "83.5"});
            table6.AddRow(new string[] {
                        "2021-05-03",
                        "83.1"});
            table6.AddRow(new string[] {
                        "2021-05-05",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2021-05-06",
                        "83.2"});
            table6.AddRow(new string[] {
                        "2021-05-07",
                        "83.7"});
            table6.AddRow(new string[] {
                        "2021-05-08",
                        "83.4"});
            table6.AddRow(new string[] {
                        "2021-05-10",
                        "82.8"});
            table6.AddRow(new string[] {
                        "2021-05-12",
                        "82.3"});
            table6.AddRow(new string[] {
                        "2021-05-13",
                        "82.0"});
            table6.AddRow(new string[] {
                        "2021-05-14",
                        "83.5"});
            table6.AddRow(new string[] {
                        "2021-05-15",
                        "82.6"});
            table6.AddRow(new string[] {
                        "2021-05-16",
                        "82.1"});
            table6.AddRow(new string[] {
                        "2021-05-17",
                        "82.1"});
            table6.AddRow(new string[] {
                        "2021-05-18",
                        "82.5"});
            table6.AddRow(new string[] {
                        "2021-05-19",
                        "82.5"});
            table6.AddRow(new string[] {
                        "2021-05-20",
                        "82.1"});
            table6.AddRow(new string[] {
                        "2021-05-22",
                        "81.2"});
            table6.AddRow(new string[] {
                        "2021-05-23",
                        "82.0"});
            table6.AddRow(new string[] {
                        "2021-05-24",
                        "82.3"});
            table6.AddRow(new string[] {
                        "2021-05-25",
                        "82.8"});
            table6.AddRow(new string[] {
                        "2021-05-26",
                        "82.2"});
            table6.AddRow(new string[] {
                        "2021-05-27",
                        "81.9"});
            table6.AddRow(new string[] {
                        "2021-05-28",
                        "82.2"});
            table6.AddRow(new string[] {
                        "2021-05-30",
                        "80.8"});
            table6.AddRow(new string[] {
                        "2021-05-31",
                        "81.3"});
            table6.AddRow(new string[] {
                        "2021-06-01",
                        "81.1"});
            table6.AddRow(new string[] {
                        "2021-06-02",
                        "81.1"});
            table6.AddRow(new string[] {
                        "2021-06-03",
                        "81.2"});
            table6.AddRow(new string[] {
                        "2021-06-04",
                        "81.2"});
            table6.AddRow(new string[] {
                        "2021-06-05",
                        "81.8"});
            table6.AddRow(new string[] {
                        "2021-06-06",
                        "81.2"});
            table6.AddRow(new string[] {
                        "2021-06-07",
                        "81.8"});
            table6.AddRow(new string[] {
                        "2021-06-08",
                        "80.8"});
            table6.AddRow(new string[] {
                        "2021-06-09",
                        "81.1"});
            table6.AddRow(new string[] {
                        "2021-06-10",
                        "80.8"});
#line 5
        testRunner.And("These weight records are available", ((string)(null)), table6, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calling calculate without weight data")]
        public virtual void CallingCalculateWithoutWeightData()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calling calculate without weight data", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 161
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Day",
                            "Weight"});
#line 162
        testRunner.Given("These weight records are available", ((string)(null)), table7, "Given ");
#line hidden
#line 164
        testRunner.Given("the sliding weight is calculated considering \'7\' records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 165
        testRunner.Then("No weight calculation exception occurred", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calling calculate with a single weight record")]
        public virtual void CallingCalculateWithASingleWeightRecord()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calling calculate with a single weight record", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 167
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Day",
                            "Weight"});
                table8.AddRow(new string[] {
                            "2021-06-10",
                            "80.8"});
#line 168
        testRunner.Given("These weight records are available", ((string)(null)), table8, "Given ");
#line hidden
#line 171
        testRunner.Given("the sliding weight is calculated considering \'7\' records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 172
        testRunner.Then("The sliding weight for \'10.06.2021\' is \'80.8\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the average weight on a given day")]
        public virtual void VerifyTheAverageWeightOnAGivenDay()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the average weight on a given day", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 174
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
#line 175
        testRunner.Given("the sliding weight is calculated considering \'7\' records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 176
        testRunner.Then("The sliding weight for \'09.06.2021\' is \'81.30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify the average weight on a given day is correct after multiple calculation ca" +
            "lls")]
        public virtual void VerifyTheAverageWeightOnAGivenDayIsCorrectAfterMultipleCalculationCalls()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the average weight on a given day is correct after multiple calculation ca" +
                    "lls", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 178
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
#line 179
        testRunner.Given("the sliding weight is calculated considering \'7\' records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 180
        testRunner.Then("The sliding weight for \'09.06.2021\' is \'81.30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 181
        testRunner.Given("the sliding weight is calculated considering \'7\' records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 182
        testRunner.Then("The sliding weight for \'09.06.2021\' is \'81.30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
