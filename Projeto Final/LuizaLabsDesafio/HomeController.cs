using Microsoft.AspNetCore.Mvc;

namespace LuizaLabsDesafio
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
