using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starfinder.Models;

namespace Starfinder.Interfaces
{
    public interface ICharacterRepository
    {
		IEnumerable<Character> Characters { get; }
	}
}
