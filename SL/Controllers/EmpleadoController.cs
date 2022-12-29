using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        [EnableCors("API")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();

            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [Route("EstadoGetAll")]
        [HttpGet]
        public IActionResult EstadoGetAll()
        {
            ML.Estado estado = new ML.Estado();

            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpGet("GetByID{IdEmpleado}")]
        public IActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost("Update/{IdEmpleado}")]
        public IActionResult Put(int IdEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;

            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [EnableCors("API")]
        [HttpDelete("Delete{IdEmpleado}")]
        public IActionResult Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }
    }
}
