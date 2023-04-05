using Microsoft.AspNetCore.Mvc;

namespace DU.Controllers
{
    public class HobbyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
