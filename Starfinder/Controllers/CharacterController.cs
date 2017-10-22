using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starfinder.Interfaces;

namespace Starfinder.Controllers
{
    public class CharacterController : Controller
    {
		private ICharacterRepository Repository;

		public CharacterController(ICharacterRepository repo)
		{
			Repository = repo;
		}

        public IActionResult Index()
        {
            return View(Repository.Characters);
        }
    }
}