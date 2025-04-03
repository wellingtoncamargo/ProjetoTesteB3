using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using BoDi;

namespace ProjetoTesteB3.Common
{

    public class Bootstrapper : IDisposable
    {
        protected IWebDriver Driver { get; }

        public Bootstrapper(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(new ChromeDriver(), typeof(IWebDriver));
            Driver = objectContainer.Resolve<IWebDriver>();
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
