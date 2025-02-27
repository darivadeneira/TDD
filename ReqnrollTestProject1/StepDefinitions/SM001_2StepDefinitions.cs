using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;
using OpenQA.Selenium.Support.UI;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class SM001_2StepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public SM001_2StepDefinitions(ScenarioContext scenarioContext)
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


        [Given("Enter the system")]
        public void GivenEnterTheSystem()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");
            _test.Log(Status.Pass, "User navigates to the election page");
        }

        [When("Enter the email credentials {string} and the password {string} admin account")]
        public void WhenEnterTheEmailCredentialsAndThePasswordAdminAccount(string email, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(email);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);

            _test.Info("User has entered the email and password");
        }

        [When("Click on the Login button")]
        public void WhenClickOnTheLoginButton()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).SendKeys(Keys.Enter);

            _test.Info("User clicked the Login button.");

        }

        [When("Select a created simulation")]
        public void WhenSelectACreatedSimulation()
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/button[2]")).Click();
            IWebElement selectElement = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/select"));

            SelectElement select = new SelectElement(selectElement);

            select.SelectByText("VotosTest");
            _test.Info("User selected a simulation.");
        }

        [When("Click on the load simulation button")]
        public void WhenClickOnTheLoadSimulationButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[2]/button")));
            element.Click();
            _test.Info("User clicked the load simulation button.");
        }

        [Then("It should show a confirmation message")]
        public void ThenItShouldShowAConfirmationMessage()
        {
            try
            {
                Thread.Sleep(1000);
                bool isErrorVisible = _driver.FindElement(By.XPath("/html/body/div/div/header/p")) != null;

                _test.Log(Status.Pass, "Alert message has been displayed.");

            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "The alert message was not displayed.");
                throw;
            }
        }

        [AfterScenario]
        public void Down()
        {
            if (_driver != null)
            {
                _driver.Quit();  // Cierra todas las ventanas del navegador
                _driver = null;   // Evita que quede en memoria
            }
            _extent.Flush();
        }

    }
}
