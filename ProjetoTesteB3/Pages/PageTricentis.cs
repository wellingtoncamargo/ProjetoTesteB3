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
        private readonly PageElements elements;
        public PageTricentis(IWebDriver webDriver) : base(webDriver)
        {
            elements = new PageElements();
        }

        public void AbrirPaginaTricentis()
        {
            _webDriver.Navigate().GoToUrl("https://sampleapp.tricentis.com/101/app.php");
        }

        public void ValidaJanela()
        {
            InputActionIn(elements.id_entervehicledata).Click();
            SelectOption(elements.id_make);

        }


    }
}
