using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("El usuario esta en la pagina del login")]
        public void GivenElUsuarioEstaEnLaPaginaDelLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la página de login");
        }

        [When("Ingresa las credenciales correo {string} y la contraseña {string}")]
        public void WhenIngresaLasCredencialesCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);

            _test.Log(Status.Info, $"Usuario ingresó el correo {email} y la contraseña {password}");
        }

        [When("Hacer click en el boton de Login")]
        public void WhenHacerClickEnElBotonDeLogin()
        {
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            _test.Log(Status.Info, "Usuario hizo click en el botón de login.");
        }


        [Then("Deberia ver un mensaje de error")]
        public void ThenDeberiaVerUnMensajeDeError()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/p")) != null;

                _test.Log(Status.Pass, "Se ha mostrado el mensaje de error.");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostró el mensaje de error esperado.");
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
