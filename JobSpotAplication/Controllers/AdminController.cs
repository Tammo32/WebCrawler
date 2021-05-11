using JobSpotAplication.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper;

namespace JobSpotAplication.Controllers
{
    
    public class AdminController : Controller
    {
        private ApplicationDbContext DbConext = new ApplicationDbContext(GlobalConfig.ConnectionString("Local"));

        public IActionResult Index()
        {
            return View();
        }
    }
}
