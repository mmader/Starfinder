using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starfinder.Controllers;
using Starfinder.Interfaces;

namespace Starfinder.Models
{
	public class CharacterRepository : ICharacterRepository
	{
		#region Private Fields
		private ApplicationDbContext context;
		#endregion


		#region Properties
		public IEnumerable<Character>       Characters	=> context.Characters;
		public IEnumerable<Race>            Races		=> context.Races;
		public IEnumerable<CharacterClass>  Classes		=> context.Classes;
		#endregion


		#region Construction
		public CharacterRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}
		#endregion
	}
}
