using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace ReqnrollTestProject1.Utilities
{
    internal class WebDriverManager
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                "brave" => GetBraveDriver(),
                _ => throw new NotSupportedException($"{browser} is not supported"),
            };
        }

        private static IWebDriver GetBraveDriver()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"; // Ruta al ejecutable de Brave
            return new ChromeDriver(options);
        }
    }
}
