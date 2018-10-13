using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaWebsite.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DementiaWebsite.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignUpDataContext _db;

        public LoginController(SignUpDataContext db)
        {
            _db = db;
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
        public IActionResult CreateUser(Person person)
        {
            if (!ModelState.IsValid) return View();
            
            person.FirstName = User.Identity.Name;
            person.LastName = User.Identity.Name;
            person.Email = User.Identity.Name;
            person.PassWord = User.Identity.Name;

            _db.Persons.Add(person);
            _db.SaveChanges();

            return View();
        }
        [Route("confirm")]
        public IActionResult ConfirmSignUp()
        {
            return View();
        }

    }
}
