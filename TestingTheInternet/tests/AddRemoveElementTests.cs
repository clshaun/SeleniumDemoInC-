using NUnit.Framework;
using System.Collections.Generic;
using TestingTheInternet.pages;


namespace TestingTheInternet.tests
{
    [Parallelizable(ParallelScope.Children)]
    public class Tests : WebDriverTestInit
    {
        [Test]
        public void NavigateToAddRemoveWebPage()
        {
            AddRemoveElementsPage.Goto();
            Assert.That(Browser.WebDriver.Title, Is.EqualTo("The Internet"));
        }


        [Test]
        public void AddRemoveElementsTest()
        {
            List<string> assertList = new List<string>();
            AddRemoveElementsPage.Goto();
            AddRemoveElementsPage.ClickAddElement();
            var els = AddRemoveElementsPage.GetAllNewElements();
            if (els.Count < 1)
            {
                assertList.Add("Clicking Add Element did not create a new element box");
            }

            AddRemoveElementsPage.DeleteAllElements();
            var randomEls = AddRemoveElementsPage.CreateRandomAmountOfElementBoxes();
            var els2 = AddRemoveElementsPage.GetAllNewElements();
            if (randomEls != els2.Count)
            {
                assertList.Add($"Not all elements were created. Expected {randomEls}. Actual: {els2.Count}");
            }

            AddRemoveElementsPage.DeleteAllElements();

            Assert.That(assertList, Is.Empty, $"{assertList}");

        }

    }
}