using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace TestingTheInternet.pages
{
    public class Browser
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        private static WebDriverWait _wait;

        public static void Start()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public static void Maximize()
        {
            WebDriver.Manage().Window.Maximize();
        }

        public static IWebDriver WebDriver => _driver;

        public static WebDriverWait Wait(int timeout = 5, params Type[] ignoreExceptions)
        {
            var wait = _wait;

            if (timeout <= 0)
            {
                // use default _wait
            }
            else if (timeout >= 1)
            {
                wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
                wait.IgnoreExceptionTypes(ignoreExceptions);
            }

            return wait;
        }

        public static IList<IWebElement> FindAllMatchingElements(string how, string path, bool waitUntilFound = true, int timeout = 5)
        {
            ReadOnlyCollection<IWebElement> elements = null;

            By by = null;

            if (how == "css")
            {
                by = By.CssSelector(path);
            }
            else if (how == "xpath")
            {
                by = By.XPath(path);
            }

            if (waitUntilFound)
            {
                Wait(timeout, ignoreExceptions: typeof(TimeoutException)).Until(drvr => drvr.FindElements(by).Count > 0);
                elements = WebDriver.FindElements(by);
            }
            else
            {
                elements = WebDriver.FindElements(by);
            }

            return elements;
        }

        public static void Quit()
        {
            WebDriver.Quit();
        }


    }
}
