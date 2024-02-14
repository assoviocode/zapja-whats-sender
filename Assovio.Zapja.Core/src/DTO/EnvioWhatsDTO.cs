using Assovio.Zapja.Core.DTO.Enum;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Assovio.Zapja.Core.DTO
{
    public class EnvioWhatsDTO
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("celular_origem")]
        public string? CelularOrigem { get; set; }

        [JsonProperty("status")]
        public EnumStatusEnvioWhats Status { get; set; }

        [JsonProperty("log")]
        public string? Log { get; set; }

        [JsonProperty("servidor")]
        public string? Servidor { get; set; }

        [JsonProperty("enviado")]
        public bool Enviado { get; set; } = false;

        [JsonProperty("template_whats")]
        public TemplateWhatsDTO? TemplateWhats { get; set; }

        [JsonProperty("contato")]
        public ContatoDTO? Contato { get; set; }

        public string getMensagemFinal()
        {
            string pattern = "{{(.*?)}}";
            if (!string.IsNullOrEmpty(TemplateWhats!.Texto) && !string.IsNullOrEmpty(Contato!.Nome))
            {

                string textoTemplate = TemplateWhats.Texto;

                var chaves = Regex.Matches(textoTemplate, pattern);

                foreach (var chave in chaves)
                {
                    string chaveTratada = this.GetStringValida(chave.ToString()!);

                    if (chaveTratada == "{{NOME}}")
                    {
                        textoTemplate = textoTemplate.Replace(chaveTratada, this.Contato.Nome);
                    }
                    else if (chaveTratada == "{{NUMERO_WHATSAPP}}")
                    {
                        textoTemplate = textoTemplate.Replace(chaveTratada, this.Contato.NumeroWhats!);
                    }
                    else
                    {
                        foreach (ContatoCampoCustomizadoDTO contatoCampoCustomizadoDTO in this.Contato.ContatoCampoCustomizadoList!)
                        {
                            string rotuloChave = "{{" + this.GetStringValida(contatoCampoCustomizadoDTO.CampoCustomizado!.Rotulo!.Replace(" ", "_").ToUpper().Trim()) + "}}";

                            if (rotuloChave.Equals(chaveTratada))
                            {
                                if (contatoCampoCustomizadoDTO != null && !String.IsNullOrEmpty(chaveTratada))
                                {
                                    textoTemplate = textoTemplate.Replace(chaveTratada, contatoCampoCustomizadoDTO.Valor);
                                    break;
                                }
                                else
                                {
                                    textoTemplate = textoTemplate.Replace(chaveTratada, String.Empty);
                                    break;
                                }
                            }
                        }
                    }
                }


                return !string.IsNullOrEmpty(textoTemplate) ? textoTemplate : string.Empty;
            }

            return string.Empty;
        }

        public virtual string getPrimeiroNomeDestino()
        {
            string nomeDestino = Contato.Nome;

            if (nomeDestino.IndexOf(" ") != -1)
                return nomeDestino.Substring(0, nomeDestino.IndexOf(" "));

            return nomeDestino;
        }

        private string GetStringValida(string texto)
        {
            string normalized = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalized.Length; i++)
            {
                char c = normalized[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Replace("{{{", "{{").Replace("}}}", "}}").Trim();
        }

    }
}
