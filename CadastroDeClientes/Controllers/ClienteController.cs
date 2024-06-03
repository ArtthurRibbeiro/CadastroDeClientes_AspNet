using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar(){
        return View();
        }
    }
}
