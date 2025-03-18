using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShipmentQuote.Drivers;
using ShipmentQuote.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using System.Diagnostics;


namespace ShipmentQuote.Tests
{
    [TestFixture]
    public class RateCalculatorTests
    {
        private WebDriverSetup _webDriverSetup;
        private IWebDriver _driver;
        private RateCalculatorPage _rateCalculatorPage;

        [SetUp]
        public void SetUp()
        {
            _webDriverSetup = new WebDriverSetup();
            _driver = _webDriverSetup.InitializeWebDriver();
            _rateCalculatorPage = new RateCalculatorPage(_driver);
        }

        //Test Case 1: Verify user can calculate the shipment quote from Malaysia to India.
        [Test]
        public void VerifyShipmentQuoteFromMalaysiaToIndia()
        {
            //Step 1: User go to https://pos.com.my/send/ratecalculator
            _rateCalculatorPage.NavigateToCalculator();

            //Step 2: User enter “Malaysia” as “From” country, and enter “35600” as the postcode.
            _rateCalculatorPage.EnterFromPostalCode("35600");

            //Step 3: User enter “India” as “To” country, and leave the postcode empty.
            _rateCalculatorPage.EnterToCountry("India");

            //Step 4: User enter 1 as the “Weight”, and user press Calculate.
            _rateCalculatorPage.EnterWeightAndCalculate(1);           

            //Step 5: Verify user can see multiple quotes and shipments optionsavailable.
            IList<IWebElement> allDivs = _driver.FindElements(By.CssSelector(".border-b.border-gray-300.w-full.px-2.py-4.sm\\:flex.sm\\:items-center.sm\\:justify-between.sm\\:space-x-6.sm\\:px-6.lg\\:space-x-8.ng-star-inserted"));

            //Collect div count to know total quotes  
            var visibleDivs = allDivs.Where(div => div.Displayed).ToList();

            if (visibleDivs.Count > 1)
            {
                Console.WriteLine("Test Passed: Multiple shipment options are visible.");
            }
            else
            {
                Console.WriteLine($"Test Failed: Expected more than 1 visible div, but found {visibleDivs.Count}");
            }

            //Collect how many book now buttons
            int bookNowCount = 0;

            foreach (var div in visibleDivs)
            {
                if (div.Text.Contains("Book Now"))
                {
                    bookNowCount += div.Text.Split(new string[] { "Book Now" }, StringSplitOptions.None).Length - 1;
                }
            }

            //Check "Book Now" is more than one 
            if (bookNowCount > 1)
            {
                //Console.WriteLine("Test Passed: More than 1 'Book Now' found.");
                Assert.Pass("Test Passed: More than 1 'Book Now' found.");
            }
            else
            {
                //Console.WriteLine("Test Failed: Less than or equal to 1 'Book Now' found.");
                Assert.Fail("Test Failed: Less than or equal to 1 'Book Now' found.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            _webDriverSetup.CloseDriver();
        }

    }
}
