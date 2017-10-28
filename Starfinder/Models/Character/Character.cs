using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models
{
    public class Character
    {
		#region Properties
		public int Id { get; set; }


		public string Name { get; set; } = "New Character";
		public int Level { get; set; } = 1;

		public int Strength { get; set; } = 10;
		public int Dexterity { get; set; } = 10;
		public int Constitution { get; set; } = 10;
		public int Wisdom { get; set; } = 10;
		public int Intelligence { get; set; } = 10;

		public Race Race { get; set; }
		public CharacterClass Class	{ get; set; }
		#endregion


		#region Public Members
		public void Randomize()
		{
			Name = "Randomized";
		}

		internal static Character Create() => new Character();
		#endregion
	}
}
