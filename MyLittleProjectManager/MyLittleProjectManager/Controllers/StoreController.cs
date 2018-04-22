using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            List<PlayerProfile> profiles = _context.PlayerProfiles.ToList();
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
        [HttpPost]
        public JsonResult Index(string itemsBoughtViewModel)
        {
			var user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
			PlayerProfile pp = _context.PlayerProfiles.Where(p => p == user.PlayerProfile)
					.Include(p => p.AvailableItems)
					.Include(p => p.AvailableTitles)
					.SingleOrDefault();
								  
			foreach (var itemId in itemsBoughtViewModel.ItemsId)
			{
				Item item = _context.Items.SingleOrDefault(i => i.Id == itemId);
				if (item != null)
				{
					if (pp.MICoins - item.Price >= 0)
					{
						pp.MICoins -= item.Price;
						PlayerItem playerItem = new PlayerItem() { Item = item, Player = pp };
						pp.AvailableItems.Add(playerItem);
					}
					else return StatusCode(402);
				}
			}
			foreach (var titleId in itemsBoughtViewModel.TitlesId)
			{
				Title title = _context.Titles.SingleOrDefault(i => i.Id == titleId);
				if (title != null)
				{
					if (pp.MICoins - title.Price >= 0)
					{
						pp.MICoins -= title.Price;
						PlayerTitle playerTitle = new PlayerTitle() { Title = title, Player = pp };
						pp.AvailableTitles.Add(playerTitle);
					}
					else return StatusCode(402);
				}
			}
			_context.SaveChanges();
            return Json(true);
        }

    }
}