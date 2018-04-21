using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleProjectManager.Controllers
{
	public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //List<PlayerProfile> profiles = _context.PlayerProfiles.ToList();
            List<Item> items = _context.Items.ToList();
            List<Title> titles = _context.Titles.ToList();

			var applicationUser = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name);
			PlayerProfile profile = _context.PlayerProfiles
					.Include(p => p.AvailableItems)
					.Include(p => p.AvailableTitles)
					.SingleOrDefault(p => p == applicationUser.PlayerProfile);

			foreach (PlayerItem item in profile.AvailableItems)
            {
                try
                {
                    items.Remove(items.FirstOrDefault(i => i.Id == item.ItemId));
                }
                catch { }
            }
            
            foreach(PlayerTitle title in profile.AvailableTitles)
            {
                try
                {
                    titles.Remove(titles.FirstOrDefault(t => t.Id == title.TitleId));
                }
                catch { }
            }

            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Profile = profile,
                StoreItems = items,
                StoreTitle = titles
            };

            return View(storeViewModel);
        }
    }
}