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
			InitRaces();
			InitClasses();
			InitCharacters();
		}

		private static void InitClasses()
		{
			if(context.Classes.Count() == 0) {
                context.Classes.AddRange(
                    new CharacterClass() { Name = "ENVOY" },
                    new CharacterClass() { Name = "MECHANIC" },
                    new CharacterClass() { Name = "MYSTIC" },
                    new CharacterClass() { Name = "OPERATIVE" },
                    new CharacterClass() { Name = "SOLARIAN" },
                    new CharacterClass() { Name = "SOLDIER" },
                    new CharacterClass() { Name = "TECHNOMANCER" }
                );

                //context.Classes.AddRange(
                //	new CharacterClass() { Id = 0, Name = "ENVOY"},
                //	new CharacterClass() { Id = 1, Name = "MECHANIC"},
                //	new CharacterClass() { Id = 2, Name = "MYSTIC"},
                //	new CharacterClass() { Id = 3, Name = "OPERATIVE"},
                //	new CharacterClass() { Id = 4, Name = "SOLARIAN"},
                //	new CharacterClass() { Id = 5, Name = "SOLDIER"},
                //	new CharacterClass() { Id = 6, Name = "TECHNOMANCER"}
                //);
            }

			context.SaveChanges();
		}

		private static void InitRaces()
		{
			if(context.Races.Count() == 0) {
                context.Races.AddRange(
                    new Race() { Name = "ANDROIDS" },
                    new Race() { Name = "HUMANS" },
                    new Race() { Name = "KASATHAS" },
                    new Race() { Name = "SHIRRENS" },
                    new Race() { Name = "VESK" },
                    new Race() { Name = "YSOKI" }
                );

//            context.Races.AddRange(
				//	new Race() { Id = 0, Name= "ANDROIDS" },
				//	new Race() { Id = 1, Name= "HUMANS"	},
				//	new Race() { Id = 2, Name= "KASATHAS" },
				//	new Race() { Id = 3, Name= "SHIRRENS" },
				//	new Race() { Id = 4, Name= "VESK" },
				//	new Race() { Id = 5, Name= "YSOKI" }
				//);
			}

			context.SaveChanges();
		}

		private static void InitCharacters()
		{
			if(context.Characters.Count() == 0) {

                // classes
                var classIds = Enumerable.Range(0, 8).ToDictionary(a => a, b => GetRandomClassId());

                // races
                var raceIds  = Enumerable.Range(0, 8).ToDictionary(a => a, b => GetRandomRaceId());

                // characters
				context.Characters.AddRange(
					new Character {
                        Name    = "Kayak", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds [0]),
                        RaceId  = raceIds [0],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[0]),
                        ClassId = classIds[0]
                    },
					new Character {
                        Name    = "Brunor", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[1]),
                        RaceId  = raceIds[1],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[1]),
                        ClassId = classIds[1],
                    },
					new Character {
                        Name    = "Kirk", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[2]),
                        RaceId  = raceIds[2],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[2]),
                        ClassId = classIds[2],
                    },
					new Character {
                        Name    = "Max", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[3]),
                        RaceId  = raceIds[3],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[3]),
                        ClassId = classIds[3],
                    },
					new Character {
                        Name = "Shaft", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[4]),
                        RaceId  = raceIds[4],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[4]),
                        ClassId = classIds[4],
                    },
					new Character {
                        Name = "MOrk", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[5]),
                        RaceId  = raceIds[5],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[5]),
                        ClassId = classIds[5],
                    },
					new Character {
                        Name = "Zaphod", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[6]),
                        RaceId  = raceIds[6],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[6]),
                        ClassId = classIds[6],
                    },
					new Character {
                        Name = "bzzzzzz", Strength = 10, Dexterity = 10, Constitution = 10, Intelligence = 10, Level = 1, Wisdom = 10,
                        Race    = context.Races.FirstOrDefault(r => r.Id == raceIds[7]),
                        RaceId  = raceIds[7],
                        Class   = context.Classes.FirstOrDefault(r => r.Id == classIds[7]),
                        ClassId = classIds[7]
                    }
				);
			}

            try {
                context.SaveChanges();
            }
            catch(Exception ex) {
                var debug = ex.GetBaseException().ToString();
                throw;
            }
		}

        private static int GetRandomClassId()
        {
            var rand = new Random().Next(1, context.Classes.Count());
            return (rand > 1) 
                ? rand - 1 
                : rand;
        }

        private static int GetRandomRaceId()
        {
            var rand = new Random().Next(1, context.Races.Count());
            return (rand > 1) 
                ? rand - 1 
                : rand;
        }
	}
} 