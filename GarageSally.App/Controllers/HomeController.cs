using System;
using Microsoft.AspNetCore.Mvc;
using UserLogin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

// for file upload
using System.IO;
using System.Threading.Tasks;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

namespace UserLogin.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public int GarageSaleId { get; private set; }

        public HomeController(MyContext context)
        {
            _context = context;
        }
        // Redirects
        [HttpGet("signin")]
        public IActionResult gotoSignin()
        {
            return RedirectToAction("index");
        }

        [HttpGet("registration")]
        public IActionResult gotoRegistration()
        {
            return RedirectToAction("index");
        }

        // Rendering
        [HttpGet("")]
        public IActionResult index()
        {
            DashboardWrapper wMod = new DashboardWrapper();
            return View("index", wMod);
        }

        [HttpGet("login")]
        public IActionResult login()
        {
            return View("login");
        }

        [HttpGet("dashboard")]
        public IActionResult dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("index");
            }
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User UserIndb = _context.Users
                .FirstOrDefault(u => u.UserId == UserIdInSession);
            ViewBag.ToDisplay = UserIndb;
            ViewBag.allUserLogs = _context.Users
                .Where(ul => ul.UserId == UserIdInSession)
                .ToList();
            DashboardWrapper wMod = new DashboardWrapper();
            wMod.User = UserIndb;
            return View("dashboard", wMod);
        }

        [HttpGet("profile")]
        public IActionResult profilePartial()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.AllUsers = _context.Users.ToList();
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User UserIndb = _context.Users
                .FirstOrDefault(u => u.UserId == UserIdInSession);
            ViewBag.ToDisplay = UserIndb;
            return View("profilePartial");
        }

        [HttpPost("PostGarageSaleHandler")]
        public IActionResult PostGarageSaleHandler(GarageSale FromForm)
        {
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("you have reached the backend of post garage sale.");
            System.Console.WriteLine("test button was click");
            System.Console.WriteLine("the backend has been reached");
            System.Console.WriteLine($"FromForm: {FromForm}");
            System.Console.WriteLine($"Street #: {FromForm.StreetNumber}");
            System.Console.WriteLine($"Street name: {FromForm.StreetName}");
            System.Console.WriteLine($"City: {FromForm.City}");
            System.Console.WriteLine($"ZipCode: {FromForm.Zipcode}");
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            var Entry = new GarageSale
            {
                UserId = UserIdInSession,
                StartDate = FromForm.StartDate,
                StartTime = FromForm.StartTime,
                EndTime = FromForm.EndTime,
                Description = FromForm.Description,
                StreetNumber = FromForm.StreetNumber,
                StreetName = FromForm.StreetName,
                City = FromForm.City,
                State = FromForm.State,
                Zipcode = FromForm.Zipcode,
                Image = "placeholder.png"
            };
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine($"Entry to be send to db {Entry}");
            _context.Add(Entry);
            _context.SaveChanges();
            return Json(new { Status = "success" });
        }

        [HttpPost("DeleteSaleHandler")]
        public IActionResult DeleteSaleHandler(GarageSale FromForm)
        {
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("reached the backend to delete sale");
            System.Console.WriteLine($"Item to delete: {FromForm.GarageSaleId}");
            GarageSale GetSale = _context.GarageSales.SingleOrDefault(l => l.GarageSaleId == FromForm.GarageSaleId);
            _context.GarageSales.Remove(GetSale);
            _context.SaveChanges();
            return Json(new { Status = "success deleteing" });
        }

        [HttpPost("UpdateProfileHandler")]
        public IActionResult UpdateProfileHandler(User FromForm)
        {
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("you have reach the backend for updating the user info!");
            System.Console.WriteLine(FromForm.LastName);
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User GetUser = _context.Users.FirstOrDefault(u => u.UserId == UserIdInSession);
            if (FromForm.FirstName == null)
            {
                GetUser.FirstName = "";
            }
            else
            {
                GetUser.FirstName = FromForm.FirstName;
            }
            if (FromForm.LastName == null)
            {
                GetUser.LastName = "";
            }
            else
            {
                GetUser.LastName = FromForm.LastName;
            }
            if (FromForm.StreetNumber == null)
            {
                GetUser.StreetNumber = "";
            }
            else
            {
                GetUser.StreetNumber = FromForm.StreetNumber;
            }
            if (FromForm.StreetName == null)
            {
                GetUser.StreetName = "";
            }
            else
            {
                GetUser.StreetName = FromForm.StreetName;
            }
            if (FromForm.City == null)
            {
                GetUser.City = "";
            }
            else
            {
                GetUser.City = FromForm.City;
            }
            if (FromForm.State == null)
            {
                GetUser.State = "";
            }
            else
            {
                GetUser.State = FromForm.State;
            }
            _context.SaveChanges();
            return Json(new { Status = "Success" });
        }

        [HttpPost("UpgradeUserHandler")]
        public IActionResult UpgradeUserHandler(User FromForm)
        {
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("you have reach the backend of upgraded user");
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User GetUser = _context.Users.FirstOrDefault(u => u.UserId == UserIdInSession);
            GetUser.AccountType = AccountType.Seller;
            GetUser.StreetNumber = FromForm.StreetNumber;
            GetUser.StreetName = FromForm.StreetName;
            GetUser.City = FromForm.City;
            GetUser.State = FromForm.State;
            GetUser.Zipcode = FromForm.Zipcode;
            _context.SaveChanges();
            return Json(new { Status = "Success" });
        }

        [HttpGet("displayGarageSales")]
        public JsonResult displayGarageSales()
        {
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            string UserStateInSession = HttpContext.Session.GetString("UserState");
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine(UserStateInSession);
            DashboardWrapper wMode = new DashboardWrapper();
            List<GarageSale> garageSaleItems = _context.GarageSales
            .Where(us => us.State == UserStateInSession)
            .OrderByDescending(d => d.StartDate)
            .ToList();
            return Json(new { data = garageSaleItems });
        }

        [HttpGet("displayUserGarageSales")]
        public JsonResult displayUserGarageSales()
        {
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            string UserStateInSession = HttpContext.Session.GetString("UserState");
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine(UserStateInSession);
            DashboardWrapper wMode = new DashboardWrapper();
            List<GarageSale> garageSaleItems = _context.GarageSales
            .Where(us => us.UserId == UserIdInSession)
            .OrderByDescending(d => d.StartDate)
            .ToList();
            return Json(new { data = garageSaleItems });
        }


        [HttpGet("SearchZipCodeHandler")]
        public JsonResult SearchZipCodeHandler(GarageSale Data)

        {
            System.Console.WriteLine("you have reached the backend of zip code");

            System.Console.WriteLine($"Data {Data.Zipcode}");

            HttpContext.Session.SetInt32("SearchZipCode", Data.Zipcode);

            return Json(new { status = "session success" });



        }

        [HttpGet("SearchResultsZipcode")]
        public JsonResult SearchResultsZipcode()
        {

            int SearchZipCodeInSession = (int)HttpContext.Session.GetInt32("SearchZipCode");

            System.Console.WriteLine("seesion zip code", SearchZipCodeInSession);

            List<GarageSale> SearchResults = _context.GarageSales
            .Where(r => r.Zipcode == SearchZipCodeInSession)
            .OrderByDescending(d => d.StartDate)
            .ToList();

            return Json(new { Data = SearchResults });

        }


        [HttpGet("SearchCityHandler")]
        public JsonResult SearchCityHandler(GarageSale Data)

        {
            System.Console.WriteLine("you have reached the backend of city");

            System.Console.WriteLine($"City: {Data.City}");
            System.Console.WriteLine($"State: {Data.State}");


            HttpContext.Session.SetString("SearchCity", Data.City);
            HttpContext.Session.SetString("SearchState", Data.State);


            return Json(new { status = "session success" });



        }


        [HttpGet("SearchCityResults")]
        public JsonResult SearchCityResults()
        {

            string SearchCityInSession = HttpContext.Session.GetString("SearchCity");
            string SearchStateInSession = HttpContext.Session.GetString("SearchState");


            System.Console.WriteLine("seesion zip code", SearchCityInSession);

            List<GarageSale> CitySearchResults = _context.GarageSales
            .Where(c => c.City == SearchCityInSession)
            .Where(s => s.State == SearchStateInSession)
            .OrderByDescending(d => d.StartDate)
            .ToList();

            return Json(new { Data = CitySearchResults });

        }









        [HttpGet("DisplayUserProfile")]
        public JsonResult DisplayUserProfile()
        {
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            DashboardWrapper wMode = new DashboardWrapper();
            List<User> UserInfo = _context.Users
                .Where(ul => ul.UserId == UserIdInSession)
                .ToList();
            return Json(new { data = UserInfo });
        }

        // Form Processing
        [HttpPost("ChangePhotoHandler")]
        public async Task<IActionResult> ChangePhotoHandler(List<IFormFile> files, User FromForm)
        {
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("you have reach the backend of change photo handler");
            int UserIdInSession = (int)HttpContext.Session.GetInt32("UserId");
            User GetUser = _context.Users.FirstOrDefault(u => u.UserId == UserIdInSession);
            long size = files.Sum(f => f.Length);
            // Still need these for debugging? Console.Writelines should be removed
            System.Console.WriteLine("here is files:", files);
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string timeStampMonth = DateTime.Now.Month.ToString("00");
                    string timeStampDay = DateTime.Now.Day.ToString("00");
                    string timeStampHour = DateTime.Now.Hour.ToString("00");
                    string timeStampMinutes = DateTime.Now.Minute.ToString("00");
                    string timeStampSeconds = DateTime.Now.Second.ToString("00");
                    string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");
                    // Still need these for debugging? Console.Writelines should be removed
                    Console.WriteLine($"Apprentice Name: {FromForm.FirstName}");
                    Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");
                    string newName = $"{timeStamp}{formFile.FileName}";
                    GetUser.ProfilePic = newName;
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            _context.SaveChanges();
            // Still need these for debugging? Console.Writelines should be removed
            Console.WriteLine("Photo has been changed!");
            return RedirectToAction("dashboard");
        }

        // What's going on with this route?
        // [HttpPost("registerBuyerWithImage")]
        // public async Task<IActionResult> Redgister(List<IFormFile> files, User FromForm)
        // {
        //     DashboardWrapper wMod = new DashboardWrapper();
        //     // Check if email is already in db
        //     if (_context.Users.Any(u => u.Email == FromForm.Email))
        //     {
        //         ModelState.AddModelError("Email", "Email already in use!");
        //     }
        //     // Validations
        //     if (ModelState.IsValid)
        //     {
        //         long size = files.Sum(f => f.Length);
        //         System.Console.WriteLine("here is files:", files);
        //         var filePaths = new List<string>();
        //         foreach (var formFile in files)
        //         {
        //             if (formFile.Length > 0)
        //             {
        //                 // TimeStamp
        //                 string timeStampMonth = DateTime.Now.Month.ToString("00");
        //                 string timeStampDay = DateTime.Now.Day.ToString("00");
        //                 string timeStampHour = DateTime.Now.Hour.ToString("00");
        //                 string timeStampMinutes = DateTime.Now.Minute.ToString("00");
        //                 string timeStampSeconds = DateTime.Now.Second.ToString("00");
        //                 string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";
        //                 //Place to save file
        //                 var filePath = Path.Combine(Directory.GetCurrentDirectory(),
        //                 "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");
        //                 // for the db
        //                 Console.WriteLine($"Apprentice Name: {FromForm.FirstName}");
        //                 Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");
        //                 // Assign name to be saved to the db
        //                 string newName = $"{timeStamp}{formFile.FileName}";
        //                 FromForm.ProfilePic = newName;
        //                 filePaths.Add(filePath);
        //                 using (var stream = new FileStream(filePath, FileMode.Create))
        //                 {
        //                     await formFile.CopyToAsync(stream);
        //                 }
        //             }
        //         }
        //         // #hash password
        //         PasswordHasher<User> Hasher = new PasswordHasher<User>();
        //         FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);
        //         FromForm.AccountType = AccountType.Buyer;
        //         FromForm.LastName = "";
        //         FromForm.StreetNumber = "";
        //         FromForm.StreetName = "";
        //         FromForm.City = "";
        //         // Add to db
        //         _context.Add(FromForm);
        //         _context.SaveChanges();
        //         // Session
        //         HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
        //         // Redirect
        //         Console.WriteLine("You may contine!");
        //         return RedirectToAction("dashboard");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Fix your errors!");
        //         return View("index", wMod);
        //     }
        // }

        [HttpPost("register")]
        public IActionResult Redgister(User FromForm)
        {
            DashboardWrapper wMod = new DashboardWrapper();
            if (_context.Users.Any(u => u.Email == FromForm.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
            }
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);
            }
            else
            {
                // Still need these for debugging? Console.Writelines should be removed
                Console.WriteLine("Fix your errors!");
                return View("index", wMod);
            }
            FromForm.AccountType = AccountType.Buyer;
            FromForm.SubscriptionStatus = SubscriptionStatus.Free;
            FromForm.FirstName = "";
            FromForm.LastName = "";
            FromForm.StreetNumber = "";
            FromForm.StreetName = "";
            FromForm.City = "";
            FromForm.ProfilePic = "placeholder.png";
            _context.Add(FromForm);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
            HttpContext.Session.SetString("UserState", _context.Users.FirstOrDefault(i => i.State == FromForm.State).State);
            // Still need these for debugging? Console.Writelines should be removed
            Console.WriteLine("You may contine!");
            return RedirectToAction("dashboard");
        }

        [HttpPost("registerSeller")]
        public async Task<IActionResult> registerSeller(List<IFormFile> files, User FromForm)
        {
            DashboardWrapper wMod = new DashboardWrapper();
            if (_context.Users.Any(u => u.Email == FromForm.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
            }
            if (ModelState.IsValid)
            {
                long size = files.Sum(f => f.Length);
                System.Console.WriteLine("here is files:", files);
                var filePaths = new List<string>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        string timeStampMonth = DateTime.Now.Month.ToString("00");
                        string timeStampDay = DateTime.Now.Day.ToString("00");
                        string timeStampHour = DateTime.Now.Hour.ToString("00");
                        string timeStampMinutes = DateTime.Now.Minute.ToString("00");
                        string timeStampSeconds = DateTime.Now.Second.ToString("00");
                        string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");
                        // Still need these for debugging? Console.Writelines should be removed
                        Console.WriteLine($"Apprentice Name: {FromForm.FirstName}");
                        Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");
                        string newName = $"{timeStamp}{formFile.FileName}";
                        FromForm.ProfilePic = newName;
                        filePaths.Add(filePath);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);
                FromForm.AccountType = AccountType.Seller;
                FromForm.SubscriptionStatus = SubscriptionStatus.Free;
                FromForm.FirstName = "";
                FromForm.LastName = "";
                FromForm.StreetNumber = "";
                FromForm.StreetName = "";
                FromForm.City = "";
                FromForm.ProfilePic = "placeholder.png";
                _context.Add(FromForm);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
                HttpContext.Session.SetString("UserState", _context.Users.FirstOrDefault(i => i.State == FromForm.State).State);
                // Still need these for debugging? Console.Writelines should be removed
                Console.WriteLine("You may contine!");
                return RedirectToAction("dashboard");
            }
            else
            {
                Console.WriteLine("Fix your errors!");
                return View("index", wMod);
            }
        }

        [HttpPost("profile/update")]
        public async Task<IActionResult> UpdateProfile(User FromForm)
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            if (await _context.Users.AnyAsync(u => u.UserId == UserId))
            {
                FromForm.UserId = UserId;
                _context.Update(FromForm);
                _context.Entry(FromForm).Property("CreatedAt").IsModified = false;
                _context.SaveChanges();
                return RedirectToAction("profile");
            }
            return RedirectToAction("profile");
        }

        //Processing Login-------------------------------------------------
        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            DashboardWrapper wMod = new DashboardWrapper();
            if (ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    // return View("login");
                    return RedirectToAction("index");

                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if (result == 0)
                {
                    // Still need these for debugging? Console.Writelines should be removed
                    // something else should happer here besides a WriteLine
                    Console.WriteLine("Password error");
                    return View("index", wMod);
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserState", userInDb.State);
                return RedirectToAction("dashboard");
            }
            return View("index", wMod);
        }

        [HttpGet("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}