using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
			else pp = new PlayerProfile();

            pp.AvailableItems = new List<Item>()
            {
                new Item(){ ImageLink = "/images/assets/animals/characterautruche.png", Type = EItemType.Avatar},
                new Item(){ ImageLink = "/images/assets/animals/characterautruchehat.png", Type = EItemType.Hat}
            };

            pp.SelectedItems = new Dictionary<EItemType, Item>();
            pp.SelectedItems.Add(EItemType.Avatar, pp.AvailableItems[0]);
            pp.SelectedItems.Add(EItemType.Hat, pp.AvailableItems[1]);

            if (pp.Pseudo != null) { HttpContext.Session.SetString("Pseudo", pp.Pseudo); }
            return View(pp);
        }
    }
}