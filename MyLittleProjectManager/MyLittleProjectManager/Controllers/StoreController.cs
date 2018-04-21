using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;

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
            var profiles = _context.PlayerProfiles.ToList();
            var items = _context.Items.ToList();
            var titles = _context.Titles.ToList();
            var profile = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name).PlayerProfile;
            
            var applicationUser = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name);
            
            if(profile == null)
            {
                profile = new PlayerProfile();
            }
            
            foreach(var item in profile.AvailableItems)
            {
                try
                {
                    items.Remove(items.FirstOrDefault(i => i.Id == item.ItemId));
                }
                catch { }
            }
            
            foreach(var title in profile.AvailableTitles)
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