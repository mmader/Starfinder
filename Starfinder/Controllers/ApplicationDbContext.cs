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
		public DbSet<Character> Characters { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Course");
        }
    }
}
