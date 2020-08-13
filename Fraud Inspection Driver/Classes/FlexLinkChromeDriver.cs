using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace RLJones.FraudInspectionDriver.Classes
{
    public class FlexLinkChromeDriver
    {
        private IWebDriver Driver;

        public FlexLinkChromeDriver()
        {
            
        }

        public void Open(string chromeDriverPath = "", bool hideCmdPrompt = true)
        {
            if (chromeDriverPath == "")
                chromeDriverPath = Path.GetDirectoryName(Application.ExecutablePath);

            var chromeDriverService =
                ChromeDriverService.CreateDefaultService(chromeDriverPath);

            chromeDriverService.HideCommandPromptWindow = hideCmdPrompt;

            Driver = new ChromeDriver(chromeDriverService, new ChromeOptions());
        }

        public void Navigate(string url)
        {
            if (Driver == null) 
                return;

            Driver.Url = url;
        }

        public IWebElement WaitForElementById(string elementId, int timeoutSeconds=10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
                var element = wait.Until(x => x.FindElement(By.Id(elementId)));
                return element;
            }
            catch
            {
                return null;
            }
        }

        public IWebElement WaitForElementByTagName(string tagName, int timeoutSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
                var element = wait.Until(x => x.FindElement(By.TagName(tagName)));
                return element;
            }
            catch
            {
                return null;
            }
        }

        public IWebElement FindElementByXPath(IWebElement element, string xPath)
        {
            try
            {
                var outputElement = element.FindElement(By.XPath(xPath));
                return outputElement;
            }
            catch
            {
                return null;
            }
        }

        public void Minimize()
        {
            if (Driver == null)
                return;

            try
            {
                Driver.Manage().Window.Minimize();
            }
            catch { }
        }

        public void Maximize()
        {
            if (Driver == null)
                return;

            try
            {
                Driver.Manage().Window.Maximize();
            }
            catch { }
        }

        public void Close()
        {
            if (Driver != null)
            {
                try
                {
                    Driver.Close();
                }
                catch { }
            }
        }

        public bool IsAlive()
        {
            try
            {
                string title = Driver.Title;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Quit()
        {
            try
            {
                if (Driver != null)
                    Driver.Quit();
            }
            catch { }
        }
    }
}
