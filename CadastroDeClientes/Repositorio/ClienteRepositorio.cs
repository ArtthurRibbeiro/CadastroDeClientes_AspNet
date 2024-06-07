using CadastroDeClientes.Data;
using CadastroDeClientes.Models;

namespace CadastroDeClientes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio{

        private BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
            
        }

        public ClienteModel BuscarPorId(int id)
        {
            ClienteModel cliente = _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
            return cliente;
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
            
        }

        public ClienteModel Editar(ClienteModel cliente)
        {
            ClienteModel clienteDb = BuscarPorId(cliente.Id);

            if (clienteDb == null) throw new Exception("Houve um erro na atualização de um registro");

            clienteDb.Codigo = cliente.Codigo;

            clienteDb.Tipo = cliente.Tipo;
            clienteDb.CpfCnpj = cliente.CpfCnpj;
            clienteDb.RgIe = cliente.RgIe;
            clienteDb.NomeRazaoSocial = cliente.NomeRazaoSocial;
            clienteDb.NomeAbreviadoFantasia = cliente.NomeAbreviadoFantasia;

            clienteDb.Cep = cliente.Cep;
            clienteDb.Logradouro = cliente.Logradouro;
            clienteDb.Numero = cliente.Numero;
            clienteDb.Complemento = cliente.Complemento;
            clienteDb.Bairro = cliente.Bairro;
            clienteDb.Municipio = cliente.Municipio;
            clienteDb.UnidadeFederativa = cliente.UnidadeFederativa;

            clienteDb.Email = cliente.Email;
            clienteDb.Telefone = cliente.Telefone;
            clienteDb.Alteracao = cliente.Alteracao;

            _bancoContext.Clientes.Update(clienteDb);
            _bancoContext.SaveChanges();

            return clienteDb;


        }

        public bool Excluir(int id)
        {
            ClienteModel clienteDb = BuscarPorId(id);

            if (clienteDb == null) throw new Exception("Houve um erro na exclusão de um registro");

            _bancoContext.Clientes.Remove(clienteDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
