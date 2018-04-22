using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
//using MyLittleProjectManager.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleProjectManager.Controllers
{
	public class LeaderboardController : Controller
    {
		private readonly ApplicationDbContext _context;

		public LeaderboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Authorize]
		public IActionResult Index()
        {
            var profiles = _context.PlayerProfiles.ToList();
            var playertitles = _context.PlayerTitles.ToList();
            var titles = _context.Titles.ToList();
            var playerItems = _context.PlayerItems.ToList();
            var items = _context.Items.ToList();
			List<PlayerProfile> playerProfiles = _context.PlayerProfiles
				.Include(p => p.AvailableTitles)
				.Include(p => p.AvailableItems)
				.ToList();

			List<LeaderboardViewModel> leaderboard = new List<LeaderboardViewModel>();
			foreach (PlayerProfile player in playerProfiles)
			{
				LeaderboardViewModel leaderboardView = new LeaderboardViewModel()
				{
					Pseudo = player.Pseudo,
					Title = player.AvailableTitles.Where(t => t.IsSelected).FirstOrDefault().Title.Text,
					TotalMICoins = player.MICoins
				};
				foreach (PlayerItem item in player.AvailableItems)
				{
					leaderboardView.TotalMICoins += item.Item.Price;
				}
				leaderboard.Add(leaderboardView);
			}
			
			return View(leaderboard);
        }
    }
}