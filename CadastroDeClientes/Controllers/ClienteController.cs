using CadastroDeClientes.Models;
using CadastroDeClientes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteRepositorio _clienteRepository;
        public ClienteController(IClienteRepositorio clienteRepositorio){
            _clienteRepository = clienteRepositorio;
        }

        public IActionResult Index(){

            List<ClienteModel> clientes =  _clienteRepository.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Criar() {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarPorId(id);




            return View(cliente);
        }

        public IActionResult ConfirmarExclusao(int id)
        {

            ClienteModel cliente = _clienteRepository.BuscarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            _clienteRepository.Excluir(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(ClienteModel cliente){

            cliente.Inclusao = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cliente.Alteracao = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                _clienteRepository.Adicionar(cliente);
                return RedirectToAction("Index");

            }

            return View(cliente);
            
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            cliente.Alteracao = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (ModelState.IsValid)
            {
                _clienteRepository.Editar(cliente);
                return RedirectToAction("Index");

            }

            return View(cliente);

        }

    }
}
