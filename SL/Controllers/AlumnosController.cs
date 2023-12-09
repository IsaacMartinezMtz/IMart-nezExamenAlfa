using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll() 
        {
            ML.Result result = BL.Usuario.GetAll();
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(400, result);
                }
        }
        [Route("GetById/{IdAlumno}")]
        [HttpGet]
        public IActionResult GetById(int IdAlumno)
        {
            ML.Result result = BL.Usuario.GetById(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return StatusCode(400, result);
            }
        }
        [Route("Delete/{IdAlumno}")]
        [HttpDelete]
        public IActionResult Delete(int IdAlumno)
        {
            ML.Result result = BL.Usuario.Delete(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add(ML.Usuario usuario) 
        {
            
            ML.Result result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }
        [Route("Update/{IdAlumno}")]
        [HttpPut]
        public IActionResult Update(int IdAlumno, [FromBody] ML.Usuario usuario)
        {
            usuario.IdUsuario = IdAlumno;
                ML.Result result = BL.Usuario.Updtae(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result) ;
            }
        }
    }
}
