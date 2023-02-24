using Microsoft.AspNetCore.Mvc;

namespace LuizaLabsDesafio.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
