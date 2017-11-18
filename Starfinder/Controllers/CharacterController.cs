using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starfinder.Interfaces;
using Starfinder.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Starfinder.Controllers
{
    public class CharacterController : Controller
    {
		private ApplicationDbContext Context;

		public CharacterController(ApplicationDbContext ctx)
		{
			Context = ctx;
		}

        public IActionResult Index()
        {
            foreach(var character in Context.Characters)
                character.Init(Context.Classes, Context.Races);

            return View(Context.Characters);
        }

        public async Task<IActionResult> Delete(int id)
		{
			if(ModelState.IsValid) {
				var chr = Context.Characters.FirstOrDefault(c => c.Id == id);
				if(chr == null)
					return RedirectToAction("Index");

				Context.Characters.Remove(chr);
				await Context.SaveChangesAsync();
			}
			
			return RedirectToAction("Index");
		}
    }
}