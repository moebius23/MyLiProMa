using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.BusinessLayer;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
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
            var profiles = _context.PlayerProfiles.ToList();
			var items = _context.Items.ToList();
			var titles = _context.Titles.ToList();
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

            pp.AvailableItems = new List<PlayerItem>();
            pp.AvailableItems.Add(new PlayerItem() { Item = new Item() { Id=0, Type = EItemType.Avatar, ImageLink = "/images/assets/animals/characterautruche.png" } });
            pp.AvailableItems.Add(new PlayerItem() { Item = new Item() { Id = 1, Type = EItemType.Hat, ImageLink = "/images/assets/animals/characterautruchehat.png" } });
            pp.AvailableItems.Add(new PlayerItem() { Item = new Item() { Id = 2, Type = EItemType.Hat, ImageLink = "/images/assets/animals/characterautruchehatfete.png" } });

            pp.SelectedItems = new Dictionary<EItemType, PlayerItem>();
            pp.SelectedItems.Add(EItemType.Avatar, pp.AvailableItems[0]);
            pp.SelectedItems.Add(EItemType.Hat, pp.AvailableItems[1]);

            return View(pp);
        }

        [HttpPost]
        [Authorize]
        public bool ChangeSelectedItem(string data)
        {
            string value = HttpContext.Request.Query["param"].ToString();
            return true;
        }

    }
}