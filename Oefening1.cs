using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestProject1
{
    public class Oefening1
    {
        IWebDriver driver;
        Actions actions;
      [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver(@"C:\Shared Folder\Werk\Testing\Test1\C# project\TestProject1\SeleniumTest\drivers\");

             actions = new Actions(driver);
        }

        [Test]
        public void SetGenderToOther()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form/");

            driver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);

            IWebElement otherOption = driver.FindElement(By.CssSelector("input[value='Other']"));

            actions.MoveToElement(otherOption).Click().Perform();

        }

        [Test]
        public void SetGenderToMale()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form/");

            IWebElement maleOption = driver.FindElement(By.Id("gender-radio-1"));

            actions.MoveToElement(maleOption).Click().Perform();
        //    SetGenderToFemale();
        }

        [Test]
        public void SetGenderToFemale()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form/");

            IList<IWebElement> radioBtns = driver.FindElements(By.Name("gender"));

            if (radioBtns.ElementAt(0).Selected)
            {
                IWebElement radioBtn2 = radioBtns.ElementAt(1);

                actions.MoveToElement(radioBtn2).Click().Perform();
            }
            else
            {
                IWebElement radioBtn2 = radioBtns.ElementAt(0);
                actions.MoveToElement(radioBtn2).Click().Perform();
            }

        }

        [TearDown]
        public void TearDown()
        {

            driver.Quit();
        }
    }
}