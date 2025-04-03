using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using ProjetoTesteB3.Common;

namespace ProjetoTesteB3.Pages
{
    public class PageTricentis : Actions
    {
        private readonly Actions _action;

        public PageTricentis(IWebDriver webDriver) : base(webDriver)
        {
            _action = new Actions(webDriver);
        }

        public void abrirPaginaTricentis()
        {
            _action.openPage("https://sampleapp.tricentis.com/101/app.php");
        }

        public void validaJanela()
        {
            _action.inputActionIn(By.Id("entervehicledata")).Click();
        }


    }
}
