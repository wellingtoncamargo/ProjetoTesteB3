using System.Text.RegularExpressions;
using OpenQA.Selenium;
using ProjetoTesteB3.Common;

namespace ProjetoTesteB3.Pages
{
    public class FormDadosSegurador : Acoes
    {
        private readonly PageElements elements;

        public FormDadosSegurador(IWebDriver webDriver) : base(webDriver)
        {
            elements = new PageElements();
        }

        public void ValidaAbaDadosSegurador()
        {
            var nome = RealizeEm(elements.id_enterinsurantdata);
            var sanit = Regex.Replace(nome.Text, @"[\r\n|0-9]", "");
            Assert.That(sanit, Is.EqualTo("Enter Insurant Data"));
            CapturaTela(nome.Text);
        }

        public void PreencheNome()
        {
            RealizeEm(elements.id_firstname).SendKeys(Faker.Name.First());
        }

        public void PreencheSobrenome()
        {
            RealizeEm(elements.id_lastname).SendKeys(Faker.Name.Last());
        }

        public void PreencheDataAniversario()
        {
            DateTime data = DateTime.Now;
            RealizeEm(elements.id_birthdate).SendKeys(GeradorData(data.Year - 18, data.Year - 60));
        }

        public void SelecionaOcupacao()
        {
            SelecionaOpcao(elements.id_occupation);
        }

        public void SelecionaHobbies()
        {
            var saltar = RealizeEm(elements.id_skydiving);
            RolarPagina(saltar);
            RealizeEm(elements.id_speeding).Click();
            RealizeEm(elements.id_bungeejumping).Click();
            RealizeEm(elements.id_skydiving).Click();
        }

        public void PreencherWebSite()
        {
            RealizeEm(elements.id_website).SendKeys("https://storage.googleapis.com/novo-blog-wordpress/2023/07/c34a5169-como-ler-imagens-1024x464.jpg");
        }

        public void ClicaBotaoNextDadosSegurador()
        {
            IWebElement footer = RealizeEm(elements.id_nextenterproductdata);
            RolarPagina(footer);
            CapturaTela($"nextenterproductdata_scrollPage");
            footer.Click();
            var proximaTela = RealizeEm(elements.id_nextselectpriceoption);
            CapturaTela($"nextselectpriceoption");
        }
    }
}
