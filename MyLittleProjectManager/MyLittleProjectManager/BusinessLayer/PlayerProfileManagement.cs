using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleProjectManager.BusinessLayer
{
    public class PlayerProfileManagement
    {
		private readonly ApplicationDbContext _context;

		public PlayerProfileManagement(ApplicationDbContext context)
		{
			_context = context;
		}

		public PlayerProfile CreatePlayerProfile(string pseudo)
		{
			PlayerProfile playerProfile = new PlayerProfile() { Pseudo = pseudo };
			_context.PlayerProfiles.Add(playerProfile);

			Title title = _context.Titles.FirstOrDefault(t => t.Text.Equals("Noob"));
			PlayerTitle PlayerTitle = new PlayerTitle() { Player = playerProfile, Title = title, IsSelected = true };
			_context.PlayerTitles.Add(PlayerTitle);

			playerProfile.AvailableTitles.Add(PlayerTitle);

			Project project = GenerateDemoProject();
			_context.Add(project);

			PlayerProject playerProject = new PlayerProject() { Project = project, Player = playerProfile };
			_context.PlayerProjects.Add(playerProject);

			playerProfile.PlayerProjects.Add(playerProject);

			_context.SaveChanges();
			return playerProfile;
		}

		private Project GenerateDemoProject()
		{
			return new Project()
			{
				Name = "MyLittleProjectManager",
				Description = "Demo Project",
				Columns = new ObservableCollection<Column>()
				{
					new Column()
					{
						Name = "To Do",
						Order = 0,
						Cards = new ObservableCollection<Card>()
						{
							new Card()
							{
								Order = 0,
								Name = "Move a card",
								Description = "Move this card to another column."
							},
							new Card()
							{
								Order = 1,
								Name = "Delete a card",
								Description = "Move this card to the trash bin. It's in the upper right corner of your screen."
							},
							new Card()
							{
								Order = 1,
								Name = "Create a card",
								Description = "Create a new card. It's in the upper left corner of your screen."
							},
							new Card()
							{
								Order = 1,
								Name = "Go get your prize !",
								Description = "The link to the store is in the top menu."
							}
						}
					},
					new Column()
					{
						Name = "Doing",
						Order = 1
					},
					new Column()
					{
						Name = "Done",
						Order = 2
					}
				}
			};
		}

	}
}
