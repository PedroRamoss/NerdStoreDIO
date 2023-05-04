using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var body = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44372/api/identidade/autenticar", body);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
        }

        public Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}