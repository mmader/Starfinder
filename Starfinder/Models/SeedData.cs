using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Starfinder.Controllers;

namespace Starfinder.Models
{
    public static class SeedData
    {
		public static void EnsurePopulated(ApplicationDbContext ctx)
		{
			var context = ctx;
			if(!context.Characters.Any()) {
				context.Characters.AddRange(
					new Character { Name = "Kayak", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "Brunor", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "Kirk", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "Max", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "Shaft", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "MOrk", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "Zaphod", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 },
					new Character { Name = "bzzzzzz", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 }
				);
			}

			context.SaveChanges();
		}

		public static void EnsurePopulated(IApplicationBuilder app)
		{
			var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			if(!context.Characters.Any()) {
				context.Characters.AddRange(
					new Character { Name = "Kayak", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10 }
				);
				context.SaveChanges();
			}
		}
    }
} 