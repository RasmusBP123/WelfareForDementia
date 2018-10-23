using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DementiaWebsite.Controllers
{
    public class ConfirmController : Controller
    {
        [Route("confirm")]
        public IActionResult ConfirmSignUp()
        {
            return View();
        }
    }
}