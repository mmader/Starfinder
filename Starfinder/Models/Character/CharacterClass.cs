using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models
{
    public class CharacterClass
    {
		/* Other Example Properties:
		 * RaceBonuses -> Dict<string,int>() { {"STR", 3}, {"DEX" , -3}};
		 * ...
		 */

		#region Properties
		public int	  Id	{ get; set; }
		public string Name	{ get; set; }
		#endregion


		#region Overrides
		public override string ToString() => $"{Name}";
		#endregion
    }
}
