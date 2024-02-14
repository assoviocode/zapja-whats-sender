using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO
{
    public class ContatoDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("numero_whats")]
        public string? NumeroWhats { get; set; }

        [JsonProperty("contato_campos_customizados")]
        public List<ContatoCampoCustomizadoDTO>? ContatoCampoCustomizadoList { get; set; }

    }
}
