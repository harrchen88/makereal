using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SmartHotel360.Registration.Web.Tests.SeleniumTests
{
    [TestClass]
    public class SearchFeatureSeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public SearchFeatureSeleniumTests()
        {
            appURL = ConfigurationManager.AppSettings["WebAppPortalUrl"];
        }

        [TestMethod]
        [TestCategory("UITest")]
        public void TheCustomerSearchIETest()
        {
            SetupTest("IE");
            PerformTest();
        }

        [TestMethod]
        [TestCategory("UITest")]
        public void TheCustomerSearchChromeTest()
        {
            SetupTest("Chrome");
            PerformTest();
        }

        [TestMethod]
        [TestCategory("UITest")]
        public void TheCustomerSearchFirefoxTest()
        {
            SetupTest("Firefox");
            PerformTest();
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public void SetupTest(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    var IEOptions = new InternetExplorerOptions
                    {
                        IgnoreZoomLevel = true,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true
                    };

                    // Reset browser to 100% zoom level.
                    driver = new InternetExplorerDriver(IEOptions);
                    driver.FindElement(By.TagName("html")).SendKeys(Keys.Control + "0");
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        public void PerformTest()
        {
            int delay = 10000;
            driver.Navigate().GoToUrl(appURL);
            Thread.Sleep(delay);
            driver.FindElement(By.Id("MainContent_txtSearchMaster")).SendKeys("just");
            Thread.Sleep(delay);
            driver.FindElement(By.Id("MainContent_btnSearch")).Click();
            Thread.Sleep(delay);

            var resultRows = driver.FindElements(By.XPath("//table[@id='MainContent_RegistrationGrid']/tbody/tr[not(th)]"));
            var resultRowsCount = resultRows.Count;

            Assert.AreEqual(2, resultRowsCount);

            foreach (var resultRow in resultRows)
            {
                Assert.IsTrue(resultRow.Text.ToUpperInvariant().StartsWith("JUST"));
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
