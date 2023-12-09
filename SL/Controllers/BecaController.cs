using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BecaController : ControllerBase
    {
        [Route("GetAll")]
        [HttpGet]

        public IActionResult GetAll()
        {
            ML.Result result = BL.Becas.GetBecas();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }
    }
}
