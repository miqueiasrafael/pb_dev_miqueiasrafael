using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBWebApi.DataAccess.Models;
using PBWebApi.DataAccess.Repositories;

namespace PBWebApi.Api._21.Controllers
{
    #region snippet_PetsController
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly PessoasRepository _repository;

        public PessoasController(PessoasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> GetAllAsync()
        {
            return await _repository.GetPessoasAsync();
        }

        #region snippet_GetById
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pessoa>> GetByIdAsync(int id)
        {
            var pes = await _repository.GetPessoaAsync(id);

            if (pes == null)
            {
                return NotFound();
            }

            return pes;
        }
        #endregion

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pessoa>> CreateAsync(Pessoa pes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPessoaAsync(pes);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = pes.Id }, pes);
        }
    }
    #endregion
}
