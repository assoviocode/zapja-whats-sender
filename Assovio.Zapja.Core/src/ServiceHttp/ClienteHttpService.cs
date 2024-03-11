using Assovio.Zapja.Core.DTO;
using Newtonsoft.Json;
using System.Net;

namespace Assovio.Zapja.Core.ServiceHttp
{
    public class ClienteHttpService : GenericHttpService
    {
        private string _pathClientes = "clientes";


        public async Task UploadQrCodeWhats(ClienteDTO dto)
        {
            if (dto == null || dto.Id == 0)
                throw new ArgumentException("Cliente nulo");

            string jsonContent = JsonConvert.SerializeObject(dto);

            string path = $"{this._pathClientes}/{dto.Id}/qrCodeWhats/upload";

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(dto.QrCodeWhats!), "qr_code_whats", "qrCode.png");

                using (var message = await this._client.PostAsync(path, content))
                {
                    if (!message.StatusCode.Equals(HttpStatusCode.Created))
                    {
                        throw new Exception("Problema ao salvar QrCode do Whats");
                    }
                }
            }
        }

        public async Task UpdateQrCodeValido(ClienteDTO dto)
        {
            if (dto == null || dto.Id == 0)
                throw new ArgumentException("Cliente nulo");

            HttpResponseMessage response;

            string jsonContent = JsonConvert.SerializeObject(dto);

            string path = $"{this._pathClientes}/{dto.Id}/autenticado";

            response = await Put(path, jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Problema ao salvar Cliente!");
            }

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
