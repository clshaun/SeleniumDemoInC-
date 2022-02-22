using NUnit.Framework;
using NUnit.Framework.Interfaces;


namespace TestingTheInternet.pages
{
    public class WebDriverTestInit
    {
        [SetUp]
        public virtual void BeforeEach()
        {
            Browser.Start();
            Browser.Maximize();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            Browser.Quit();
        }
    }
}
