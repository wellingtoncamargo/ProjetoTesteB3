using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;

namespace ProjetoTesteB3.Common
{
    public class Actions
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _actions;
        private Actions webDriver;

        public Actions(IWebDriver webDriver)
        {  _webDriver = webDriver; }

        public void openPage(string url) { 
            _webDriver.Navigate().GoToUrl(url);
        }
        public void closePage()
        {
            _webDriver.Close();

        }

        //public IWebElement getText(By by)
        //{
        //    _actions = _webDriver.FindElement(by);
        //    return _actions;
        //}

        //public IWebElement sendKeys(By by)
        //{
        //    _actions = _webDriver.FindElement(by);
        //    _actions.Clear();
        //    return _actions;
        //}

        public IWebElement inputActionIn(By by)
        {
            _actions = _webDriver.FindElement(by);
            emphasis();
            return _actions;
        }

        private void emphasis() {
            if (_actions.Displayed)
            {
                highlightElement(_actions);
            }
        }

        private static void highlightElement(IWebElement element)
        {
            //try
            //{
            //    if ( _webDriver Instanceof JavascriptExecutor) {
            //        ((JavascriptExecutor)_webDriver()).executeScript("arguments[0].style.border='2px dashed red'", element);
            //        ((JavascriptExecutor)_webDriver()).executeScript("arguments[0].style.border='1,5'", element);
            //        wait(1);
            //        ((JavascriptExecutor)_webDriver()).executeScript("arguments[0].style.border=''", element);
            //        ((JavascriptExecutor)_webDriver()).executeScript("arguments[0].style.border=''", element);
            //    }
            //}
            //catch (Exception e)
            //{
            //    log.error(String.format("O elemento não esta visivel para o Highlight: %s", e));
            //}

            IJavaScriptExecutor js = (IJavaScriptExecutor)element;
            js.ExecuteScript("arguments[0].style.border='2px dashed red'");
            js.ExecuteScript("arguments[0].style.border='1,5'");
            js.ExecuteScript("arguments[0].style.border=''");
            js.ExecuteScript("arguments[0].style.border=''");
        }

    }
}
