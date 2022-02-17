using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TestProject1
{
    public class Oefenings2
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Shared Folder\Werk\Testing\Test1\C# project\TestProject1\drivers\");
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);
        }

        [Test]
        public IWebElement SelectContinent()
        {
            IWebElement selectElement = driver.FindElement(By.Id("dropdown"));

            return selectElement;
        }

        [Test]
        public void SelectAllOptions()
        {
            SelectElement select = new SelectElement(SelectContinent());    
            
            TearDown();
        }

        [Test]
        public void GetFirstOption()
        {
            SelectElement select = new SelectElement(SelectContinent());
            select.SelectByText("Option 1");
        }

        
        [Test]
        public void GetOptionTwo()
        {
            SelectElement select = new SelectElement(SelectContinent());
            select.SelectByValue("2");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
           // driver.Quit();
        }

    }

}