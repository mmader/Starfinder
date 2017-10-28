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
		private static ApplicationDbContext context;

		public static void EnsurePopulated(ApplicationDbContext ctx)
		{
			context = ctx;
			InitCharacters();
			InitRaces();
			InitClasses();
		}

		private static void InitClasses()
		{
			if(!context.Classes.Any()) {
				context.Classes.AddRange(
					new CharacterClass() { Name = "ENVOY"},
					new CharacterClass() { Name = "MECHANIC"},
					new CharacterClass() { Name = "MYSTIC"},
					new CharacterClass() { Name = "OPERATIVE"},
					new CharacterClass() { Name = "SOLARIAN"},
					new CharacterClass() { Name = "SOLDIER"},
					new CharacterClass() { Name = "TECHNOMANCER"}
				);
			}

			context.SaveChanges();
		}

		private static void InitRaces()
		{
			if(!context.Races.Any()) {
				context.Races.AddRange(
					new Race() { Name= "ANDROIDS" },
					new Race() { Name= "HUMANS"	},
					new Race() { Name= "KASATHAS" },
					new Race() { Name= "SHIRRENS" },
					new Race() { Name= "VESK" },
					new Race() { Name= "YSOKI" }
				);
			}

			context.SaveChanges();
		}

		private static void InitCharacters()
		{
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
	}
} 