using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjetoTesteB3.Pages;

namespace ProjetoTesteB3
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private FormDadosVeiculo _pageFormDadosVeiculo;
        private FormDadosSegurador _pageFormDadosSegurador;


        [SetUp]
        public void Setup()
        {
            //var opcoes = new ChromeOptions();
            //opcoes.AddArguments("--Headless");
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1920);
            _pageFormDadosVeiculo = new FormDadosVeiculo(_driver);
            _pageFormDadosSegurador = new FormDadosSegurador(_driver);
            _pageFormDadosVeiculo.AbrirPaginaTricentis();
        }

        [TestCase(TestName = "Teste-01 Formulario Dados Veiculo",
            Description = "Preencher formulario de dados do Veiculo")]
        public void TesteFormDadosVeiculo()
        {
            _pageFormDadosVeiculo.ValidarAbaDadosVeiculo();
            _pageFormDadosVeiculo.SelecionaMarca();
            _pageFormDadosVeiculo.SelecionaModelo();
            _pageFormDadosVeiculo.ValidaTextoCapacidadeCilindrada();
            _pageFormDadosVeiculo.PreencheCapacidadeCilindrada();
            _pageFormDadosVeiculo.PreenchePerformanceMotor();
            _pageFormDadosVeiculo.DataManutencao();
            _pageFormDadosVeiculo.SelecionaNumeroAcentos();
            _pageFormDadosVeiculo.SelecionaPosicaoVolante();
            _pageFormDadosVeiculo.SelecionaNumeroAcentosMoto();
            _pageFormDadosVeiculo.TipoCombustivel();
            _pageFormDadosVeiculo.Carga();
            _pageFormDadosVeiculo.PesoTotal();
            _pageFormDadosVeiculo.ListaPreco();
            _pageFormDadosVeiculo.NumeroLicenciamento();
            _pageFormDadosVeiculo.QuilometragemAnual();
            Thread.Sleep(10000);
            _pageFormDadosVeiculo.ClicaBotaoNextDadosVeiculo();
        }



        [TestCase(TestName = "Teste-02 Formulario Dados Segurador",
            Description = "Preencher formulario de dados do segurador")]
        public void TesteFormDadosSegurador()
        {
            TesteFormDadosVeiculo();
            _pageFormDadosSegurador.ValidaAbaDadosSegurador();
            _pageFormDadosSegurador.PreencheNome();
            _pageFormDadosSegurador.PreencheSobrenome();
            _pageFormDadosSegurador.PreencheDataAniversario();
            _pageFormDadosSegurador.Genero();
            _pageFormDadosSegurador.NomeRua();
            _pageFormDadosSegurador.Pais();
            _pageFormDadosSegurador.CEP();
            _pageFormDadosSegurador.Cidade();
            _pageFormDadosSegurador.SelecionaOcupacao();
            _pageFormDadosSegurador.SelecionaHobbies();
            _pageFormDadosSegurador.PreencherWebSite();
            _pageFormDadosSegurador.InformarArquivo();
            Thread.Sleep(10000);
            _pageFormDadosSegurador.ClicaBotaoNextDadosSegurador();
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("Finalizando teste...");
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
