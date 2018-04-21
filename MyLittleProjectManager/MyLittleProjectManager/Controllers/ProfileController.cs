using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLittleProjectManager.Controllers
{
    public class ProfileController : Controller
    {
		private readonly ApplicationDbContext _context;

		public ProfileController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
        [Authorize]
        public IActionResult Index()
        {
			var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
			PlayerProfile pp = _context.PlayerProfiles.Where(p => p == user.PlayerProfile)
				.Include(p => p.AvailableItems)
				.Include(p => p.SelectedItems)
				.Include(p => p.AvailableTitles)
				.SingleOrDefault();
            return View(pp);
        }
    }
}