using JobSpotAplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_userManager.Context.User.Identity.Name == "admin")
            {
                return RedirectToAction("Index", "Admin");
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
