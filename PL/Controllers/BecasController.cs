using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class BecasController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
