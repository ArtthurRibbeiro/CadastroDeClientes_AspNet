using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CadastroDeClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(HttpClient httlpClient)
        {
            _httpClient = httlpClient;
        }


        [HttpGet("cnpj/{cnpj}")]

        public async Task<IActionResult> GetCnpjInfo(string cnpj)
        {
            var response = await _httpClient.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpj}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");


        }
    }
}
