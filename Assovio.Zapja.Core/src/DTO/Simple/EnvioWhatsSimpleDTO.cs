using Assovio.Zapja.Core.DTO.Enum;
using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO.Simple
{
    public class EnvioWhatsSimpleDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("numero_whats")]
        public string? NumeroWhats { get; set; }

        [JsonProperty("nome_contato")]
        public string? NomeContato { get; set; }

        [JsonProperty("nome_template")]
        public string? NomeTemplate { get; set; }

        [JsonProperty("numero_origem")]
        public string? NumeroOrigem { get; set; }

        [JsonProperty("status")]
        public EnumStatusEnvioWhats Status { get; set; }

        [JsonProperty("data_envio")]
        public DateTime DataEnvio { get; set; }
    }
}
