using Assovio.Zapja.Core.DTO;
using Assovio.Zapja.Core.DTO.Page;
using Newtonsoft.Json;
using System.Net;

namespace Assovio.Zapja.Core.ServiceHttp
{
    public class EnvioWhatsHttpService : GenericHttpService
    {
        private string _pathEnvioWhats = "enviosWhats";

        public async Task<EnvioWhatsPageDTO> Index(Dictionary<string, object> mapFilters)
        {

            string path = GetPathWithMapFilters(_pathEnvioWhats, mapFilters);

            string response = await GetAll(path);

            if (!string.IsNullOrEmpty(response))
            {
                EnvioWhatsPageDTO? responseList = JsonConvert.DeserializeObject<EnvioWhatsPageDTO>(response);

                if (responseList != null)
                {
                    return responseList;
                }
            }

            return null!;

        }

        public async Task<EnvioWhatsDTO?> Show(int id)
        {
            string response = await Get($"{_pathEnvioWhats}/{id}");

            if (response != null)
            {
                return JsonConvert.DeserializeObject<EnvioWhatsDTO>(response)!;
            }

            return null;

        }

        public async Task<EnvioWhatsDTO> Update(EnvioWhatsDTO dto)
        {

            if (dto == null || dto.Id == 0)
                throw new ArgumentException("Envio Whats nulo");

            HttpResponseMessage response;

            string jsonContent = JsonConvert.SerializeObject(dto);

            string path = $"{_pathEnvioWhats}/{dto.Id}";
            response = await Put(path, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<EnvioWhatsDTO>(json)!;

            }

            throw new Exception("Problema ao salvar Envio Whats");
        }

        public async Task<EnvioWhatsDTO?> ShowProximo()
        {
            try
            {
                string response = await Get($"{_pathEnvioWhats}/proximo");

                if (response != null)
                {
                    return JsonConvert.DeserializeObject<EnvioWhatsDTO>(response)!;
                }

            }
            catch (HttpRequestException hre)
            {
                if (hre.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    Console.WriteLine("Nenhum envio na fila! Nova tentativa em 60s...");
                    Thread.Sleep(1000 * 10);
                    return null;
                }
            }

            return null;
        }

        public async Task<EnvioWhatsDTO> UpdateEnviado(EnvioWhatsDTO dto)
        {

            if (dto == null || dto.Id == 0)
                throw new ArgumentException("Envio Whats nulo");

            HttpResponseMessage response;

            string jsonContent = JsonConvert.SerializeObject(dto);

            string path = $"{this._pathEnvioWhats}/{dto.Id}/enviado";
            response = await Put(path, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<EnvioWhatsDTO>(json)!;

            }

            throw new Exception("Problema ao salvar Envio Whats");
        }

        protected string GetPathWithMapFilters(string pathBase, Dictionary<string, object> mapFilters)
        {
            if (mapFilters != null && mapFilters.Count() > 0)
            {
                string stringFilters = string.Empty;

                foreach (var filter in mapFilters)
                {
                    stringFilters = $"{stringFilters}{filter.Key}={filter.Value}  ";
                }

                pathBase = $"{pathBase}?{stringFilters.TrimStart().TrimEnd().Replace("  ", "&").Trim()}";

            }

            return pathBase;
        }
    }
}
