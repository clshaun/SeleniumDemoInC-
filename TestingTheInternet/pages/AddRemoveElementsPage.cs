using OpenQA.Selenium;
using System;
using System.Collections.Generic;


namespace TestingTheInternet.pages
{
    public class AddRemoveElementsPage
    {
        public static void Goto()
        {
            Browser.WebDriver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
        }

        public static void ClickAddElement()
        {
            var el = Browser.FindAllMatchingElements(how: "xpath", path: "//button[contains(text(), 'Add Element')]");
            el[0].Click();
        }

        public static int CreateRandomAmountOfElementBoxes()
        {
            Random rnd = new Random();
            int range = rnd.Next(1, 30);
            for (int i = 0; i < range; i++)
            {
                ClickAddElement();
            }
            return range;
        }

        public static IList<IWebElement> GetAllNewElements()
        {
            var els = Browser.FindAllMatchingElements(how: "css", path: "button.added-manually");
            return els;
        }

        public static void DeleteAllElements()
        {
            var els = Browser.FindAllMatchingElements(how: "css", path: "button.added-manually");
            foreach (var el in els)
            {
                el.Click();
            }
        }
    }
}
