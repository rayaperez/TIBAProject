using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Page;
using TIBAProject.Hooks;

namespace TIBAProject.PageObjects
{
    [Binding]
    public class POYouTube 
    {
        private readonly IWebDriver _webDriver;
        public ILog log = LogManager.GetLogger(typeof(POYouTube));

        public POYouTube(IWebDriver driver) 
        {
            _webDriver = driver;
            XmlConfigurator.Configure(new FileInfo("../../../LoggerConfig.xml"));
        }

    public string GoToYouTubeLink(string link)
        {
            return _webDriver.Url = link;
        }

        public void SearchPhrase(string phrase)
        {
            GetTxtSearch().SendKeys(phrase);
            GetTxtSearch().Submit();
        }

        public void ClickOnFilterButton()
        {
            FilterButton().Click();
        }


        public void SelectItemFromFilterPopUp(string item)
        {
            SelectItem(item);
        }

        public void SelectGivenVideo(string urlOfVideo)
        {
            SelectVideoByURL(urlOfVideo);
        }

        public void ExtractMetaData()
        {
            string medaData = SelectMoreToExpand();
            log.Info("Artist is " + medaData);
        }

        public string SelectMoreToExpand()
        {
            IWebElement el= _webDriver.FindElement(By.XPath("//tp-yt-paper-button[@id='expand']"));
            Thread.Sleep(5000);
            if(el.Enabled)
            {
                el.Click();
            }
            
            return _webDriver.FindElement(By.XPath("//*[@id='description-inline-expander']/yt-attributed-string/span/span")).GetAttribute("innerText");            
        }

        public void ExtractUserChannel()
        {
            IList<IWebElement> ownerName = _webDriver.FindElements(By.XPath("//div[contains(@class,'ytd-channel-name')]//a"));
            
            int i = 0;
            foreach (IWebElement el in ownerName)
            {
                if (i == 0)
                {
                    string channel = el.GetAttribute("innerText");
                    log.Info("channel is " + channel);
                    i++;
                    return;
                }
            }
                
        }

        public void SelectVideoByURL(string url)
        {   
            string[] words = url.Split('=');
            string urlCode = words[1];
            IList<IWebElement> allLinks = _webDriver.FindElements(By.XPath("//*[@id='thumbnail']"));

            foreach (IWebElement el in allLinks)
            {
                String link = el.GetAttribute("href");
                if(link != null)
                {
                    if (link.Contains(urlCode))
                    {
                        el.Click();
                        return;
                    }
                }
               
            }
            
        }

        public void SelectItem(string item)
        {
            IList<IWebElement> types = _webDriver.FindElements(By.XPath("//*[@id='label']/yt-formatted-string"));
            foreach (IWebElement el in types)
            {
               string value = el.GetAttribute("outerText");

                if (value.Equals(item))
                {
                    el.Click();
                    return;
                }
            }
        }

        public IWebElement GetTxtSearch()
        {
            return _webDriver.FindElement(By.XPath("//input[@id='search']"));
        }

        public IWebElement FilterButton()
        {
            return _webDriver.FindElement(By.XPath("//*[@id='filter-button']/ytd-button-renderer/yt-button-shape/button"));
        }
    }
}
