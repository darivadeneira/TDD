using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;



namespace TestProducto
{
    public class TestCliente : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public TestCliente() 
        { 
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"; // Ruta en Windows
            _driver = new ChromeDriver(options); // Usa ChromeDriver pero con Brave
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        //[Fact]
        public void Test_CreateCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente/Create");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).SendKeys("1727515775");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("11/22/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("darivadeneira@espe.ec");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0963776997");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("El Condado");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmit")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            Assert.Equal("https://localhost:7274/Cliente", _driver.Url);

        }

        //[Fact]
        public void Test_CorreoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente/Create");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).SendKeys("1727515775");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("11/22/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("darivadeneira7");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0963776997");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("El Condado");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);
            Assert.Equal("https://localhost:7274/Cliente/Create", _driver.Url);
        }

        //[Fact]
        public void Test_TelefonoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente/Create");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).SendKeys("1727515775");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("11/22/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("darivadeneira7@espe.edu.ec");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("096377699");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("El Condado");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);
            Assert.Equal("https://localhost:7274/Cliente/Create", _driver.Url);
        }

        //[Fact]
        public void Test_CedulaInvalida()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente/Create");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).SendKeys("172751577");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Rivadeneira");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("11/22/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("darivadeneira7@espe.edu.ec");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0963776997");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("El Condado");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);
            Assert.Equal("https://localhost:7274/Cliente/Create", _driver.Url);
        }

        //[Fact]
        public void Test_EnviarVacio()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente/Create");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);
            Assert.Equal("https://localhost:7274/Cliente/Create", _driver.Url);
        }

        [Fact]
        public void Test_EditCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente");
            Thread.Sleep(1000);
            var editButton = _wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '2007')]]//a[contains(@href, '/Cliente/Edit/2007')]")));
            editButton.Click();
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Cedula"))).Clear();
            _driver.FindElement(By.Name("Cedula")).SendKeys("1713226940");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Nombres"))).Clear();
            _driver.FindElement(By.Name("Nombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Apellidos"))).Clear();
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Smith");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("FechaNacimiento"))).Clear();
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("02/11/1992");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Mail"))).Clear();
            _driver.FindElement(By.Name("Mail")).SendKeys("darivadeneira7@espe.edu.ec");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Telefono"))).Clear();
            _driver.FindElement(By.Name("Telefono")).SendKeys("0980213124");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Name("Direccion"))).Clear();
            _driver.FindElement(By.Name("Direccion")).SendKeys("El Condado");
            Thread.Sleep(1000);
            _wait.Until(d => d.FindElement(By.Id("btnGuardar"))).Click();
            Thread.Sleep(1000);
            _wait.Until(d => d.Url == "https://localhost:7274/Cliente");

            Assert.Equal("https://localhost:7274/Cliente", _driver.Url);
        }


        [Fact]
        public void Test_DeleteCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7274/Cliente");
            Thread.Sleep(4000);
            var deleteButton = _wait.Until(driver =>
            {
                var element = driver.FindElement(By.XPath("//tr[td[contains(text(), '2009')]]//button[contains(@id, 'btnDelete')]"));
                return (element.Displayed && element.Enabled) ? element : null;
            });
            deleteButton.Click();
            Thread.Sleep(1000);
            _wait.Until(driver =>
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            });
            Thread.Sleep(1000);
            bool isDeleted = _wait.Until(driver =>
                !driver.FindElements(By.XPath("//tr[td[contains(text(), '2009')]]")).Any()
            );

            Assert.True(isDeleted, "El cliente no fue eliminado correctamente.");
        }



        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
