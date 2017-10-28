using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starfinder.Interfaces;
using Starfinder.Models;

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
		[HttpGet] public IActionResult Index(Character character)
		{
			return (character != null) 
				? View("Index", character) 
				: View();
		}

		[HttpPost] public IActionResult Randomize(Character character)
		{
			if(ModelState.IsValid)
				character?.Randomize();

			return RedirectToAction("Index", character);
		}

		[HttpPost] public async Task<IActionResult> Save(Character character)
		{
			if(ModelState.IsValid && (character != null)) {
				await context?.Characters?.AddAsync(character);
				await context?.SaveChangesAsync();
			}
			return RedirectToAction("Index", character);
		} 

		[HttpPost] public IActionResult New(Character character) => RedirectToAction("Index", Character.Create());
		#endregion
	}
}
