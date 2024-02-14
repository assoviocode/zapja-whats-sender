using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO
{
    public class CampoCustomizadoDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rotulo")]
        public string? Rotulo { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [JsonProperty("obrigatorio")]
        public bool Obrigatorio { get; set; }

        [JsonProperty("tipo_campo_customizado")]
        public TipoCampoCustomizadoDTO? TipoCampoCustomizado { get; set; }
    }
}
