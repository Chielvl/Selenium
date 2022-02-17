using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestProject1
{
    public class OefeningTables
    {
        IWebDriver driver;
        IWebElement table;
        IList<IWebElement> rowList;

        [SetUp]
        public void Setup()
        {
            //Get driver
            driver = new ChromeDriver(@"C:\Shared Folder\Werk\Testing\Test1\C# project\TestProject1\drivers\");
        }

        [Test]
        public void SwitchWindows()
        {
            //Go to one page
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");

            //Use driver as javascript executor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Go to another page in new window
            string url_2 = "http://the-internet.herokuapp.com/";
            js.ExecuteScript("window.open('" + url_2 + "', '_blank')");

            //Check to see if there are two windows
            Assert.AreEqual(2, driver.WindowHandles.Count);

            //Switches back to first window
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Test]
        public void SwitchToLeftFrame()
        {
            //Go to page with nested URLS
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/nested_frames");

            //Select main frame on page
            driver.SwitchTo().ParentFrame();

            //Find frame with name top
            var topFrame = driver.SwitchTo().Frame(driver.FindElement(By.Name("frame-top")));

            //in top frame, find frame with name left
            topFrame.SwitchTo().Frame("frame-left");

            Console.WriteLine(currentFrame);
        }

        [Test]
        public void SwitchToMiddleFrame()
        {
            //Go to page with nested URLS
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/nested_frames");
            
            //Select main frame on page
            driver.SwitchTo().ParentFrame();
            
            //Find frame with name top
            var topFrame = driver.SwitchTo().Frame(driver.FindElement(By.Name("frame-top")));
            
            //in top frame, find frame with name middle
            topFrame.SwitchTo().Frame("frame-middle");

        }

        [Test]
        public void SwitchToRightFrame()
        {
            //Go to page with nested URLS
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/nested_frames");
            
            //Select main frame on page
            driver.SwitchTo().ParentFrame();
            
            //Find frame with name top
            var topFrame = driver.SwitchTo().Frame(driver.FindElement(By.Name("frame-top")));
            
            //in top frame, find frame with name right
            topFrame.SwitchTo().Frame("frame-right");

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            var currentFrame = jsExecutor.ExecuteScript("return self.name");
            Console.WriteLine(currentFrame);
        }

        [Test]
        public void SelectJohnSmith()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            
            //Gets the table on the page
            table = driver.FindElement(By.Id("table1"));
            
            //Check if John is a valid entry
            Assert.IsTrue(table.Text.Contains("John"));
           
        }

        [Test]
        public void SelectHighestDue()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
         
            //Gets the table on the page
            table = driver.FindElement(By.Id("table1"));

            //Finds all columns with the tag TH and loop through all entries to find the Due column
            List<IWebElement> element = new List<IWebElement>(table.FindElements(By.TagName("th")));
            foreach (var item in element)
            {
                //if the column has the word Due in it, click it twice to sort highest to lowest
                if(item.FindElement(By.TagName("Span")).Text.Contains("Due"))
                {
                    item.Click();
                    item.Click();
                    continue;
                }
            }
            //Determine the entry order in the list, after sorting it on Due
            rowList = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            Assert.IsTrue(rowList[1].Text.Contains("jdoe@hotmail.com"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
