using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Devops_Ticket_Prediction
{
    [TestClass]
    public class Ticket_Prediction_Unit_Test
    {
        [TestMethod]
        [TestCategory("Simulate Tickets")]
        public void Simulate()
        {
            OpenSite();
            //LoginApplication();
            SimulateTickets();
            quit();
        }
        [TestMethod]
        [TestCategory("Run Nlp Process")]
        public void RunNLPProcess()
        {
            OpenSite();
           // LoginApplication();
            SimulateTickets();
            RunNLPAnalytics();
            quit();
            
        }
        [TestMethod]
        [TestCategory("Accept Tickets")]
        public void AcceptedTickets()
        {
            OpenSite();
            //LoginApplication();
            SimulateTickets();
            RunNLPAnalytics();
            ChooseTheConfidenceLevel();
            Accept();
            quit();

        }
        [TestMethod]
        [TestCategory("Resolved Tickets")]
        public void ResolvedTickets()
        {
            OpenSite();
            //LoginApplication();
            SimulateTickets();
            RunNLPAnalytics();
            ChooseTheConfidenceLevel();
            Accept();
            Resolved();
            quit();

        }
        [TestMethod]
        [TestCategory("Reset Demo Application")]
        public void ResetDemo()
        {
            OpenSite();
            //LoginApplication();
            SimulateTickets();
            RunNLPAnalytics();
            ChooseTheConfidenceLevel();
            Accept();
            Resolved();
            Reset();
            quit();

        }
        public void OpenSite()
        {
            Global.SetUpDriver();
            Global.Driver.Navigate().GoToUrl(" http://ticketwebrjsdemo.azurewebsites.net/");
            Global.Driver.Manage().Window.Maximize();

            System.Threading.Thread.Sleep(8000);
        }
     
     /*   public void LoginApplication()
        {
            Global.Driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("admin@ilink-systems.com");
            Global.Driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Enter321");
            System.Threading.Thread.Sleep(3000);
            By by = By.XPath("//button[@class='btn btn-success']");
            Extentions.ClickOnGivenLocators(by);
        }
       */
        public void SimulateTickets()
        {
            
            Global.Driver.FindElement(By.XPath("//span[text()='Simulate Tickets']")).Click();
            System.Threading.Thread.Sleep(10000);
            var ticketCount = Global.Driver.FindElements(By.XPath("//td[1]/span")).Count;
            Extentions.WaitForPageLoad(120);
            Console.WriteLine(ticketCount);
            Assert.AreEqual(50, ticketCount);
          
        }
    
        public void RunNLPAnalytics()
        {
            By by = By.XPath("//span[text()='Run NLP Analytics']");
            Extentions.ClickOnGivenLocators(by);
            Extentions.WaitForElementNotExists(By.XPath(".//*[@id='progressbox2']"));
            Global.Driver.FindElements(By.XPath("//*[@id='progressoverlay3']"));
            //Global.Driver.Quit();
        }
     

        public void ChooseTheConfidenceLevel()
        {
            var E1 = Global.Driver.FindElement(By.XPath("//span[@style='left: 79.798%;']"));
            //System.Threading.Thread.Sleep(5000);
            var Target = Global.Driver.FindElement(By.XPath("//span[@style='left: 100%;']"));
            Actions ac = new Actions(Global.Driver);
            ac.DragAndDrop(E1, Target);
            ac.Build().Perform();
            System.Threading.Thread.Sleep(1000);
        }
       

        public void Accept()
        {
            By by = By.XPath("//button[text()='Accept']");
            Extentions.ClickOnGivenLocators(by);
            System.Threading.Thread.Sleep(1000);
        }
      
       
        public void Resolved()
        {
            By by = By.XPath("//span[text()='Resolved Tickets']");
            Extentions.ClickOnGivenLocators(by);
            System.Threading.Thread.Sleep(1000);
        }
      
        public void Reset()
        {
            By by = By.XPath("//button[text()='Reset Demo']");
            Extentions.ClickOnGivenLocators(by);
            System.Threading.Thread.Sleep(1000);
            Global.Driver.Quit();
        }
        public void quit()
        {
            Global.Driver.Quit();
        }
        
        
    }
}
