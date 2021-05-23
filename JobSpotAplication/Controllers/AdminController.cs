using JobSpotAplication.Data;
using JobSpotAplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebScraper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Security.Claims;

namespace JobSpotAplication.Controllers
{
    
    public class AdminController : Controller
    {
        
        ApplicationDbContext DbConext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
            .Options);

        public ActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
       
            if (userId != "admin@admin")
            {
                return Redirect("/Home/Privacy");
            }
            return View(DbConext.Users.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return View(new ErrorViewModel { RequestId = "The user ID is invalid" });
            }
            var user = DbConext.Users.Find(id);
            if (user == null)
            {
                return View(new ErrorViewModel { RequestId = "The user ID is invalid" });
            }
            return View(user);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return View(new ErrorViewModel { RequestId = "The user ID is invalid" });
            }
            var user = DbConext.Users.Find(id);
            if (user == null)
            {
                return View(new ErrorViewModel { RequestId = "The user ID is invalid" });
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityUser changedUser)
        {
            var user = await DbConext.Users.FindAsync(changedUser.Id);

            if (ModelState.IsValid)
            {
                changedUser.PasswordHash = user.PasswordHash;
                changedUser.NormalizedEmail = user.NormalizedEmail;
                changedUser.NormalizedUserName = user.NormalizedUserName;
                changedUser.EmailConfirmed = user.EmailConfirmed;
                changedUser.PhoneNumber = user.PhoneNumber;
                changedUser.LockoutEnabled = user.LockoutEnabled;
                changedUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                changedUser.SecurityStamp = user.SecurityStamp;
                changedUser.ConcurrencyStamp = user.ConcurrencyStamp;
                ApplicationDbContext DbConext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
                .Options);
                DbConext.Entry(changedUser).State = EntityState.Modified;
                await DbConext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            return View();
        }

        public ActionResult Background()
        {
            return Redirect("/hangfire");
        }
    }
}
