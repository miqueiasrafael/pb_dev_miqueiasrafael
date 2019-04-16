using Microsoft.EntityFrameworkCore;
using PBWebApi.DataAccess.Models;

namespace PBWebApi.DataAccess
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }        
    }

    //Case optional for context
    public enum EnderecoFake
    {
        [System.Runtime.Serialization.EnumMember(Value = "0")]
        Null,
        [System.Runtime.Serialization.EnumMember(Value = "1")]
        Temporario
    }

}
