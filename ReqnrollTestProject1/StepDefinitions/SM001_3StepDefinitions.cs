using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class SM001_3StepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public SM001_3StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (_extent == null)
            {
                var sparkReporter = new ExtentSparkReporter("Extentreport2.html");
                _extent = new ExtentReports();
                _extent.AttachReporter(sparkReporter);
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (_driver == null) // Evita múltiples instancias
            {
                _driver = WebDriverManager.GetDriver("edge");
            }
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("Enter the system.")]
        public void GivenEnterTheSystem_()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");
            _test.Log(Status.Pass, "User navigates to the election page");
        }

        [When("Enter the email credentials {string} and the password {string} admin account.")]
        public void WhenEnterTheEmailCredentialsAndThePasswordAdminAccount_(string email, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(email);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);

            _test.Info("User has entered the email and password");
        }

        [When("Click on the Login button.")]
        public void WhenClickOnTheLoginButton_()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).SendKeys(Keys.Enter);

            _test.Info("User clicked the Login button.");
        }

        [When("Select the button to end a simulation.")]
        public void WhenSelectTheButtonToEndASimulation_()
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/div/button[1]")).SendKeys(Keys.Enter);
            _test.Info("User selected the button to end a simulation.");
        }

        [When("Click on the finish simulation button.")]
        public void WhenClickOnTheFinishSimulationButton_()
        {
            _driver.FindElement(By.XPath("/html/body/div/div/div[1]/dialog/div[2]/button")).Click();
            _test.Info("The user clicked the End Simulation button");
        }

        [Then("It should show a confirmation message.")]
        public void ThenItShouldShowAConfirmationMessage_()
        {
            try
            {
                Thread.Sleep(1000);
                bool isErrorVisible = _driver.FindElement(By.XPath("/html/body/div[2]/div")) != null;

                _test.Log(Status.Pass, "Alert message has been displayed.");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "The alert message was not displayed.");
            }
        }
        [AfterScenario]
        public void Down()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
