using CadastroDeClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        public List<ClienteModel> ListarTodos()
        {

        }

        public ClienteModel BuscarPorId(int id)
        {

        }
        public ClienteModel BuscarPorCodigo(String codigo)
        {

        }
        public ClienteModel BuscarPorDocumento(String documento)
        {

        }
        public ClienteModel BuscarPorNomeRazaoSocial(String NomeRazaoSocial)
        {

        }

        public ClienteModel Criar(ClienteModel cliente)
        {

        }

        public ClienteModel Alterar(ClienteModel cliente)
        {

        }

        public bool Deletar(int id)
        {
            return true;
        }
        
    }
}
