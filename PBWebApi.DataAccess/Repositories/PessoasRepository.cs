using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBWebApi.DataAccess.Models;
using PBWebApi.DataAccess.Repositories;

namespace PBWebApi.DataAccess.Repositories
{
    public class PessoasRepository
    {
        private readonly PessoaContext _context;

        public PessoasRepository(PessoaContext context)
        {
            _context = context;

            if (_context.Pessoas.Count() == 0)
            {
                _context.Pessoas.AddRange(
                    new Pessoa
                    {
                        Id = 1,
                        Nome = "Miquéias Rafael P. Pedra",
                        Email = "rafaelh3r@yahoo.com.br",
                        Telefone = "(41) 99893-3274",
                        Endereco = null
                        //Endereco = EnderecoFake.Temporario
                    },
                    new Pessoa
                    {
                        Id = 2,
                        Nome = "Rafael Pedra",
                        Email = "rafaelh3r@yahoo.com.br",
                        Telefone = "(41) 99893-3274",
                        Endereco = null
                    },
                    new Pessoa
                    {
                        Id = 3,
                        Nome = "Geovanna L. Pedra",
                        Email = "rafaelh3r@yahoo.com.br",
                        Telefone = "(41) 99893-3274",
                        Endereco = null
                    },
                    new Pessoa
                    {
                        Id = 4,
                        Nome = "Daniel L. Pedra",
                        Email = "rafaelh3r@yahoo.com.br",
                        Telefone = "(41) 99893-3274",
                        Endereco = null
                    });
                _context.SaveChanges();
            }

        }
        

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<int> AddPessoaAsync(Pessoa pes)
        {
            int rowsAffected = 0;

            _context.Pessoas.Add(pes);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        /*public static async Task Remove(int id)
        {
            using (var ctx = new PessoaContext())
            {
                var pes = new Pessoa { Id = id };
                ctx.Pessoas.Attach(pes);
                ctx.Pessoas.Remove(pes);
                await ctx.SaveChangesAsync();
            }
        } */

    }
}
