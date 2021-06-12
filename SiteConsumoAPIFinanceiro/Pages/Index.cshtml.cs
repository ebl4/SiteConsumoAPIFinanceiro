using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SiteConsumoAPIFinanceiro.Client;

namespace SiteConsumoAPIFinanceiro.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromServices]APIFinanceiroClient client)
        {
            TempData["ResultadoAPIFinanceiro"] =
                client.ObterDadosFinanceiro();
        }
    }
}
