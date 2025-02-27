using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace TestProducto
{
    public class UnitTest1
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public UnitTest1()
        {
            _driver = new EdgeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        //public bool EsMailValido(string email)
        //{
        //    return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //}

        //[Theory]
        //[InlineData("usuario@gmail.com", true)]
        //[InlineData("test@presa.com", true)]
        //[InlineData("correo@_prueba.com", true)]
        //[InlineData("correocom", true)]
        //public void ValidarEmail(string email, bool esperado)
        //{
        //    bool resultado = EsMailValido(email);
        //    Assert.Equal(esperado, resultado);

        //}
        //[Fact]
        //public void Test_NavegadorGoogle()
        //{
        //    try
        //    {
        //        _driver.Navigate().GoToUrl("https://www.bing.com");

        //        var buscarTexto = _wait.Until(d => d.FindElement(By.Name("q")));

        //        Thread.Sleep(3000);

        //        buscarTexto.SendKeys("Selenium");

        //        Thread.Sleep(3000);

        //        _driver.FindElement(By.Id("search_icon")).Click();

        //        Thread.Sleep(3000);

        //        var resultados = _wait.Until(d => d.FindElements(By.CssSelector("h2")));

        //        Assert.True(resultados.Count > 0, "No se encontraron resultados de la busqueda");

        //        Console.WriteLine("Prueba exitosa");
        //        Console.WriteLine("Esperando 10 segundos para cerrar el navegador");
        //        Thread.Sleep(10000);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        _driver.Quit();

        //    }
        //}

        //[Fact]
        public void Test_formulario()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                Thread.Sleep(3000);
                var enviarFormulario = _wait.Until(d => d.FindElement(By.Id("submit")));
                Thread.Sleep(3000);
                enviarFormulario.Click();
                Thread.Sleep(3000);

                var errorValidacion = _driver.FindElement(By.ClassName("was-validated"));

                Assert.True(errorValidacion != null, "Faltan completar campos");

            }
            finally
            {
                Console.WriteLine("Cerrando navegador en 10 segundos");
                Thread.Sleep(10000);
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_CorreoInvalido()
        {
            string usuario = "test";
            string correoInvalido = "testo2.com";
            try
            {
                _driver.Navigate().GoToUrl("https://www.automationexercise.com/");
                Thread.Sleep(3000);
                var loginLink = _wait.Until(d => d.FindElement(By.CssSelector("a[href='/login']")));
                loginLink.Click();
                Thread.Sleep(3000);
                var nombreInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='signup-name']")));
                nombreInput.SendKeys(usuario);
                Thread.Sleep(3000);
                var emailInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='signup-email']")));
                emailInput.SendKeys(correoInvalido);
                Thread.Sleep(3000);
                var enviarFormulario = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa=\"signup-button\"]")));
                Thread.Sleep(3000);
                enviarFormulario.Click();
                Thread.Sleep(3000);

                var errorEmail = _driver.FindElement(By.CssSelector("[data-qa='signup-email']"));


                string validationMessage = emailInput.GetAttribute("validationMessage");

                Assert.Equal($"Please include an '@' in the email address. '{correoInvalido}' is missing an '@'.", validationMessage);

            }
            finally
            {
                Console.WriteLine("Cerrando navegador en 10 segundos");
                Thread.Sleep(10000);
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_contrasenaInvalida()
        {
            string email = "test@testing1.com";
            string passInvalida = "testo2.com";
            try
            {
                _driver.Navigate().GoToUrl("https://www.automationexercise.com/");
                Thread.Sleep(3000);
                var loginLink = _wait.Until(d => d.FindElement(By.CssSelector("a[href='/login']")));
                loginLink.Click();
                Thread.Sleep(3000);
                var nombreInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='login-email']")));
                nombreInput.SendKeys(email);
                Thread.Sleep(3000);
                var emailInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='login-password']")));
                emailInput.SendKeys(passInvalida);
                Thread.Sleep(3000);
                var enviarFormulario = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa=\"login-button\"]")));
                Thread.Sleep(3000);
                enviarFormulario.Click();
                Thread.Sleep(3000);

                var errorMessage = _wait.Until(d => d.FindElement(By.CssSelector("p[style='color: red;']")));


                string validationMessage = errorMessage.Text;

                Assert.Equal("Your email or password is incorrect!", validationMessage);

            }
            finally
            {
                Console.WriteLine("Cerrando navegador en 10 segundos");
                Thread.Sleep(10000);
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_contrasenaValida()
        {
            string email = "test@testing1.com";
            string passValida = "testeo1";
            try
            {
                _driver.Navigate().GoToUrl("https://www.automationexercise.com/");
                Thread.Sleep(3000);
                var loginLink = _wait.Until(d => d.FindElement(By.CssSelector("a[href='/login']")));
                loginLink.Click();
                Thread.Sleep(3000);
                var nombreInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='login-email']")));
                nombreInput.SendKeys(email);
                Thread.Sleep(3000);
                var emailInput = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa='login-password']")));
                emailInput.SendKeys(passValida);
                Thread.Sleep(3000);
                var enviarFormulario = _wait.Until(d => d.FindElement(By.CssSelector("[data-qa=\"login-button\"]")));
                Thread.Sleep(3000);
                enviarFormulario.Click();
                Thread.Sleep(3000);


                var categoriaElemento = _driver.FindElements(By.ClassName("panel-group category-products"));
                Assert.True(categoriaElemento.Count > 0, "La categoría no se encontró en la página.");

            }
            finally
            {
                Console.WriteLine("Cerrando navegador en 10 segundos");
                Thread.Sleep(10000);
                _driver.Quit();
            }
        }
    }
}
