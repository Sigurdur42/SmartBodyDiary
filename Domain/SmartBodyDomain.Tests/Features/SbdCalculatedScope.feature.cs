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
    [NUnit.Framework.DescriptionAttribute("SbdCalculatedScope - Verifies all kinds of scope calculations")]
    public partial class SbdCalculatedScope_VerifiesAllKindsOfScopeCalculationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "SbdCalculatedScope.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "SbdCalculatedScope - Verifies all kinds of scope calculations", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Day",
                        "Weight",
                        "Comment"});
            table5.AddRow(new string[] {
                        "2020-08-18",
                        "82.5",
                        "Start of week 1"});
            table5.AddRow(new string[] {
                        "2020-08-19",
                        "83.5",
                        ""});
            table5.AddRow(new string[] {
                        "2020-08-20",
                        "83.5",
                        ""});
            table5.AddRow(new string[] {
                        "2020-08-21",
                        "84.5",
                        ""});
            table5.AddRow(new string[] {
                        "2020-08-22",
                        "81.5",
                        ""});
            table5.AddRow(new string[] {
                        "2020-08-24",
                        "85.2",
                        ""});
            table5.AddRow(new string[] {
                        "2020-08-25",
                        "87.7",
                        "End of week 1"});
            table5.AddRow(new string[] {
                        "2020-08-30",
                        "87.7",
                        ""});
            table5.AddRow(new string[] {
                        "2020-09-01",
                        "87.7",
                        ""});
#line 5
        testRunner.Given("These weight records are available", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Day",
                        "GymProgress",
                        "Comment"});
            table6.AddRow(new string[] {
                        "2020-08-18",
                        "Normal",
                        "Start of week 1"});
            table6.AddRow(new string[] {
                        "2020-08-19",
                        "Progress",
                        ""});
            table6.AddRow(new string[] {
                        "2020-08-20",
                        "Progress",
                        ""});
            table6.AddRow(new string[] {
                        "2020-08-26",
                        "Progress",
                        "Not in week 1"});
#line 16
        testRunner.Given("These gym sessions are available", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Day",
                        "Neat",
                        "Sleep",
                        "Macros",
                        "Kcal",
                        "Protein",
                        "Comment"});
            table7.AddRow(new string[] {
                        "18.08.2020",
                        "Reached",
                        "Unknown",
                        "Missed",
                        "Reached",
                        "Missed",
                        "Start week 1"});
            table7.AddRow(new string[] {
                        "25.08.2020",
                        "Reached",
                        "Unknown",
                        "Missed",
                        "Reached",
                        "Reached",
                        "End week 1"});
#line 22
        testRunner.And("These daily goals shall be used", ((string)(null)), table7, "And ");
#line hidden
#line 26
        testRunner.And("The given data is set in the repository", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
        testRunner.And("The sliding weight has been calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate weekly scope when all data is present")]
        public virtual void CalculateWeeklyScopeWhenAllDataIsPresent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate weekly scope when all data is present", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 29
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
#line 30
        testRunner.Given("The scope shall be calculated from \'18.08.2020\' to \'25.08.2020\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 31
        testRunner.Then("The weight diff shall be \'5.2\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
        testRunner.Then("The sliding weight diff shall be \'1.56\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
        testRunner.And("There must be \'7\' weight records in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
        testRunner.And("There must be \'3\' gym sessions in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Neat",
                            "Sleep",
                            "Macros",
                            "Kcal",
                            "Protein"});
                table8.AddRow(new string[] {
                            "7/2/0",
                            "7/0/0",
                            "7/0/2",
                            "7/2/0",
                            "7/1/1"});
#line 35
        testRunner.And("There must be this daily goal summary", ((string)(null)), table8, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate weekly scope when no data is present")]
        public virtual void CalculateWeeklyScopeWhenNoDataIsPresent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate weekly scope when no data is present", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 39
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
#line 40
        testRunner.Given("The scope shall be calculated from \'18.08.2018\' to \'25.08.2018\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
        testRunner.Then("The weight diff shall be \'0\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
        testRunner.Then("The sliding weight diff shall be \'0\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
        testRunner.And("There must be \'0\' weight records in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
        testRunner.And("There must be \'0\' gym sessions in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Neat",
                            "Sleep",
                            "Macros",
                            "Kcal",
                            "Protein"});
                table9.AddRow(new string[] {
                            "0/0/0",
                            "0/0/0",
                            "0/0/0",
                            "0/0/0",
                            "0/0/0"});
#line 45
        testRunner.And("There must be this daily goal summary", ((string)(null)), table9, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate weekly scope when a single data point is present")]
        public virtual void CalculateWeeklyScopeWhenASingleDataPointIsPresent()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate weekly scope when a single data point is present", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 49
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
#line 50
        testRunner.Given("The scope shall be calculated from \'18.08.2018\' to \'18.08.2020\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
        testRunner.Then("The weight diff shall be \'0\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
        testRunner.Then("The sliding weight diff shall be \'0\' kg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 53
        testRunner.And("There must be \'1\' weight records in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
        testRunner.And("There must be \'1\' gym sessions in scope result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Neat",
                            "Sleep",
                            "Macros",
                            "Kcal",
                            "Protein"});
                table10.AddRow(new string[] {
                            "731/1/0",
                            "731/0/0",
                            "731/0/1",
                            "731/1/0",
                            "731/0/1"});
#line 55
        testRunner.And("There must be this daily goal summary", ((string)(null)), table10, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
