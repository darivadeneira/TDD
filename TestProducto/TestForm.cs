using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProducto
{
    public class TestForm : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public TestForm()
        {
            //_driver = new EdgeDriver();
            //_driver.Manage().Window.Maximize();
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"; // Ruta en Windows
            _driver = new ChromeDriver(options); // Usa ChromeDriver pero con Brave
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public bool EsMailValido(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        //[Fact]

        public void validarCampos()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);
            var enviarFormulario = _wait.Until(d => d.FindElement(By.Id("submit")));
            Thread.Sleep(3000);
            enviarFormulario.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var errorValidacion = _driver.FindElement(By.ClassName("was-validated"));

            Assert.True(errorValidacion != null, "Faltan completar campos");
        }

        //[Fact]
        public void datosInvalidos()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);
            _driver.FindElement(By.Id("firstName")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("lastName")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            string email = "darivadeneira7@espe.edu.ec";

            if (!EsMailValido(email))
            {
                Console.WriteLine($"El correo {email} no es válido.");
            }
            _driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("userNumber")).SendKeys("asda1233");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Control + "a");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys("22 Nov 2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            var enviarFormulario = _wait.Until(d => d.FindElement(By.Id("submit")));

            enviarFormulario.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var telefonoInvalido = _driver.FindElement(By.Id("userNumber"));
            Thread.Sleep(2000);

            Assert.Equal("rgb(220, 53, 69)", telefonoInvalido.GetCssValue("border-color"));

        }

        //[Fact]
        public void datosValidos()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(5000);
            _driver.FindElement(By.Id("firstName")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("lastName")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            string email = "darivadeneira7@espe.edu.ec";

            if (!EsMailValido(email))
            {
                Console.WriteLine($"El correo {email} no es válido.");
            }
            _driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[@for='gender-radio-1']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("userNumber")).SendKeys("0963776997");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Control + "a");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys("22 Nov 2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("dateOfBirthInput")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("subjectsInput")).SendKeys("Maths");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("subjectsInput")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("currentAddress")).SendKeys("Calle 1");
            Thread.Sleep(1000);


            var enviarFormulario = _wait.Until(d => d.FindElement(By.Id("submit")));
            enviarFormulario.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var formularioCorrecto = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));

            Assert.True(formularioCorrecto != null, "Formulario correcto");
        }

        //[Fact]
        public void correoInvalido()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);
            _driver.FindElement(By.Id("firstName")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("lastName")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);

            string email = "darivadewparroba.com";

            if (!EsMailValido(email))
            {
                Console.WriteLine($"El correo {email} no es válido.");
            }
            _driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("userNumber")).SendKeys("0963776997");
            Thread.Sleep(1000);

            var enviarFormulario = _wait.Until(d => d.FindElement(By.Id("submit")));

            enviarFormulario.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var correoInvalido = _driver.FindElement(By.Id("userEmail"));
            Thread.Sleep(2000);

            Assert.Equal("rgb(220, 53, 69)", correoInvalido.GetCssValue("border-color"));

        }
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
