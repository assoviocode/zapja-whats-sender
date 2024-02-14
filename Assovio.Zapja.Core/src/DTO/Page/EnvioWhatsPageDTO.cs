using Assovio.Zapja.Core.DTO.Simple;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assovio.Zapja.Core.DTO.Page
{
    public class EnvioWhatsPageDTO : PageDTO
    {
        [JsonProperty("content")]
        public List<EnvioWhatsSimpleDTO>? Content { get; set; }
    }
}
