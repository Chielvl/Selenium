using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;
       [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver(@"C:\Shared Folder\Werk\Testing\Test1\C# project\TestProject1\drivers\");

        }

        [Test]
        public void VerifyLogo()

        {
            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);

            TearDown();
        }

        [Test]

        public void VerifyMenuItemcount()

        {
            driver.Navigate().GoToUrl("https://www.browserstack.com/");

            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath("//ul[contains(@class,'horizontal-list product-menu')]/li"));

            Assert.AreEqual(menuItem.Count, 4);

            TearDown();
        }

        [Test]

        public void VerifyPricingPage()

        {

            driver.Navigate().GoToUrl("https://browserstack.com/pricing");

            IWebElement contactUsPageHeader = driver.FindElement(By.TagName("h1"));

            Assert.IsTrue(contactUsPageHeader.Text.Contains("Replace your device lab and VMs with any of these plans"));

        }

        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}