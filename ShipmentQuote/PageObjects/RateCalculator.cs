using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentQuote.PageObjects
{
    public class RateCalculatorPage
    {
        private readonly IWebDriver _driver;

        public RateCalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private By FromPostcodeField = By.XPath("//input[@placeholder='Postcode']");
        private By ToCountryDropdown = By.Id("mat-input-0");
        private By WeightField = By.XPath("//input[@placeholder='eg. 0.1kg']");
        private By CalculateButton = By.XPath("//a[@type=' button']");
        private By QuoteResults = By.XPath("//div[contains(@class, 'quote-results')]");

        // Actions
        public void NavigateToCalculator()
        {
            _driver.Navigate().GoToUrl("https://www.pos.com.my/send/ratecalculator");
            Thread.Sleep(1000);
        }
        public void EnterFromPostalCode(string postcode)
        {
            _driver.FindElement(FromPostcodeField).SendKeys(postcode);
        }

        public void EnterToCountry(string country)
        {
            IWebElement toCountryField = _driver.FindElement(ToCountryDropdown);

            // Click the dropdown field
            toCountryField.Click();
           
            // Select all existing text (Ctrl + A)
            toCountryField.SendKeys(Keys.Control + "a");
            Thread.Sleep(1000);

            // Type "India"
            toCountryField.SendKeys(country);

            // Wait a bit for suggestions to load (if necessary)
            Thread.Sleep(1000);

            // Press Arrow Down to select the first suggestion
            toCountryField.SendKeys(Keys.ArrowDown);

            // Press Enter to confirm selection
            toCountryField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public void EnterWeightAndCalculate(int weight)
        {
            _driver.FindElement(WeightField).SendKeys(weight.ToString());
            _driver.FindElement(CalculateButton).Click();
            Thread.Sleep(1000);

            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(1000);
        }
    }
}
