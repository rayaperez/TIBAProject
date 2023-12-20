using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;

namespace TIBAProject.Hooks
{
    [Binding]
    public  class Hooks1
    {
        public IWebDriver _webDriver;
        private readonly IObjectContainer _objectContainer;
        
   
        public Hooks1(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //There are options to do switch case to run on different browsers
            if (_webDriver == null)
            {
                // ChromeOptions options = new ChromeOptions();
                // options.AddArgument("--ignore-ssl-errors=yes");
                //  options.AddArgument("--ignore-certificate-errors");

                //  _webDriver = new ChromeDriver(options); 
                //  _webDriver.Manage().Window.Maximize();
                //  _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _webDriver = new ChromeDriver();
            }
            else
            {
                throw new Exception("Couldnt initialise the driver");
            }
            _objectContainer.RegisterInstanceAs(_webDriver);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver = _objectContainer.Resolve<IWebDriver>();

            if (_webDriver != null)
            {
                _webDriver.Quit();
                _webDriver.Dispose();
            }
            else throw new Exception("Issue to close the driver");
        }
    }
}