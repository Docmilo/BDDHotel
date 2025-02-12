﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ReqnrollProject1.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SearchForAHotelRoomFeature : object, Xunit.IClassFixture<SearchForAHotelRoomFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Search for a hotel room", "A simple set of scenarios for searching for a hotel room", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "SearchRoom.feature"
#line hidden
        
        public SearchForAHotelRoomFeature(SearchForAHotelRoomFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User enters valid dates")]
        [Xunit.TraitAttribute("FeatureTitle", "Search for a hotel room")]
        [Xunit.TraitAttribute("Description", "User enters valid dates")]
        [Xunit.TraitAttribute("Category", "mytag")]
        public async System.Threading.Tasks.Task UserEntersValidDates()
        {
            string[] tagsOfScenario = new string[] {
                    "mytag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User enters valid dates", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "RoomNo",
                            "Type",
                            "MaxOccupancy",
                            "PricePerNight"});
                table1.AddRow(new string[] {
                            "101",
                            "Single",
                            "1",
                            "�140"});
                table1.AddRow(new string[] {
                            "102",
                            "Single",
                            "1",
                            "�140"});
                table1.AddRow(new string[] {
                            "103",
                            "Double",
                            "2",
                            "�180"});
                table1.AddRow(new string[] {
                            "104",
                            "Double",
                            "3",
                            "�180"});
                table1.AddRow(new string[] {
                            "105",
                            "Double",
                            "3",
                            "�180"});
                table1.AddRow(new string[] {
                            "106",
                            "Suite",
                            "4",
                            "�250"});
#line 9
 await testRunner.GivenAsync("the hotel has the following hotel rooms:", ((string)(null)), table1, "Given ");
#line hidden
#line 17
 await testRunner.AndAsync("a user wants to books a hotel room with a checkIn date of \"17/05/2025\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 18
 await testRunner.AndAsync("a checkOut date of \"19/05/2025\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 19
 await testRunner.AndAsync("selects 2 adults", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 20
 await testRunner.AndAsync("1 child", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
 await testRunner.WhenAsync("the user searches for a hotel room", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "RoomNo",
                            "Type",
                            "MaxOccupancy",
                            "PricePerNight"});
                table2.AddRow(new string[] {
                            "104",
                            "Double",
                            "3",
                            "�180"});
                table2.AddRow(new string[] {
                            "105",
                            "Double",
                            "3",
                            "�180"});
                table2.AddRow(new string[] {
                            "106",
                            "Suite",
                            "4",
                            "�250"});
#line 23
 await testRunner.ThenAsync("the user should be informed that the available rooms are:", ((string)(null)), table2, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await SearchForAHotelRoomFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await SearchForAHotelRoomFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
