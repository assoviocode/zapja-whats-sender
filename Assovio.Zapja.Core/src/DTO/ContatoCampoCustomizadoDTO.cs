using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assovio.Zapja.Core.DTO
{
    public class ContatoCampoCustomizadoDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("valor")]
        public string? Valor { get; set; }

        [JsonProperty("campo_customizado")]
        public CampoCustomizadoDTO? CampoCustomizado { get; set; }
    }
}
