using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTutorialPointNUnit
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {

        ThreadLocal<IWebDriver> driver = new();
        private string HomeUrl = "https://www.tutorialspoint.com/selenium/practice/selenium_automation_practice.php";
        private string LoginUrl = "https://www.tutorialspoint.com/selenium/practice/login.php";

        private string homePageTitlexpath = "//form[@id='practiceForm']/h1";

        private string loginPageTitlexpath = "//form[@id='signInForm']/h1";

        [SetUp]
        public void Setup()
        {
            driver.Value = DriverInvocation("chrome");

        }

        private static IWebDriver DriverInvocation(string browsername) {

            IWebDriver createdriverinstance = null;
            switch (browsername) {
                case "chrome":
                    createdriverinstance = new ChromeDriver();
                    createdriverinstance.Manage().Window.Maximize();
                    break;
                case "edge":
                    createdriverinstance = new EdgeDriver();
                    createdriverinstance.Manage().Window.Maximize();

                    break;
                    
            }
            return createdriverinstance;
        }

        private static void WaitforElementVisible(IWebDriver driver ,string xpath) {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

        
        }

        [Test, Parallelizable]
        public void HomepagetitleCheck()
        {

            IWebDriver currentdriverinstance = driver.Value;

            currentdriverinstance.Navigate().GoToUrl(HomeUrl);

            WaitforElementVisible(currentdriverinstance, homePageTitlexpath);

            string homeTitle = currentdriverinstance.FindElement(By.XPath(homePageTitlexpath)).Text;

            Assert.That(homeTitle, Is.EqualTo("Student Registration Form"));

            Thread.Sleep(6000);


        }

        [Test, Parallelizable]
        public void LoginpagetitleCheck()
        {
            IWebDriver currentdriverinstance = driver.Value;

            currentdriverinstance.Navigate().GoToUrl(LoginUrl);

            WaitforElementVisible(currentdriverinstance, loginPageTitlexpath);

            string homeTitle = currentdriverinstance.FindElement(By.XPath(loginPageTitlexpath)).Text;

            Assert.That(homeTitle, Is.EqualTo("Welcome, Login In"));

            Thread.Sleep(5000);



        }

        [TearDown]

        public void TearDown() {

            Console.WriteLine(driver.ToString());

            driver.Value.Quit();
            driver.Value.Dispose();

        }
    }
}