using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starfinder.Infrastructure;
using Starfinder.Interfaces;
using Starfinder.Models;
using Starfinder.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Starfinder.Controllers
{
    public class CreateCharacterController : Controller
    {
		#region Private fields
		private ApplicationDbContext context;
		#endregion


		#region Construction
		public CreateCharacterController(ApplicationDbContext ctx)
		{
			context = ctx;
		}
		#endregion


		#region Public Members
		[HttpGet] public IActionResult Index(int id)
            => View("Index", new CreateCharacterViewModel {
                Character        = GetCharacter(),
                AvailableRaces   = context.Races,
                AvailableClasses = context.Classes
            }); 

		[HttpPost] public IActionResult Randomize()
		{
            var character = GetCharacter();
            character.Randomize(context.Classes, context.Races);

			return RedirectToAction("Index", new CreateCharacterViewModel {
                Character        = character,
                AvailableRaces   = context.Races,
                AvailableClasses = context.Classes
            });
		}

		[HttpPost] public async Task<IActionResult> Save(int selectedClass, int selectedRace)
		{
            //var raceId  = int.Parse(HttpContext.Request.Form["Character.Race" ]);
            //var classId = int.Parse(HttpContext.Request.Form["Character.Class"]);
            var raceId  = selectedRace;
            var classId = selectedClass;

            var vm = new CreateCharacterViewModel() { Character = GetCharacter(), AvailableClasses = context.Classes, AvailableRaces = context.Races };
            vm.Character.Race    = context.Races  .FirstOrDefault(r => r.Id == raceId);
            vm.Character.RaceId  = vm.Character.Race.Id;
            vm.Character.Class   = context.Classes.FirstOrDefault(r => r.Id == classId);
            vm.Character.ClassId = vm.Character.Class.Id;

			if(ModelState.IsValid && (vm?.Character != null)) {
				await context?.Characters?.AddAsync(vm.Character);
				await context?.SaveChangesAsync();
			}
			return RedirectToAction("Index", vm);
		} 

		[HttpPost] public IActionResult New(CreateCharacterViewModel vm) => RedirectToAction("Index", vm.Character = Character.Create());
        #endregion


        #region Private Helpers
        private Character GetCharacter() => HttpContext.Session.GetJson<Character>("Character") ?? new Character();

        private void SaveCart(Character character) => HttpContext.Session.SetJson("Character", character);
        #endregion
    }
}
