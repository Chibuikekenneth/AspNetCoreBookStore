﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreBookStore.Models;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.ViewModels;

namespace AspNetCoreBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _service;

        public HomeController(IBookRepository service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                bookOfTheWeek = _service.BooksOfTheWeek()
            };
            return View(homeViewModel);
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
