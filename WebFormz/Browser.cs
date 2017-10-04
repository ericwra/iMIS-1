using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormz.Interfaces;

namespace WebFormz
{
    class Browser : IBrowser
    {
        private PhantomJSDriver browser;
        private WebDriverWait wait;


        public Browser(int secondsToWait)
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.AddArgument("--webdriver-loglevel=None");
            browser = new PhantomJSDriver(service);
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(secondsToWait);
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(secondsToWait));
        }

        public void Click(string xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            browser.FindElementByXPath(xpath).Click();
        }

        public void SendKeys(string xpath, string text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            browser.FindElementByXPath(xpath).SendKeys(text);
        }

        public void GoToUrl(string url)
        {
            browser.Navigate().GoToUrl(url);
        }

        public bool IsChecked(string xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            return browser.FindElementByXPath(xpath).Selected;
        }

        public string GetText(string xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

            return browser.FindElementByXPath(xpath).Text;
        }

        public string GetTitle()
        {
            return browser.Title;
        }

        public string GetPageSource()
        {
            return browser.PageSource;
        }
    }
}
