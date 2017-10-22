using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models
{
    public class Character
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Constitution { get; set; }
		public int Wisdom { get; set; }
		public int Intelligence { get; set; }
    }
}
