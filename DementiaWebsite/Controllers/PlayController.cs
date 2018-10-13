﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DementiaWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DementiaWebsite.Controllers
{
    public class PlayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(Game game)
        {
            game.NameOfGame = "Go";
            return View(game);
        }
    }
}
