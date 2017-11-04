using System;
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
		public void Randomize()
		{
			Name = "Randomized";
		}

        public void Init(ApplicationDbContext context)
        {
            Race  = context.Races  .FirstOrDefault(r => r.Id == RaceId );
            Class = context.Classes.FirstOrDefault(c => c.Id == ClassId);
        }

		internal static Character Create() => new Character();
		#endregion


		#region Overrides
		public override string ToString() => $"Name: {Name} - {Level}";
		#endregion
	}
}
