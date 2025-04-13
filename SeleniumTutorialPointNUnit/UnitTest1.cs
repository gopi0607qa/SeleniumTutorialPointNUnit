using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTutorialPointNUnit
{
    public class Tests
    {
        private IWebDriver driver;
        private string Url = "https://www.tutorialspoint.com/selenium/practice/selenium_automation_practice.php";
        private string homePageTitlexpath = "//form[@id='practiceForm']/h1";
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        private void WaitforElementVisible(IWebDriver driver ,string xpath) {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        
        }

        [Test]
        public void HomepagetitleCheck()
        {
            driver.Navigate().GoToUrl(Url);

            WaitforElementVisible(driver, homePageTitlexpath);

            string homeTitle = driver.FindElement(By.XPath(homePageTitlexpath)).Text;

            Assert.That(homeTitle, Is.EqualTo("Student Registration Form"));
        }

        [TearDown]

        public void TearDown() {

            driver.Dispose();
        }
    }
}