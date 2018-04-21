using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLittleProjectManager.Models;

namespace MyLittleProjectManager.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public virtual DbSet<Card> Cards { get; set; }
		public virtual DbSet<Column> Columns { get; set; }
		public virtual DbSet<Item> Items { get; set; }
		public virtual DbSet<PlayerItem> PlayerItems { get; set; }
		public virtual DbSet<PlayerProfile> PlayerProfiles { get; set; }
		public virtual DbSet<PlayerProject> PlayerProjects { get; set; }
		public virtual DbSet<PlayerTitle> PlayerTitles { get; set; }
		public virtual DbSet<Project> Projects { get; set; }
		public virtual DbSet<Title> Titles { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.Entity<PlayerProject>().HasKey(p => new { p.ProjectId, p.PlayerId });
			builder.Entity<PlayerProject>()
				.HasOne(pp => pp.Player).WithMany(p => p.PlayerProjects)
				.HasForeignKey(pp => pp.PlayerId);
			builder.Entity<PlayerProject>()
				.HasOne(pp => pp.Project).WithMany(p => p.PlayerProjects)
				.HasForeignKey(pp => pp.ProjectId);

			builder.Entity<PlayerItem>().HasKey(p => new { p.ItemId, p.PlayerId });
			builder.Entity<PlayerItem>()
				.HasOne(pi => pi.Player).WithMany(p => p.AvailableItems)
				.HasForeignKey(pi => pi.PlayerId);
			builder.Entity<PlayerItem>()
				.HasOne(pi => pi.Item).WithMany(p => p.PlayerItems)
				.HasForeignKey(pi => pi.ItemId);

			builder.Entity<PlayerTitle>().HasKey(p => new { p.TitleId, p.PlayerId });
			builder.Entity<PlayerTitle>()
				.HasOne(pt => pt.Player).WithMany(p => p.AvailableTitles)
				.HasForeignKey(pt => pt.PlayerId);
			builder.Entity<PlayerTitle>()
				.HasOne(pt => pt.Title).WithMany(p => p.PlayerTitles)
				.HasForeignKey(pt => pt.TitleId);
		}
    }
}
