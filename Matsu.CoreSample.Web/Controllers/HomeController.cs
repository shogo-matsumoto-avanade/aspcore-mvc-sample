﻿using Matsu.CoreSample.Common;
using Matsu.CoreSample.Common.Domain.Users;
using Matsu.CoreSample.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Matsu.CoreSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var result = GetDbResults();
            return View("Index", result);
        }

        public string GetDbResults()
        {
            return _userService.Get("1").Name;
        }

        //public string GetWorkFlowResults()
        //{
        //    var api = new LogicAppsStandardWebApi();
        //    var result = api.CallHttpTrigger("https://la4standard.azurewebsites.net:443/api/WF-HTTPtrigger/triggers/manual/invoke?api-version=2022-05-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0", "tFJChuAq-AwUYqVJIOrtFrsGlQcqG7QA3JiXE6YhB0c").Result.ToString();
        //    return $"Time from Logic Apps: {result}";
        //}

        public string GetApiResults()
        {
            return "Success App Service Api Call!";
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