﻿using Microsoft.AspNetCore.Mvc;
using ProjectConfigurationDemo.Models;
using System.Diagnostics;

namespace ProjectConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var logLevelConfiguration = new LoggingLevelConfiguration();
            _configuration.Bind("Logging:LogLevel", logLevelConfiguration);
            var homeModel = new HomeModel
            {
                DefaultLogLevel = logLevelConfiguration.Default
            };
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}