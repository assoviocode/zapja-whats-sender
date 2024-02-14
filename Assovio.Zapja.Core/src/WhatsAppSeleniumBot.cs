using Assovio.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Assovio.Zapja.Core
{
    public class WhatsAppSeleniumBot : SeleniumBot
    {


        public WhatsAppSeleniumBot()
        {

        }

        protected void FecharECriarAbaExtra(string link)
        {
            this.FecharAbasExtras();

            this.CriarAbaExtra(link);
        }

        protected void CriarAbaExtra(string link)
        {
            this._driver.SwitchTo().NewWindow(WindowType.Tab);

            this.Navegate(link);
        }

        protected void TrocarDeAba(string originalWindow)
        {
            this._wait.Until(wd => wd.WindowHandles.Count == 2);

            foreach (string window in this._driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    this._driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        protected void FecharAbasExtras()
        {
            while (this._driver.WindowHandles.Count() > 1)
            {
                this.FecharAbaExtra();
            }
        }

        protected void FecharAbaExtra()
        {
            this._driver.Close();
            this._driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        protected void CreateChromeDriver()
        {
            // Configurar o WebDriverManager para o Chrome
            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--start-maximized");

            this._driver = new ChromeDriver(options);

            this._wait = new WebDriverWait(this._driver, TimeSpan.FromMinutes(2));
        }

        protected void WaitUntil(Func<IWebDriver, IWebElement> conditions)
        {
            new WebDriverWait(this._driver, TimeSpan.FromSeconds(120)).Until(conditions);
        }

        protected void WaitUntil(Func<IWebDriver, bool> conditions)
        {
            new WebDriverWait(this._driver, TimeSpan.FromSeconds(120)).Until(conditions);
        }
    }
}
