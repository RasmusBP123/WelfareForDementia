using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DementiaWebsite.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignUpDataContext _db;

        private readonly UserManager<IdentityUser> _userManager;
        public LoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("create")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateUser(Person person)
        {
            if (!ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = person.FirstName,

                };
              var result = await _userManager.CreateAsync(user, person.PassWord);

                if (result.Succeeded)
                {
                    return RedirectToAction("ConfirmSignUp", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }
        [Route("confirm")]
        public IActionResult ConfirmSignUp()
        {
            return View();
        }

    }
}
