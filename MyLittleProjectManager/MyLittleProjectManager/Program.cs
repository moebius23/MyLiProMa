using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyLittleProjectManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Seed().Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}

	public static class DatabaseSeedInitializer
	{
		public static IWebHost Seed(this IWebHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				IServiceProvider services = scope.ServiceProvider;
				using (var serviceScope = services.CreateScope())
				{
					ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
					InsertSeedData(context);
				}
			}
			return host;
		}

		private static void InsertSeedData(ApplicationDbContext context)
		{
			if (context.Projects.Any()) return;
			var project = new Project()
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
			context.Add(project);
			context.SaveChanges();
		}

	}

}
