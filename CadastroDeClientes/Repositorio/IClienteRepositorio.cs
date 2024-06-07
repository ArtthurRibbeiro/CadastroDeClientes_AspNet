using CadastroDeClientes.Models;

namespace CadastroDeClientes.Repositorio
{
    public interface IClienteRepositorio
    {

        public List<ClienteModel> BuscarTodos();

        public ClienteModel BuscarPorId(int id);

        public ClienteModel Adicionar(ClienteModel cliente);

        public ClienteModel Editar(ClienteModel cliente);

        public bool Excluir(int id);
    }
}
