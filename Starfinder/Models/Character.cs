using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models
{
    public class Character
    {
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Level { get; set; } = 1;
		public int Strength { get; set; } = 10;
		public int Dexterity { get; set; } = 10;
		public int Constitution { get; set; } = 10;
		public int Wisdom { get; set; } = 10;
		public int Intelligence { get; set; } = 10;
		public string Race { get; set; } = string.Empty;
		public string Class { get; set; } = string.Empty;
	}
}
