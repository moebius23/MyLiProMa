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
            var profile = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name).PlayerProfile;
            if(profile == null)
            {
                profile = new PlayerProfile();
            }
            var items = _context.Items.ToList();
            foreach(var item in profile.AvailableItems)
            {
                try
                {
                    items.Remove(items.FirstOrDefault(i => i.Id == item.Id));
                }
                catch { }
            }
            var titles = _context.Titles.ToList();
            foreach(var title in profile.AvailableTitles)
            {
                try
                {
                    titles.Remove(titles.FirstOrDefault(t => t.Id == title.Id));
                }
                catch { }
            }
            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Profile = profile,
                StoreItems = items,
                StoreTitle = titles
            };

            storeViewModel.StoreItems.AddRange(new List<Item>()
            {
                new Item()
                {
                    Id = 1,
                    Name = "Riri",
                    Price = 10,
                    Type = EItemType.Hat
                },
                new Item()
                {
                    Id = 2,
                    Name = "Fifi",
                    Price = 15,
                    Type = EItemType.Hat
                },
                new Item()
                {
                    Id = 3,
                    Name = "Loulou",
                    Price = 13,
                    Type = EItemType.Hat
                }
            });
            storeViewModel.StoreTitle.AddRange(new List<Title>()
            {
                new Title()
                {
                    Id = 1,
                    Price=15,
                    Text="Le Dieu"
                },
                new Title()
                {
                    Id =2,
                    Price = 20,
                    Text = "Le Saigneur"
                },
                new Title()
                {
                    Id =3,
                    Price = 10,
                    Text = "Le Sith"
                }
            });

            return View(storeViewModel);
        }
    }
}