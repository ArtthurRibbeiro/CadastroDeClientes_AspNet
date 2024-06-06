using AspNetCore;
using CadastroDeClientes.Helpers;
using CadastroDeClientes.Models;
using CadastroDeClientes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        [HttpGet("todos")]
        public List<ClienteModel> ListarTodos()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return clientes;   

        }
        [HttpGet("id/{id}")]
        public ClienteModel BuscarPorId(int id) {

            return _clienteRepositorio.BuscarPorId(id);
        {

        }
        [HttpGet("codigo/{codigo}")]
        public ClienteModel BuscarPorCodigo(String codigo)
        {

        }
        [HttpGet("cpf-cnpj/{documento}")]
        public ClienteModel BuscarPorDocumento(String documento)
        {

        }
        [HttpGet("nome-razao-social/{nomeRazaoSocial}")]
        public ClienteModel BuscarPorNomeRazaoSocial(String nomeRazaoSocial)
        {

        }
        [HttpPost("")]
        public ActionResult<ClienteModel>  Criar(ClienteModel cliente)
        {
                cliente.Inclusao = DataHelper.DataFormatada();
                cliente.Alteracao = DataHelper.DataFormatada();

                try
                {
                    if (ModelState.IsValid)
                    {
                        _clienteRepositorio.Adicionar(cliente);
                        return cliente;
                    }

                    return
                }


        }
        [HttpPut("")]
        public ClienteModel Alterar(ClienteModel cliente)
        {

        }

        public bool Deletar(int id)
        {
            return true;
        }
        
    }
}
