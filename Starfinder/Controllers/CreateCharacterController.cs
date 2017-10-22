﻿using System;
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
		private ApplicationDbContext context;

		public CreateCharacterController(ApplicationDbContext ctx)
		{
			context = ctx;
		}

        // GET: /<controller>/
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Save(Character character)
        {
			if(ModelState.IsValid) {
				await context.Characters.AddAsync(character);
				await context.SaveChangesAsync();
			}
			return View("Index");
        }


    }
}
