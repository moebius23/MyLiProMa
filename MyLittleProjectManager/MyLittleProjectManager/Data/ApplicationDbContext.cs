using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public virtual DbSet<Project> Projects { get; set; }
		public virtual DbSet<PlayerProfile> PlayerProfiles { get; set; }
		public virtual DbSet<Title> Titles { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
