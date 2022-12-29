using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
       
        [HttpGet]
        public IActionResult GetAll()
        {
            return View();
        }

    }


}
