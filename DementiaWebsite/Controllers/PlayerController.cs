﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DementiaWebsite.Models;

namespace DementiaWebsite.Controllers
{
    [Route("player")]
    public class PlayerController : Controller
    {
       
        public IActionResult Index()
        { 
            return View();
        }

    }
}
