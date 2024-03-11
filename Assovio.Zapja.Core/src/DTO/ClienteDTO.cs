using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO
{
    public class ClienteDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("qr_code_whats")]
        public byte[]? QrCodeWhats { get; set; }

    }
}
