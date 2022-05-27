using JESPGAutoTask.Drivers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace JESPGAutoTask.Hooks
{
    [Binding]
    public sealed class Hooks1 : DriverHelper
    {

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            var options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Enviroment.baseurl);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (driver  != null)
            {
                driver.Quit();
            }
            driver = null;
        }
    }
}