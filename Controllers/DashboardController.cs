using Microsoft.AspNetCore.Mvc;

namespace SKNHPM.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
