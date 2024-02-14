using Assovio.Zapja.Core;
using Assovio.Zapja.Core.DTO;
using Assovio.Zapja.Core.ServiceHttp;
using Assovio.Zapja.WhatsApp.Exceptions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Assovio.Zapja.WhatsApp
{
    public class WhatsAppSender : WhatsAppSeleniumBot
    {
        private EnvioWhatsHttpService _envioWhatsHttpService;
        private Random _random = new Random();

        public WhatsAppSender()
        {
            this._envioWhatsHttpService = new EnvioWhatsHttpService();

            this.CreateChromeDriver();
        }

        public async Task Send(EnvioWhatsDTO envioWhatsDTO)
        {

            string uri = $"https://web.whatsapp.com/send?phone=[55{envioWhatsDTO!.Contato!.NumeroWhats}]";
            this._driver.Navigate().GoToUrl(uri);

            this.Aguardar(5);

            while (this._driver.PageSource.Contains("Use o WhatsApp no seu computador"))
            {
                this.Aguardar(5);
            }

            this.Aguardar(20);

            if (this._driver.PageSource.Contains("O número de telefone compartilhado através de url é inválido."))
            {
                this._driver.FindElement(By.XPath("/html/body/div[1]/div/span[2]/div/span/div/div/div/div/div/div[2]/div/div/div/div")).Click();
                throw new NumeroInvalidoException("O número de telefone compartilhado através de url é inválido.");
            }

            this.SendMessage(envioWhatsDTO.getMensagemFinal());

            this.SendFile(envioWhatsDTO.TemplateWhats?.PathArquivo);

            this.Aguardar(this._random.Next(15, 35));

            await this._envioWhatsHttpService.UpdateEnviado(envioWhatsDTO);
        }

        private void SendMessage(string message)
        {
            this.WaitUntil(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[text()='Iniciando conversa']")));

            if (!string.IsNullOrEmpty(message))
            {
                var caracteres = message.Replace("\n", " ").ToCharArray();

                this._wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@title='Digite uma mensagem']/p")));

                var inputMessage = this.GetElement("//div[@title='Digite uma mensagem']/p", Selenium.EnumKeyType.X_PATH);

                foreach (char caractere in caracteres)
                {
                    inputMessage.SendKeys(caractere.ToString());
                    Thread.Sleep(10);
                }

                this.Aguardar(2);

                this.ClickOnButton("//button[@aria-label='Enviar']", Selenium.EnumKeyType.X_PATH);
            }


        }

        private void SendFile(string? pathImage)
        {
            if (!string.IsNullOrEmpty(pathImage) && File.Exists(pathImage))
            {
                this._driver.FindElement(By.CssSelector("span[data-icon='clip']")).Click();
                this.Aguardar(2);
                this._driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(pathImage);
                this.Aguardar(2);
                this._driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
            }
        }

        public void StopMessages()
        {
            this.CloseDriver();
        }

    }
}
