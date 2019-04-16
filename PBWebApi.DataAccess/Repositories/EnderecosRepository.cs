using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBWebApi.DataAccess.Models;

namespace PBWebApi.DataAccess.Repositories
{
    public class EnderecosRepository
    {
        private readonly EnderecoContext _context;

        public EnderecosRepository(EnderecoContext context)
        {
            _context = context;

            if (_context.Enderecos.Count() == 0)
            {
                _context.Enderecos.AddRange(
                    new Endereco
                    {
                        Id = 1,
                        CEP = "83706-160",
                        UF = "PR",
                        Cidade = "Araucária",
                        Bairro = "Capela Velha",
                        Logradouro = "Rua Arapongas",
                        Numero = "1528",
                        Complemento = "Club Acqua Park",
                        Pessoa_Id = null

                    },
                    new Endereco
                    {
                        Id = 2,
                        CEP = "83706-160",
                        UF = "PR",
                        Cidade = "Belém",
                        Bairro = "Centro",
                        Logradouro = "Av. Gov. Magalhães Barata",
                        Numero = "1315",
                        Complemento = "Prox. ao forum",
                        Pessoa_Id = null
                    },
                    new Endereco
                    {
                        Id = 3,
                        CEP = "83706-160",
                        UF = "PR",
                        Cidade = "Araucária",
                        Bairro = "Capela Velha",
                        Logradouro = "Rua Arapongas",
                        Numero = "1528",
                        Complemento = "Club Acqua Park",
                        Pessoa_Id = null
                    },
                    new Endereco
                    {
                        Id = 4,
                        CEP = "83706-160",
                        UF = "PR",
                        Cidade = "Araucária",
                        Bairro = "Capela Velha",
                        Logradouro = "Rua Arapongas",
                        Numero = "1528",
                        Complemento = "Club Acqua Park",
                        Pessoa_Id = null
                    });
                _context.SaveChanges();
            }
        }

        public async Task<List<Endereco>> GetEnderecosAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> GetEnderecoAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<int> AddEnderecoAsync(Endereco address)
        {
            int rowsAffected = 0;

            _context.Enderecos.Add(address);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
