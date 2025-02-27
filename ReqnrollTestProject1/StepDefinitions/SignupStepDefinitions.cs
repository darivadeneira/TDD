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
    public class SignupStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public SignupStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("El usuario esta en la pagina del Login")]
        public void GivenElUsuarioEstaEnLaPaginaDelLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la página de signup");

        }

        [When("Ingresa las credenciales de usuario {string} y el correo {string}")]
        public void WhenIngresaLasCredencialesDeUsuarioYElCorreo(string user, string email)
        {
            _driver.FindElement(By.CssSelector("[data-qa='signup-name']")).SendKeys(user);
            _driver.FindElement(By.CssSelector("[data-qa='signup-email']")).SendKeys(email);

            _test.Log(Status.Info, $"Usuario ingresó el correo {user} y la contraseña {email}");
            Thread.Sleep(1000);

        }

        [When("Hacer click en el boton de Signup")]
        public void WhenHacerClickEnElBotonDeSignup()
        {
            _driver.FindElement(By.CssSelector("[data-qa=\"signup-button\"]")).SendKeys(Keys.Enter);
            _test.Log(Status.Info, "Usuario hizo click en el botón de Signup.");
        }

        [When("Ingresa las credenciales de contraseña {string}, el primer nombre {string}, el apellido {string}, la direccion {string}, el estado {string}, la ciudad {string}, el codigo zip {string} y el numero telefónico {string}")]
        public void WhenIngresaLasCredencialesDeContrasenaElPrimerNombreElApellidoLaDireccionElEstadoLaCiudadElCodigoZipYElNumeroTelefonico(string password, string pablo, string perez, string eSPE, string sangolqui, string quito, string p6, string p7)
        {
            _driver.FindElement(By.Id("password")).SendKeys(password);
            _driver.FindElement(By.Id("first_name")).SendKeys(pablo);
            _driver.FindElement(By.Id("last_name")).SendKeys(perez);
            _driver.FindElement(By.Id("address1")).SendKeys(eSPE);
            _driver.FindElement(By.Id("state")).SendKeys(sangolqui);
            _driver.FindElement(By.Id("city")).SendKeys(quito);
            _driver.FindElement(By.Id("zipcode")).SendKeys(p6);
            _driver.FindElement(By.Id("mobile_number")).SendKeys(p7);

            _test.Log(Status.Info, $"Usuario ingresó la contraseña {password}, el primer nombre {pablo}, el apellido {perez}, la direccion {eSPE}, el estado {sangolqui}, la ciudad {quito}, el codigo zip {p6} y el numero telefónico {p7}");
            Thread.Sleep(1000);
        }

        [When("Hacer click en el boton Create Account")]
        public void WhenHacerClickEnElBotonCreateAccount()
        {
            _driver.FindElement(By.CssSelector("[data-qa=\"create-account\"]")).SendKeys(Keys.Enter);
            _test.Log(Status.Info, "Usuario hizo click en el botón de Signup.");
        }

        [Then("Deberia aparecer un mensaje de confirmacion")]
        public void ThenDeberiaAparecerUnMensajeDeConfirmacion()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/h2")) != null;

                _test.Log(Status.Pass, "Se ha mostrado el mensaje de confirmacion.");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostró el mensaje de confirmacion esperado.");
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
