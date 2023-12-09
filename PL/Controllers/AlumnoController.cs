using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
