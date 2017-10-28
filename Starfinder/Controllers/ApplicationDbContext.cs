using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Starfinder.Models;

namespace Starfinder.Controllers
{
    public class ApplicationDbContext : DbContext
    {
		#region Properties
		public DbSet<Race>		Races		{ get; set; }
		public DbSet<Character> Characters	{ get; set; }
		public DbSet<CharacterClass> Classes { get; set; }
		#endregion


		#region Construciton
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
		#endregion


		#region Overrides
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Character>().ToTable("Characters");
			modelBuilder.Entity<Race>().ToTable("Races");
			modelBuilder.Entity<CharacterClass>().ToTable("Classes");
		} 
		#endregion
	}
}
