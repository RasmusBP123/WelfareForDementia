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
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateUser(Person person)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    Id = null,
                    UserName = person.Email,
                    Email = person.Email,
                    EmailConfirmed = true,
                    NormalizedUserName = null,
                    NormalizedEmail = null,
                    SecurityStamp = null,
                    ConcurrencyStamp = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                };
                var result = await _userManager.CreateAsync(user, person.PassWord);

                if (result.Succeeded)
                {
                    return RedirectToAction("LoginUser", "Login");
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
        
        [HttpGet, Route("login")]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginUser(Login login, string returnURL = null)
        {
            if (ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, 
                    login.RememberMe, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnURL))
                    {
                        Redirect(returnURL);
                    }
                    else
                    {
                        RedirectToAction(nameof(GameController.Index), "Play");
                    }
                }
                else
                {             
                        ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
