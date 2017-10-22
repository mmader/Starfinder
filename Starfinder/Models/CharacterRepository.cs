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
		private	ApplicationDbContext context;

		public CharacterRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}

		public IEnumerable<Character> Characters => context.Characters;
	}
}
