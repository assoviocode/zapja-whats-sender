using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO
{
    public class TemplateWhatsDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("chave")]
        public string? Chave { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [JsonProperty("texto")]
        public string? Texto { get; set; }

        [JsonProperty("path_arquivo")]
        public string? PathArquivo { get; set; }

    }
}
