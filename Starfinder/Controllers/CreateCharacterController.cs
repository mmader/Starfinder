using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		[HttpGet] public IActionResult Index(CreateCharacterViewModel vm)
		{
            vm.AvailableRaces   = context.Races;
            vm.AvailableClasses = context.Classes;

            return (vm != null) 
				? View("Index", vm) 
				: View();
		}

		[HttpPost] public IActionResult Randomize(CreateCharacterViewModel vm)
		{
			if(ModelState.IsValid)
				vm?.Character?.Randomize(context);

			return RedirectToAction("Index", vm);
		}

		[HttpPost] public async Task<IActionResult> Save(CreateCharacterViewModel vm)
		{
            var race           = int.Parse(HttpContext.Request.Form["Character.Race" ]);
            var characterClass = int.Parse(HttpContext.Request.Form["Character.Class"]);

            vm.Character.Race  = context.Races  .FirstOrDefault(r => r.Id == race);
            vm.Character.Class = context.Classes.FirstOrDefault(r => r.Id == race);

			if(ModelState.IsValid && (vm?.Character != null)) {
				await context?.Characters?.AddAsync(vm.Character);
				await context?.SaveChangesAsync();
			}
			return RedirectToAction("Index", vm);
		} 

		[HttpPost] public IActionResult New(CreateCharacterViewModel vm) => RedirectToAction("Index", vm.Character = Character.Create());
		#endregion
	}
}
