using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class UM001_1StepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public UM001_1StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("Extentreport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("Enter the Login system")]
        public void GivenEnterTheLoginSystem()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");
            _test.Log(Status.Pass, "User navigates to the election page");
        }

        [When("you enter the email credentials {string} and the password {string}")]
        public void WhenYouEnterTheEmailCredentialsAndThePassword(string email, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(email);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);
            _test.Log(Status.Info, "User has entered the email and password");
        }

        [When("click on the Login button")]
        public void WhenClickOnTheLoginButton()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).SendKeys(Keys.Enter);
            _test.Log(Status.Info, "User clicked the Login button.");
        }

        [Then("an alert message should appear")]
        public void ThenAnAlertMessageShouldAppear()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/h2")) != null;

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
