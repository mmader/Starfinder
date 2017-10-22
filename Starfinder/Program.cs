﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Starfinder.Controllers;
using Starfinder.Models;

namespace Starfinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

		public static IWebHost BuildWebHost(string[] args)
		{
			var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
				.UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build();

			using(var scope = host.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				try {
					var context = services.GetRequiredService<ApplicationDbContext>();
					SeedData.EnsurePopulated(context);
				}
				catch(Exception ex) {
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

			return host;
		}
    }
}
