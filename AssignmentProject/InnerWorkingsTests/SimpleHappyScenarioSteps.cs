using System;
using TechTalk.SpecFlow;

namespace InnerWorkingsTests
{
    // TODO: moq IOutputAdapter method and test input argument for passed values.

    [Binding]
    public class SimpleHappyScenarioSteps
    {
        [Given(@"the following items in the job")]
        public void GivenTheFollowingItemsInTheJob(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"following tax is '(.*)'")]
        public void GivenFollowingTaxIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"BaseMargin is '(.*)'")]
        public void GivenBaseMarginIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ExtraMargin is '(.*)'")]
        public void GivenExtraMarginIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I process job")]
        public void WhenIProcessJob()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be as bellow")]
        public void ThenTheResultShouldBeAsBellow(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
