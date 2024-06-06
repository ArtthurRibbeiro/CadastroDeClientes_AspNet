using CadastroDeClientes.Helpers;
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
            try
            {
            _clienteRepository.Excluir(id);

                TempData["MensagemConfirm"] = "Registro deletado com sucesso";
            return RedirectToAction("Index");

            } catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Falha ao deletar um registro, Erro: {ex.Message}";
                return RedirectToAction("Index");
            }

            
        }


        [HttpPost]
        public IActionResult Criar(ClienteModel cliente){

            

            cliente.Inclusao = DataHelper.DataFormatada();;
            cliente.Alteracao = DataHelper.DataFormatada();;

            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.Adicionar(cliente);


                    TempData["MensagemConfirm"] = "Cliente Cadastrado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Falha no cadastro de Cliente, Erro: {ex.Message}";
                return RedirectToAction("Index");

            }

            
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            cliente.Alteracao = DataHelper.DataFormatada();

            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.Editar(cliente);

                    TempData["MensagemConfirm"] = "Registro editado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(cliente);
            }catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Falha no cadastro de Cliente, Erro: {ex.Message}";
                return RedirectToAction("Index");

            }

        }

    }
}
