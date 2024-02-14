using Newtonsoft.Json;

namespace Assovio.Zapja.Core.DTO.Page
{
    public class PageDTO
    {
        [JsonProperty("pageable")]
        public Pageable? Pageable { get; set; }

        [JsonProperty("first")]
        public bool First { get; set; }

        [JsonProperty("last")]
        public bool Last { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

    }

    public class Pageable
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
