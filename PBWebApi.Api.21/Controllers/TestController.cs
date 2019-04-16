using Microsoft.AspNetCore.Mvc;
using PBWebApi.DataAccess.Models;

namespace PBWebApi.Api._21.Controllers
{
    /// <summary>
    /// Testing sample for method in controller or migrate for one schema @miqueias.rafael 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region snippet_ActionsCausingExceptions
        // Don't do this. All of the following actions result in an exception.
        [HttpPost]
        public IActionResult Action1(Pessoa product, 
                                     Endereco endereco) => null;

        [HttpPost]
        public IActionResult Action2(Pessoa product, 
                                     [FromBody] Endereco endereco) => null;

        [HttpPost]
        public IActionResult Action3([FromBody] Pessoa pessoa, 
                                     [FromBody] Endereco endereco) => null;
        #endregion
    }
}