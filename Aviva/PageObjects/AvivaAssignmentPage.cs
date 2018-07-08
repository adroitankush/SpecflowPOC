using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Aviva
{
    class AvivaAssignmentPage
    {
        public IWebDriver driver;

        public AvivaAssignmentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Page Objects of Google Home Page.........

        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement googleSearchBox;

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement searchButton;

        [FindsBy(How = How.Name, Using = "btnI")]
        private IWebElement iamFeelingLuckyButton;




        //Setters and Getters methods......

        public void openUrl()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            driver.Manage().Window.Maximize();
        }

        public void enterSearchKeyword(String key)
        {
            googleSearchBox.SendKeys(key);
            googleSearchBox.SendKeys(Keys.Tab);
        }

        public void clickOnSearchButton()
        {
            searchButton.Click();
        }

        public int ActualLinks;
        public void verifyNoOfLinksForText(int links, string keyword)
        {
            ICollection<IWebElement> Links =  driver.FindElements(By.XPath(".//a[contains(.,'"+ keyword+"')]"));
            ActualLinks = Links.Count;
            Assert.AreEqual(links, ActualLinks);
          
        }

        public void clickOnLinkWithNumber(int linkNo, String keyword)
        {
            driver.FindElement(By.XPath("(.//a[contains(.,'" + keyword + "')])[" + linkNo + "]")).Click();
        }

        public String actualTitle;
        public void verifyPageTitle(String expectedTitle)
        {
            WebDriverWait wd = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wd.Until(ExpectedConditions.TitleContains(expectedTitle));
            actualTitle =driver.Title;
            Assert.AreEqual(expectedTitle,actualTitle);
        }

        public void clickOnIamFeelingLuckyButton()
        {
            WebDriverWait wd = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wd.Until(ExpectedConditions.ElementToBeClickable(iamFeelingLuckyButton));
            iamFeelingLuckyButton.Click();
        }

        public void verifyNoOfLinksNotPresentForText(int links, string keyword)
        {
            ICollection<IWebElement> Links = driver.FindElements(By.XPath(".//a[contains(.,'" + keyword + "')]"));
            ActualLinks = Links.Count;
            Assert.AreNotEqual(links, ActualLinks);

        }

        public void verifyLinkNotPresent(int linkNo, String keyword)
        {
            ICollection<IWebElement> Links = driver.FindElements(By.XPath(".//a[contains(.,'" + keyword + "')]"));
            ActualLinks = Links.Count;
            Assert.AreEqual(0, ActualLinks);
        }

        public void verifyPageTitleNotSame(String expectedTitle)
        {
            WebDriverWait wd = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wd.Until(ExpectedConditions.TitleContains(expectedTitle));
            actualTitle = driver.Title;
            Assert.AreNotSame(expectedTitle, actualTitle);
        }
    }
}
