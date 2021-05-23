using JobSpotAplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace JobSpotAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);

            if (userId == "admin@admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            if (userId != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
