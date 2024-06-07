using CadastroDeClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeClientes.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {
        }

        public DbSet<ClienteModel> Clientes { get; set; } 

    }
}
