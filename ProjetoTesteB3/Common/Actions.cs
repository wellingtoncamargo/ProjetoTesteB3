using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ProjetoTesteB3.Common
{
    public class Actions
    {
        protected readonly IWebDriver _webDriver;

        public Actions(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public IWebElement InputActionIn(By by)
        {
            var element = _webDriver.FindElement(by);
            EmphasizeElement(element);
            return element;
        }

        private void EmphasizeElement(IWebElement element)
        {
            if (element.Displayed)
            {
                HighlightElement(element);
            }
        }

        public void SelectOption(By by)
        {
            var selectElement = InputActionIn(by);
            var lista = new SelectElement(selectElement);
                lista.SelectByIndex(new Random().Next(1, lista.Options.Count()));
        }

        private void HighlightElement(IWebElement element)
        {
            var js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].style.border='2px dashed red'", element);
            Thread.Sleep(500); 
            js.ExecuteScript("arguments[0].style.border=''", element);
        }

    }
}
