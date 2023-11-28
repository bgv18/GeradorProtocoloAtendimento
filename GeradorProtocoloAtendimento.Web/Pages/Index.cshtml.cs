using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeradorProtocoloAtendimento.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _url = "https://localhost:44397/api";
        }

        public string Protocolo { get; set; }
        public void OnGet()
        {

        }

        public void OnPostSubmit(string idEmpresa, DateTime data)
        {
            try
            {
                var response = _httpClient.GetAsync($"{_url}/Gerar?empresaId={idEmpresa}&data={data}").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    this.Protocolo = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                else
                {
                    this.Protocolo = "Erro ao gerar protocolo(API)";
                }
            }
            catch (Exception ex)
            {
                this.Protocolo = "Erro ao gerar protocolo" + ex.Message;
            }
        }
    }
}