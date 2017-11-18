using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starfinder.Models.ViewModels
{
    public class CreateCharacterViewModel
    {
        #region Properties
        public Character Character { get; set; }
        public IEnumerable<Race> AvailableRaces { get; set; }
        public int SelectedRace { get; set; }
        public IEnumerable<CharacterClass> AvailableClasses { get; set; }
        public int SelectedClass { get; set; }
        #endregion


        #region Construction
        public CreateCharacterViewModel() { }
        #endregion
    }
}
