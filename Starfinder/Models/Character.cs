using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models
{
    public class Character
    {
		#region Properties
		public int	  Id			{ get; set; }
		public int	  Level			{ get; set; } = 1;
		public int	  Strength		{ get; set; } = 10;
		public int	  Dexterity		{ get; set; } = 10;
		public int	  Constitution	{ get; set; } = 10;
		public int	  Wisdom		{ get; set; } = 10;
		public int	  Intelligence	{ get; set; } = 10;
		public string Name			{ get; set; } = "New Character";
		public string Race			{ get; set; } = string.Empty;
		public string Class			{ get; set; } = string.Empty;
		#endregion


		#region Public Members
		public void Randomize()
		{
			Name = "Randomized";
		} 
		#endregion
	}
}
