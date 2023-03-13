using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class Currency : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
