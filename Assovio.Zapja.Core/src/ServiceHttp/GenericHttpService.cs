using System.Configuration;
using System.Text;

namespace Assovio.Zapja.Core.ServiceHttp
{
    public abstract class GenericHttpService
    {

        protected HttpClient _client = new HttpClient();

        protected string _token;

        public GenericHttpService()
        {
            string uri = ConfigurationManager.AppSettings["ConnectionAPI"]!;
            _client.BaseAddress = new Uri(uri);
            _client.Timeout = TimeSpan.FromMinutes(10);
        }


        protected virtual async Task<string> GetToken()
        {
            try
            {

                if (!_client.DefaultRequestHeaders.Contains("Authorization") && !string.IsNullOrEmpty(_token))
                {
                    _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
                }

                return _token;

            }
            catch (Exception ex)
            {
                throw new Exception("Problema ao autenticar.");
            }
        }

        protected async Task<string> GetAll(string resource)
        {
            try
            {

                await GetToken();

                string response = await _client.GetStringAsync(resource);

                if (response != null && !response.Equals("[]"))
                {
                    return response;
                }

                return null;


            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Erro GET - " + resource + " - " + hre.Message);
                return null;
            }
        }

        public async Task<string> Get(string resource)
        {
            try
            {
                await GetToken();
                return await _client.GetStringAsync(resource);
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Erro GET - " + resource + " - " + hre.Message);
                throw hre;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro GET - " + resource + " - " + e.Message);
                throw e;
            }
        }

        public async Task<HttpResponseMessage> Post(string resource, string jsonContent)
        {
            try
            {
                HttpContent dataJson = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                await GetToken();

                HttpResponseMessage result = await _client.PostAsync(resource, dataJson);
                var response = "";
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return result;
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Erro POST - " + resource + " - " + hre.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro POST - " + resource + " - " + e.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Put(string resource, string jsonContent)
        {
            try
            {
                HttpContent dataJson = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                await GetToken();

                HttpResponseMessage result = await _client.PutAsync(resource, dataJson);
                var response = "";
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return result;
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Erro PUT - " + resource + " - " + hre.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro PUT - " + resource + " - " + e.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Delete(string resource)
        {
            try
            {
                await GetToken();

                HttpResponseMessage result = await _client.DeleteAsync(resource);
                var response = "";
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return result;
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Erro DELETE - " + resource + " - " + hre.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro DELETE - " + resource + " - " + e.Message);
                return null;
            }
        }
    }
}
