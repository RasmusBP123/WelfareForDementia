using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DementiaWebsite.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> _signinManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateUser(Person person)
        {
            if (!ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = person.Email,
                };
                var result = await _userManager.CreateAsync(user, person.PassWord);

                if (result.Succeeded)
                {
                    return RedirectToAction("ConfirmSignUp", "Confirm");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(person);
        }
        [HttpGet, Route("create")]
        public IActionResult CreateUser()
        {
            return View();
        }

    }
}
