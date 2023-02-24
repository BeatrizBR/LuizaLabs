using Microsoft.AspNetCore.Mvc;

namespace LuizaLabsDesafio.Controllers
{
    [Route("login/[controller]")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Logged");
        }
    }
}
