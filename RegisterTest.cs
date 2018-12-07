using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class RegisterTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheRegisterTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$ US Dollar'])[1]/following::ul[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Account'])[1]/following::span[1]")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("ana");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("anic");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("ana.anic3@gmail.com");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("098998589");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("123456");
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("123456");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Privacy Policy'])[1]/following::input[2]")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
