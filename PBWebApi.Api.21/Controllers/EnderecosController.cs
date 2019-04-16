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
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecosRepository _repository;

        public EnderecosController(EnderecosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> GetAllAsync()
        {
            return await _repository.GetEnderecosAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Endereco>> GetByIdAsync(int id)
        {
            var address = await _repository.GetEnderecoAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Endereco>> CreateAsync(Endereco address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddEnderecoAsync(address);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = address.Id }, address);
        }
    }
    #endregion
}
