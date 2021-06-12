using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SiteConsumoAPIFinanceiro.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SiteConsumoAPIFinanceiro.Client
{
    public class APIFinanceiroClient
    {
        private HttpClient _client;
        private IConfiguration _configuration;
        private ILogger<APIFinanceiroClient> _logger;

        public APIFinanceiroClient(HttpClient client, IConfiguration configuration, ILogger<APIFinanceiroClient> logger)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _configuration = configuration;
            _logger = logger;
        }

        public string ObterDadosFinanceiro()
        {
            var response = _client.GetAsync(_configuration.GetSection("UrlApiFinanceiro").Value).Result;

            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode) _logger.LogInformation("Resultado normal: " + result);
            else _logger.LogError("Erro: " + result);
            LogFileHelper.WriteMessage(result);

            response.EnsureSuccessStatusCode();
            return result;
        }

    }
}
