using System.Text.RegularExpressions;
using OpenQA.Selenium;
using ProjetoTesteB3.Common;

namespace ProjetoTesteB3.Pages
{
    public class FormDadosVeiculo : Acoes
    {
        private readonly PageElements elements;
        public FormDadosVeiculo(IWebDriver webDriver) : base(webDriver)
        {
            elements = new PageElements();
        }

        public void AbrirPaginaTricentis()
        {
            _webDriver.Navigate().GoToUrl("https://sampleapp.tricentis.com/101/app.php");
        }

        public void ValidarAbaDadosVeiculo()
        {
            var nome = RealizeEm(elements.id_entervehicledata);
            var sanit = Regex.Replace(nome.Text, @"[\r\n|0-9]", "");
            Assert.That(sanit, Is.EqualTo("Enter Vehicle Data"));
            nome.Click();
            CapturaTela(nome.Text);
        }

        public void SelecionaMarca()
        {
            SelecionaOpcao(elements.id_make);
        }

        public void SelecionaModelo()
        {
            SelecionaOpcao(elements.id_model);
        }

        public void ValidaTextoCapacidadeCilindrada()
        {
            var cilindradaText = RealizeEm(elements.id_cylindercapacityText);
            var sanit = Regex.Replace(cilindradaText.Text, @"[\r\n|0-9]", "");
            Assert.That(sanit, Is.EqualTo("Cylinder Capacity [ccm]"));
        }

        public void PreencheCapacidadeCilindrada()
        {
            RealizeEm(elements.id_cylindercapacity).SendKeys(new Random().Next(1000).ToString());
        }

        public void PreenchePerformanceMotor()
        {
            RealizeEm(elements.id_engineperformance).SendKeys(new Random().Next(50).ToString());
        }

        public void SelecionaNumeroAcentos()
        {
            SelecionaOpcao(elements.id_numberofseats);
        }

        public void SelecionaPosicaoVolante()
        {
            RealizeEm(elements.id_righthanddriveyes).Click();
        }

        public void TipoCombustivel()
        {
            SelecionaOpcao(elements.id_fuel);
        }

        public void ClicaBotaoNextDadosVeiculo()
        {
            IWebElement botaoNext = RealizeEm(elements.id_nextenterinsurantdata);
            RolarPagina(botaoNext);
            CapturaTela($"nextenterinsurantdata_scrollPage");
            botaoNext.Click();
            var proximaTela = RealizeEm(elements.id_enterinsurantdata);
            CapturaTela($"enterinsurantdata");
        }
    }
}
