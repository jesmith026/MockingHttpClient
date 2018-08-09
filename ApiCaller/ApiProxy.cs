using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ApiCaller
{
    public class ApiProxy
    {
        protected HttpClient _client;

        public ApiProxy()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:61811/")
            };
        }

        public async Task<List<string>> GetValues()
        {
            try
            {
                var response = _client.GetAsync("api/Values");
                return await response.Result.Content.ReadAsAsync<List<string>>();
            }
            catch (Exception e)
            {
                throw new ServiceFailedException(e);
            }
        }
    }
}