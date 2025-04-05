# ProjetoTesteB3

🚗 **Projeto de Testes Automatizados - Tricentis Sample App**

Este repositório contém uma suíte de testes automatizados desenvolvida em **C#** utilizando o **Selenium WebDriver**, **NUnit** e o padrão **Page Object Model (POM)**. Os testes são aplicados sobre o sistema de demonstração fornecido pela **Tricentis**.

---

## 🧪 Tecnologias Utilizadas

- [x] C#
- [x] Selenium WebDriver
- [x] NUnit
- [x] ChromeDriver
- [x] Page Object Model (POM)
- [x] BoDi (Injeção de Dependência)
- [x] .NET Core

---

## 🔍 Estrutura do Projeto

```plaintext
ProjetoTesteB3/
│
├── Common/               # Classes auxiliares, WebDriver e Bootstrap
├── Pages/                # Objetos de Página (Page Object Model)
├── Data/                 # Arquivos auxiliares
├── Capturas/             # Captura de telas durante os testes
└── README.md             # Documentação do projeto
```
---

## ▶️ Como Executar os Testes

### ✔️ Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) instalado
- Google Chrome atualizado

### 🚀 Executar via terminal

```bash
dotnet restore
dotnet test
```

---

## 📸 Captura de Tela
- O projeto salva capturas de tela automaticamente durante a execução dos testes (quando implementado), e os arquivos são armazenados na pasta Capturas/.
