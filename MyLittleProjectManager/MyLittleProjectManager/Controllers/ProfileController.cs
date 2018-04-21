using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.BusinessLayer;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

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

			PlayerProfile pp;
			if (user.PlayerProfile != null)
			{
				pp = _context.PlayerProfiles.Where(p => p == user.PlayerProfile)
					.Include(p => p.AvailableItems)
					.Include(p => p.AvailableTitles)
					.SingleOrDefault();
			}
			else pp = (new PlayerProfileManagement(_context)).CreatePlayerProfile(user.UserName);

            if (pp.Pseudo != null) { HttpContext.Session.SetString("Pseudo", pp.Pseudo); }

            return View(pp);
        }
    }
}