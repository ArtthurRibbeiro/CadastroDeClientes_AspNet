using CadastroDeClientes.Models;

namespace CadastroDeClientes.Repositorio
{
    public interface IClienteRepositorio
    {

        public List<ClienteModel> BuscarTodos();

        public ClienteModel BuscarPorId(int id);
        public ClienteModel BuscarPorCodigo(String codigo);
        public ClienteModel BuscarPorDocumento(String documento);
        public ClienteModel BuscarPorNomeRazaoSocial(String nomeRazaoSocial);
        public ClienteModel Adicionar(ClienteModel cliente);

        public ClienteModel Editar(ClienteModel cliente);

        public bool Excluir(int id);
    }
}
