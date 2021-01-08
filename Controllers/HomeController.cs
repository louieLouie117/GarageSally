using System;
using Microsoft.AspNetCore.Mvc;
using UserLogin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace UserLogin.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }


        // Navigation no process
        [HttpGet("signin")]
        public IActionResult gotoSignin()
        {
            return RedirectToAction("login");
        }

        [HttpGet("registration")]
        public IActionResult gotoRegistration()
        {
            return RedirectToAction("index");
        }

        // -----------------------------------------------------------end

        // Rendering Pages in Views--------------------------------------------
        [HttpGet("")]
        public IActionResult index()
        {
            return View("index");
        }


        [HttpGet("login")]
        public IActionResult login()
        {
            return View("login");
        }


        [HttpGet("dashboard")]
        public IActionResult dashboard()
        {
            // block pages is not in session
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("index");
            }

            return View("dashboard");
        }
        // -----------------------------------------------------------end


        // Processing Registration and Login-------------------------------------------------
        [HttpPost("Redgister")]
        public IActionResult Redgister(User FromForm)
        {
            // Check if email is already in db
            if (_context.Users.Any(u => u.Email == FromForm.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
            }

            // Validations
            if (ModelState.IsValid)
            {
                // #hash password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);

                // Add to db
                _context.Add(FromForm);
                _context.SaveChanges();

                // Session
                HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
                // Redirect
                System.Console.WriteLine("You may contine!");
                return RedirectToAction("dashboard");
            }
            else
            {
                System.Console.WriteLine("Fix your erros!");
                return View("index");

            }

        }



        //Processing Registration Login-------------------------------------------------    
        [HttpPost("Login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            // Validations
            if (ModelState.IsValid)
            {
                // Check db email with from email
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);

                // No user in db
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("login");
                }
                // Check hashing are the same
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                }
                // Set Session Instance
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("dashboard");

            }

            return View("login");

        }


        [HttpGet("logout")]
        public IActionResult logout()
        {
            // Clear Session
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }



        // ------------------------------------------end of registration and login








    }
}