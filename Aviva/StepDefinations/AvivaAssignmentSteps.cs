using System;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Aviva
{ 
    [Binding]
    public class AvivaAssignmentSteps
    {
        static IWebDriver driver = new ChromeDriver();
        AvivaAssignmentPage page = new AvivaAssignmentPage(driver);
        ScreenCapture screenCapture = new ScreenCapture();
        public ExtentReports extent = ExtentManager.getInstance(FeatureContext.Current.FeatureInfo.Title);
        ExtentTest test;

        [BeforeScenario]
        public void Initialize()
        {
            test = extent.CreateTest("Scenario: " + ScenarioContext.Current.ScenarioInfo.Title);
            test.AssignAuthor(Environment.UserName.ToString());
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--lang=es");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
        }

        [AfterScenario]
        public void Cleanup()
        {
            extent.Flush();
        }

        [AfterTestRun]
        public static void clean()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Given(@"I am on Google Search page")]
        public void GivenIAmOnGoogleSearchPage()
        {
            try
            {
                page.openUrl();
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Successfully Opened URL");
               
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Unable to open URL " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
        }

        [Given(@"I enter search (.*)")]
        public void GivenIEnterSearch(string keyword)
        {
            try
            {
                page.enterSearchKeyword(keyword);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Successfully Entered Search Keyword As " + keyword);
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Unable to Enter Search Keyword As " + keyword + " " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {
            try
            {
                page.clickOnSearchButton();
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Successfully Clicked On Search Button");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                 + "Unable to click On Search Button " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
           
        }

        [Then(@"Search result should contain (.*) with (.*)")]
        public void ThenSearchResultShouldContainWith(int links, string keyword)
        {
            try
            {
                page.verifyNoOfLinksForText(links, keyword);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected Links: " + links + " " + "Actual Links: " + page.ActualLinks + " " +"Are Equal.");
                extent.Flush();
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected Links: " + links + " " + "Actual Links: " + page.ActualLinks + " " + "Are Not Equal." + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
        }

        [When(@"I click on specfied (.*) with (.*)")]
        public void WhenIClickOnSpeficied(int linkNo, String keyword)
        {
            try
            {
                page.clickOnLinkWithNumber(linkNo, keyword);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Successfully clicked on link with no " + linkNo);
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Unable to click on link with no " + linkNo + " " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
        }

        [Then(@"I should see page with (.*)")]
        public void ThenIShouldSeePageIWith(String title)
        {
            try
            {
                page.verifyPageTitle(title);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected and Actual titles are matching. Expected Title :" + title);
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected and Actual titles are not matching." + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
        }

        [Given(@"I click on I'm Feeling Lucky Button instead")]
        public void GivenIClickOnIMFeelingLuckyButtonInstead()
        {
            try
            {
                page.clickOnIamFeelingLuckyButton();
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Successfully Clicked On I'am Feeling Lucky Button");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                 + "Unable to click On I'am Feeling Lucky Button " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
            
        }

        [Then(@"I should not see search result containing (.*) with (.*)")]
        public void ThenIShouldNotSeeSearchResulContainingWithAviva(int links,String keyword)
        {
            try
            {
                page.verifyNoOfLinksNotPresentForText(links, keyword);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected Links: " + links + " " + "Actual Links: " + page.ActualLinks + " " + "Are Not Equal as Expected");
                extent.Flush();
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Expected Links: " + links + " " + "Actual Links: " + page.ActualLinks + " " + "Are Equal. Not Expected" + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
            
        }

        [Then(@"I should not be able to click on (.*) with (.*)")]
        public void ThenIShouldNotBeAbleToClickOnWithAviva(int linkNo,String keyword)
        {
            try
            {
                page.verifyLinkNotPresent(linkNo, keyword);
                test.Log(Status.Pass, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Unable to click on link with no as Expected " + linkNo);
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioStepContext.Current.StepInfo.Text
                    + "-Able to click on link with no " + linkNo + "Not Expected " + e);
                test.AddScreenCaptureFromPath(screenCapture.TakeScreenshot(page.driver));
            }
            
        }

       
    }
}
