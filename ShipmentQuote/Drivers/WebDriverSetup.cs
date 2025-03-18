using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentQuote.Drivers
{
    public class WebDriverSetup
    {
        public IWebDriver driver;

        public IWebDriver InitializeWebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}

