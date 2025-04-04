using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ProjetoTesteB3.Common
{
    public class Acoes(IWebDriver webDriver)
    {
        protected readonly IWebDriver _webDriver = webDriver;

        public IWebElement RealizeEm(By by)
        {
            try
            {
                var element = _webDriver.FindElement(by);
                ValidarElemento(element);
                return element;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro inesperado ao buscar elemento {by}: {ex.Message}");
                throw;
            }
        }

        private void ValidarElemento(IWebElement element)
        {
            if (element.Displayed)
            {
                DestacarElemento(element);
            }
        }

        public void SelecionaOpcao(By by)
        {
            var selectElement = RealizeEm(by);
            var lista = new SelectElement(selectElement);
            lista.SelectByIndex(new Random().Next(1, lista.Options.Count()));
        }

        public SelectElement SelecionaPor(By by)
        {
            var selectElement = RealizeEm(by);
            return new SelectElement(selectElement);
        }

        private void DestacarElemento(IWebElement element)
        {
            var js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].style.border='2px dashed red'", element);
        }

        public void RolarPagina(IWebElement element)
        {
            new Actions(_webDriver).ScrollByAmount(0, element.Location.Y).Perform();
        }

        public void CapturaTela(string nome)
        {
            string diretorio = Path.Combine("../../../Capturas");
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            string nomeSanitizado = Regex.Replace(nome.Replace(" ", ""), @"[\r\n]", "");
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nomeArquivo = $"{nomeSanitizado}_{timestamp}.png";
            string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);

            Screenshot ss = ((ITakesScreenshot)_webDriver).GetScreenshot();
            ss.SaveAsFile(caminhoCompleto);
        }

        public string GeradorData(int anoMin, int anoMax)
        {
            Random rnd = new Random();
            DateTime data = new DateTime(rnd.Next(anoMax, anoMin), rnd.Next(1, 13), rnd.Next(1, 28));
            return data.ToString("MM/dd/yyyy");
        }

    }
}
