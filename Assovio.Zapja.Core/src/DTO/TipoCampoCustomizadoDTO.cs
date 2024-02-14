using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO
{
    public class TipoCampoCustomizadoDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("mascara")]
        public string? Mascara { get; set; }
    }
}
