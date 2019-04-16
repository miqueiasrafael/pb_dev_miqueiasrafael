using Microsoft.EntityFrameworkCore;
using PBWebApi.DataAccess.Models;

namespace PBWebApi.DataAccess
{
    public class EnderecoContext : DbContext
    {
        public EnderecoContext(DbContextOptions<EnderecoContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}
