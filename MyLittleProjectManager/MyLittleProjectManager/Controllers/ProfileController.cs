using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;

namespace MyLittleProjectManager.Controllers
{
    public class ProfileController : Controller
    {
		ApplicationDbContext context = new ApplicationDbContext(null);

		[HttpGet]
        [Authorize]
        public IActionResult Index()
        {
			var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
			PlayerProfile pp = user.PlayerProfile;
            return View(pp);
        }
    }
}