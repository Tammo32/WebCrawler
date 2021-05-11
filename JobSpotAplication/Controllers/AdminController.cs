using JobSpotAplication.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Controllers
{
    
    public class AdminController : Controller
    {
        private ApplicationDbContext DbConext = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
