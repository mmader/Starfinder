﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starfinder.Controllers;

namespace Starfinder.Models
{
    public class Character
    {
		#region Properties
		public int Id { get; set; }

		public string Name  { get; set; } = "New Character";
		public int    Level { get; set; } = 1;

		public int Strength     { get; set; } = 10;
		public int Dexterity    { get; set; } = 10;
		public int Constitution { get; set; } = 10;
		public int Wisdom       { get; set; } = 10;
		public int Intelligence { get; set; } = 10;

        public int RaceId           { get; set; }
        public int ClassId          { get; set; }
		public Race           Race  { get; set; }
		public CharacterClass Class	{ get; set; }

		public string AvatarPath { get; set; }
		#endregion


		#region Public Members
		public void Randomize(IEnumerable<CharacterClass> classes, IEnumerable<Race> races)
		{
			Name         = "Randomized Name";
            Strength     = new Random().Next(1, 20);
            Dexterity    = new Random().Next(1, 20);
            Constitution = new Random().Next(1, 20);
            Wisdom       = new Random().Next(1, 20);
            Intelligence = new Random().Next(1, 20);

            RaceId = new Random().Next(1, races.Count());
            Race = races.FirstOrDefault(r => r.Id == RaceId);

            ClassId = new Random().Next(1, classes.Count());
            Class   = classes.FirstOrDefault(r => r.Id == ClassId);
		}

        public void Init(IEnumerable<CharacterClass> classes, IEnumerable<Race> races)
        {
            Race  = races  .FirstOrDefault(r => r.Id == RaceId );
            Class = classes.FirstOrDefault(c => c.Id == ClassId);
        }

		internal static Character Create() => new Character();
		#endregion


		#region Overrides
		public override string ToString() => $"Name: {Name} - {Level}";
		#endregion
	}
}
