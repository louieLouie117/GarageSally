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
            if (FromForm.StartDate == DateTime.MinValue)
            {
                return Json(new { Status = "Date has not been selected!" });

            }


            if (FromForm.StartTime == DateTime.MinValue)
            {
                return Json(new { Status = "Start time has not be selected!" });

            };

            if (FromForm.EndTime == DateTime.MinValue)
            {
                return Json(new { Status = "End time has not be selected!" });

            };
            if (FromForm.StreetNumber == null)
            {
                FromForm.StreetNumber = "";
            }

            if (FromForm.Description == null)
            {
                return Json(new { Status = "Description can not be empty!" });

            }

            if (FromForm.StreetName == null)
            {
                return Json(new { Status = "Street name can not be empty!" });

            }

            if (FromForm.City == null)
            {
                return Json(new { Status = "City can not be empty!" });

            }

            if (FromForm.State == null)
            {
                return Json(new { Status = "State can not be empty!" });

            }
            if (FromForm.Zipcode == 0)
            {
                return Json(new { Status = "Zipcode can not be empty!" });

            }



            System.Console.WriteLine("you have reached the backend of post garage sale.");


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
                County = FromForm.County,
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

            if (FromForm.StreetName == null)
            {
                return Json(new { Status = "Street name can not be empty!" });

            }

            if (FromForm.City == null)
            {
                return Json(new { Status = "City can not be empty!" });

            }

            if (FromForm.State == null)
            {
                return Json(new { Status = "State can not be empty!" });

            }

            if (FromForm.Zipcode == 0)
            {
                return Json(new { Status = "Zipcode can not be empty!" });

            }


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

        [HttpGet("GetAllUsersByState")]
        public JsonResult GetAllUsersByState()
        {
            // Still need these for debugging? Console.Writelines should be removed
            // DashboardWrapper wMode = new DashboardWrapper();

            List<GarageSale> ALList = _context.GarageSales
            .Where(st => st.State == "AL")
            .ToList();
            List<GarageSale> WYList = _context.GarageSales
           .Where(st => st.State == "WY")
           .ToList();
            List<GarageSale> WIList = _context.GarageSales
           .Where(st => st.State == "WI")
           .ToList();
            List<GarageSale> WVList = _context.GarageSales
           .Where(st => st.State == "WV")
           .ToList();
            List<GarageSale> WAList = _context.GarageSales
           .Where(st => st.State == "WA")
           .ToList();
            List<GarageSale> VAList = _context.GarageSales
           .Where(st => st.State == "VA")
           .ToList();
            List<GarageSale> UTList = _context.GarageSales
           .Where(st => st.State == "UT")
           .ToList();

            List<GarageSale> TXList = _context.GarageSales
            .Where(st => st.State == "TX")
            .ToList();

            List<GarageSale> TNList = _context.GarageSales
           .Where(st => st.State == "TN")
           .ToList();

            List<GarageSale> SDList = _context.GarageSales
           .Where(st => st.State == "SD")
           .ToList();

            List<GarageSale> SCList = _context.GarageSales
           .Where(st => st.State == "SC")
           .ToList();
            List<GarageSale> RIList = _context.GarageSales
           .Where(st => st.State == "RI")
           .ToList();
            List<GarageSale> PAList = _context.GarageSales
           .Where(st => st.State == "PA")
           .ToList();
            List<GarageSale> ORList = _context.GarageSales
           .Where(st => st.State == "OR")
           .ToList();
            List<GarageSale> OKList = _context.GarageSales
           .Where(st => st.State == "OK")
           .ToList();
            List<GarageSale> OHList = _context.GarageSales
           .Where(st => st.State == "OH")
           .ToList();
            List<GarageSale> NDList = _context.GarageSales
           .Where(st => st.State == "ND")
           .ToList();
            List<GarageSale> NCList = _context.GarageSales
           .Where(st => st.State == "NC")
           .ToList();
            List<GarageSale> NYList = _context.GarageSales
           .Where(st => st.State == "NY")
           .ToList();
            List<GarageSale> NMList = _context.GarageSales
           .Where(st => st.State == "NM")
           .ToList();
            List<GarageSale> NJList = _context.GarageSales
           .Where(st => st.State == "NJ")
           .ToList();
            List<GarageSale> NHList = _context.GarageSales
           .Where(st => st.State == "NH")
           .ToList();
            List<GarageSale> NVList = _context.GarageSales
           .Where(st => st.State == "NV")
           .ToList();
            List<GarageSale> NEList = _context.GarageSales
           .Where(st => st.State == "NE")
           .ToList();
            List<GarageSale> MTList = _context.GarageSales
           .Where(st => st.State == "MT")
           .ToList();
            List<GarageSale> MOList = _context.GarageSales
           .Where(st => st.State == "MO")
           .ToList();
            List<GarageSale> MSList = _context.GarageSales
           .Where(st => st.State == "MS")
           .ToList();
            List<GarageSale> MNList = _context.GarageSales
           .Where(st => st.State == "MN")
           .ToList();
            List<GarageSale> MIList = _context.GarageSales
           .Where(st => st.State == "MI")
           .ToList();
            List<GarageSale> MAList = _context.GarageSales
           .Where(st => st.State == "MA")
           .ToList();
            List<GarageSale> MDList = _context.GarageSales
           .Where(st => st.State == "MD")
           .ToList();
            List<GarageSale> MEList = _context.GarageSales
           .Where(st => st.State == "ME")
           .ToList();
            List<GarageSale> LAList = _context.GarageSales
           .Where(st => st.State == "LA")
           .ToList();
            List<GarageSale> KYList = _context.GarageSales
           .Where(st => st.State == "KY")
           .ToList();
            List<GarageSale> KSList = _context.GarageSales
           .Where(st => st.State == "KS")
           .ToList();
            List<GarageSale> IAList = _context.GarageSales
           .Where(st => st.State == "IA")
           .ToList();
            List<GarageSale> INList = _context.GarageSales
           .Where(st => st.State == "IN")
           .ToList();
            List<GarageSale> ILList = _context.GarageSales
           .Where(st => st.State == "IL")
           .ToList();
            List<GarageSale> IDList = _context.GarageSales
           .Where(st => st.State == "ID")
           .ToList();
            List<GarageSale> HIList = _context.GarageSales
           .Where(st => st.State == "HI")
           .ToList();
            List<GarageSale> GAList = _context.GarageSales
           .Where(st => st.State == "GA")
           .ToList();
            List<GarageSale> FLList = _context.GarageSales
           .Where(st => st.State == "FL")
           .ToList();
            List<GarageSale> DEList = _context.GarageSales
           .Where(st => st.State == "DE")
           .ToList();
            List<GarageSale> CTList = _context.GarageSales
           .Where(st => st.State == "CT")
           .ToList();
            List<GarageSale> COList = _context.GarageSales
           .Where(st => st.State == "CO")
           .ToList();
            List<GarageSale> CAList = _context.GarageSales
           .Where(st => st.State == "CA")
           .ToList();
            List<GarageSale> ARList = _context.GarageSales
           .Where(st => st.State == "AR")
           .ToList();
            List<GarageSale> AZList = _context.GarageSales
           .Where(st => st.State == "AZ")
           .ToList();
            List<GarageSale> AKList = _context.GarageSales
           .Where(st => st.State == "AK")
           .ToList();

            var AllSales = new
            {
                AL = ALList.Count,
                AK = AKList.Count,
                AZ = AZList.Count,
                AR = ARList.Count,
                CA = CAList.Count,
                CO = COList.Count,
                CT = CTList.Count,
                DE = DEList.Count,
                FL = FLList.Count,
                GA = GAList.Count,
                HI = HIList.Count,
                ID = IDList.Count,
                IL = ILList.Count,
                IN = INList.Count,
                IA = IAList.Count,
                KS = KSList.Count,
                KY = KYList.Count,
                LA = LAList.Count,
                ME = MEList.Count,
                MD = MDList.Count,
                MA = MAList.Count,
                MI = MIList.Count,
                MN = MNList.Count,
                MS = MSList.Count,
                MO = MOList.Count,
                MT = MTList.Count,
                NE = NEList.Count,
                NV = NVList.Count,
                NH = NHList.Count,
                NJ = NJList.Count,
                NM = NMList.Count,
                NY = NYList.Count,
                NC = NCList.Count,
                ND = NDList.Count,
                OH = OHList.Count,
                OK = OKList.Count,
                OR = ORList.Count,
                PA = PAList.Count,
                RI = RIList.Count,
                SC = SCList.Count,
                SD = SDList.Count,
                TN = TNList.Count,
                TX = TXList.Count,
                UT = UTList.Count,
                VA = VAList.Count,
                WA = WAList.Count,
                WV = WVList.Count,
                WI = WIList.Count,
                WY = WYList.Count
            };



            return Json(new { data = AllSales });

        }

        [HttpGet("GetSalesByState")]
        public JsonResult GetSalesByState()
        {
            // Still need these for debugging? Console.Writelines should be removed
            // DashboardWrapper wMode = new DashboardWrapper();


            // 1.Alabama
            List<GarageSale> AllSalesInAL = _context.GarageSales
            .Where(st => st.State == "AL")
            .ToList();
            List<GarageSale> NewSalesInAL = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "AL")
            .ToList();
            var Alabama = new List<string>();
            Alabama.Add("Alabama");
            Alabama.Add(AllSalesInAL.Count.ToString());
            Alabama.Add(NewSalesInAL.Count.ToString());

            // 2.Alaska
            List<GarageSale> AllSalesInAK = _context.GarageSales
            .Where(st => st.State == "AK")
            .ToList();
            List<GarageSale> NewSalesInAK = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "AK")
            .ToList();
            var Alaska = new List<string>();
            Alaska.Add("Alaska");
            Alaska.Add(AllSalesInAK.Count.ToString());
            Alaska.Add(NewSalesInAK.Count.ToString());

            // 3.Arizona
            List<GarageSale> AllSalesInAZ = _context.GarageSales
            .Where(st => st.State == "AZ")
            .ToList();
            List<GarageSale> NewSalesInAZ = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "AZ")
            .ToList();
            var Arizona = new List<string>();
            Arizona.Add("Arizona");
            Arizona.Add(AllSalesInAZ.Count.ToString());
            Arizona.Add(NewSalesInAZ.Count.ToString());

            // 4.Arkansas
            List<GarageSale> AllSalesInAR = _context.GarageSales
            .Where(st => st.State == "AR")
            .ToList();
            List<GarageSale> NewSalesInAR = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "AR")
            .ToList();
            var Arkansas = new List<string>();
            Arkansas.Add("Arkansas");
            Arkansas.Add(AllSalesInAR.Count.ToString());
            Arkansas.Add(NewSalesInAR.Count.ToString());

            // 5.California
            List<GarageSale> AllSalesInCA = _context.GarageSales
            .Where(st => st.State == "CA")
            .ToList();
            List<GarageSale> NewSalesInCA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "CA")
            .ToList();
            var California = new List<string>();
            California.Add("California");
            California.Add(AllSalesInCA.Count.ToString());
            California.Add(NewSalesInCA.Count.ToString());


            // 6.Colorado
            List<GarageSale> AllSalesInCO = _context.GarageSales
            .Where(st => st.State == "CO")
            .ToList();
            List<GarageSale> NewSalesInCO = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "CO")
            .ToList();
            var Colorado = new List<string>();
            Colorado.Add("Colorado");
            Colorado.Add(AllSalesInCO.Count.ToString());
            Colorado.Add(NewSalesInCO.Count.ToString());


            // 7.Connecticut
            List<GarageSale> AllSalesInCT = _context.GarageSales
            .Where(st => st.State == "CT")
            .ToList();
            List<GarageSale> NewSalesInCT = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "CT")
            .ToList();
            var Connecticut = new List<string>();
            Connecticut.Add("Connecticut");
            Connecticut.Add(AllSalesInCT.Count.ToString());
            Connecticut.Add(NewSalesInCT.Count.ToString());

            // 8.Delaware
            List<GarageSale> AllSalesInDE = _context.GarageSales
            .Where(st => st.State == "DE")
            .ToList();
            List<GarageSale> NewSalesInDE = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "DE")
            .ToList();
            var Delaware = new List<string>();
            Delaware.Add("Delaware");
            Delaware.Add(AllSalesInDE.Count.ToString());
            Delaware.Add(NewSalesInDE.Count.ToString());


            // 9.Florida
            List<GarageSale> AllSalesInFL = _context.GarageSales
            .Where(st => st.State == "FL")
            .ToList();
            List<GarageSale> NewSalesInFL = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "FL")
            .ToList();
            var Florida = new List<string>();
            Florida.Add("Florida");
            Florida.Add(AllSalesInFL.Count.ToString());
            Florida.Add(NewSalesInFL.Count.ToString());

            // 10.Georgia
            List<GarageSale> AllSalesInGA = _context.GarageSales
            .Where(st => st.State == "GA")
            .ToList();
            List<GarageSale> NewSalesInGA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "GA")
            .ToList();
            var Georgia = new List<string>();
            Georgia.Add("Georgia");
            Georgia.Add(AllSalesInGA.Count.ToString());
            Georgia.Add(NewSalesInGA.Count.ToString());


            // 11.Hawaii
            List<GarageSale> AllSalesInHI = _context.GarageSales
            .Where(st => st.State == "HI")
            .ToList();
            List<GarageSale> NewSalesInHI = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "HI")
            .ToList();
            var Hawaii = new List<string>();
            Hawaii.Add("Hawaii");
            Hawaii.Add(AllSalesInHI.Count.ToString());
            Hawaii.Add(NewSalesInHI.Count.ToString());

            //12.Idaho
            List<GarageSale> AllSalesInID = _context.GarageSales
            .Where(st => st.State == "ID")
            .ToList();
            List<GarageSale> NewSalesInID = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "ID")
            .ToList();
            var Idaho = new List<string>();
            Idaho.Add("Idaho");
            Idaho.Add(AllSalesInID.Count.ToString());
            Idaho.Add(NewSalesInID.Count.ToString());

            // 13.Illinois
            List<GarageSale> AllSalesInIL = _context.GarageSales
            .Where(st => st.State == "IL")
            .ToList();
            List<GarageSale> NewSalesInIL = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "IL")
            .ToList();
            var Illinois = new List<string>();
            Illinois.Add("Illinois");
            Illinois.Add(AllSalesInIL.Count.ToString());
            Illinois.Add(NewSalesInIL.Count.ToString());

            // 14.Indiana
            List<GarageSale> AllSalesInIN = _context.GarageSales
            .Where(st => st.State == "IN")
            .ToList();
            List<GarageSale> NewSalesInIN = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "IN")
            .ToList();
            var Indiana = new List<string>();
            Indiana.Add("Indiana");
            Indiana.Add(AllSalesInIN.Count.ToString());
            Indiana.Add(NewSalesInIN.Count.ToString());


            // 15.Iowa
            List<GarageSale> AllSalesInIA = _context.GarageSales
            .Where(st => st.State == "IA")
            .ToList();
            List<GarageSale> NewSalesInIA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "IA")
            .ToList();
            var Iowa = new List<string>();
            Iowa.Add("Iowa");
            Iowa.Add(AllSalesInIA.Count.ToString());
            Iowa.Add(NewSalesInIA.Count.ToString());

            // 16.Kansas
            List<GarageSale> AllSalesInKS = _context.GarageSales
            .Where(st => st.State == "KS")
            .ToList();
            List<GarageSale> NewSalesInKS = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "KS")
            .ToList();
            var Kansas = new List<string>();
            Kansas.Add("Kansas");
            Kansas.Add(AllSalesInKS.Count.ToString());
            Kansas.Add(NewSalesInKS.Count.ToString());

            // 17.Kentucky
            List<GarageSale> AllSalesInKY = _context.GarageSales
            .Where(st => st.State == "KY")
            .ToList();
            List<GarageSale> NewSalesInKY = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "KY")
            .ToList();
            var Kentucky = new List<string>();
            Kentucky.Add("Kentucky");
            Kentucky.Add(AllSalesInKY.Count.ToString());
            Kentucky.Add(NewSalesInKY.Count.ToString());


            // 18. Louisiana
            List<GarageSale> AllSalesInLA = _context.GarageSales
            .Where(st => st.State == "LA")
            .ToList();
            List<GarageSale> NewSalesInLA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "LA")
            .ToList();
            var Louisiana = new List<string>();
            Louisiana.Add("Louisiana");
            Louisiana.Add(AllSalesInLA.Count.ToString());
            Louisiana.Add(NewSalesInLA.Count.ToString());

            // 19.Maine
            List<GarageSale> AllSalesInME = _context.GarageSales
            .Where(st => st.State == "ME")
            .ToList();
            List<GarageSale> NewSalesInME = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "ME")
            .ToList();
            var Maine = new List<string>();
            Maine.Add("Maine");
            Maine.Add(AllSalesInME.Count.ToString());
            Maine.Add(NewSalesInME.Count.ToString());


            // 20.Maryland
            List<GarageSale> AllSalesInMD = _context.GarageSales
            .Where(st => st.State == "MD")
            .ToList();
            List<GarageSale> NewSalesInMD = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MD")
            .ToList();
            var Maryland = new List<string>();
            Maryland.Add("Maryland");
            Maryland.Add(AllSalesInMD.Count.ToString());
            Maryland.Add(NewSalesInMD.Count.ToString());

            // 21.Massachusetts
            List<GarageSale> AllSalesInMA = _context.GarageSales
            .Where(st => st.State == "MA")
            .ToList();
            List<GarageSale> NewSalesInMA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MA")
            .ToList();
            var Massachusetts = new List<string>();
            Massachusetts.Add("Massachusetts");
            Massachusetts.Add(AllSalesInMA.Count.ToString());
            Massachusetts.Add(NewSalesInMA.Count.ToString());


            // 22.Michigan
            List<GarageSale> AllSalesInMI = _context.GarageSales
            .Where(st => st.State == "MI")
            .ToList();
            List<GarageSale> NewSalesInMI = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MI")
            .ToList();
            var Michigan = new List<string>();
            Michigan.Add("Michigan");
            Michigan.Add(AllSalesInMI.Count.ToString());
            Michigan.Add(NewSalesInMI.Count.ToString());


            // 23.Minnesota
            List<GarageSale> AllSalesInMN = _context.GarageSales
            .Where(st => st.State == "MN")
            .ToList();
            List<GarageSale> NewSalesInMN = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MN")
            .ToList();
            var Minnesota = new List<string>();
            Minnesota.Add("Minnesota");
            Minnesota.Add(AllSalesInMN.Count.ToString());
            Minnesota.Add(NewSalesInMN.Count.ToString());


            //24.Mississippi
            List<GarageSale> AllSalesInMS = _context.GarageSales
            .Where(st => st.State == "MS")
            .ToList();
            List<GarageSale> NewSalesInMS = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MS")
            .ToList();
            var Mississippi = new List<string>();
            Mississippi.Add("Mississippi");
            Mississippi.Add(AllSalesInMS.Count.ToString());
            Mississippi.Add(NewSalesInMS.Count.ToString());


            // 25.Missouri
            List<GarageSale> AllSalesInMO = _context.GarageSales
            .Where(st => st.State == "MO")
            .ToList();
            List<GarageSale> NewSalesInMO = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MO")
            .ToList();
            var Missouri = new List<string>();
            Missouri.Add("Missouri");
            Missouri.Add(AllSalesInMO.Count.ToString());
            Missouri.Add(NewSalesInMO.Count.ToString());


            // 26.Montana
            List<GarageSale> AllSalesInMT = _context.GarageSales
            .Where(st => st.State == "MT")
            .ToList();
            List<GarageSale> NewSalesInMT = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "MT")
            .ToList();
            var Montana = new List<string>();
            Montana.Add("Montana");
            Montana.Add(AllSalesInMT.Count.ToString());
            Montana.Add(NewSalesInMT.Count.ToString());


            // 27.Nebraska
            List<GarageSale> AllSalesInNE = _context.GarageSales
            .Where(st => st.State == "NE")
            .ToList();
            List<GarageSale> NewSalesInNE = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NE")
            .ToList();
            var Nebraska = new List<string>();
            Nebraska.Add("Nebraska");
            Nebraska.Add(AllSalesInNE.Count.ToString());
            Nebraska.Add(NewSalesInNE.Count.ToString());

            // 28.Nevada
            List<GarageSale> AllSalesInNV = _context.GarageSales
            .Where(st => st.State == "NV")
            .ToList();
            List<GarageSale> NewSalesInNV = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NV")
            .ToList();
            var Nevada = new List<string>();
            Nevada.Add("Nevada");
            Nevada.Add(AllSalesInNV.Count.ToString());
            Nevada.Add(NewSalesInNV.Count.ToString());

            // 29.NewHampshire
            List<GarageSale> AllSalesInNH = _context.GarageSales
            .Where(st => st.State == "NH")
            .ToList();
            List<GarageSale> NewSalesInNH = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NH")
            .ToList();
            var NewHampshire = new List<string>();
            NewHampshire.Add("New Hampshire");
            NewHampshire.Add(AllSalesInNH.Count.ToString());
            NewHampshire.Add(NewSalesInNH.Count.ToString());

            // 30.NewJersey
            List<GarageSale> AllSalesInNJ = _context.GarageSales
            .Where(st => st.State == "NJ")
            .ToList();
            List<GarageSale> NewSalesInNJ = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NJ")
            .ToList();
            var NewJersey = new List<string>();
            NewJersey.Add("New Jersey");
            NewJersey.Add(AllSalesInNJ.Count.ToString());
            NewJersey.Add(NewSalesInNJ.Count.ToString());

            // 31.NewMexico
            List<GarageSale> AllSalesInNM = _context.GarageSales
            .Where(st => st.State == "NM")
            .ToList();
            List<GarageSale> NewSalesInNM = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NM")
            .ToList();
            var NewMexico = new List<string>();
            NewMexico.Add("New Mexico");
            NewMexico.Add(AllSalesInNM.Count.ToString());
            NewMexico.Add(NewSalesInNM.Count.ToString());

            // 32.NewYork
            List<GarageSale> AllSalesInNY = _context.GarageSales
            .Where(st => st.State == "NY")
            .ToList();
            List<GarageSale> NewSalesInNY = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NY")
            .ToList();
            var NewYork = new List<string>();
            NewYork.Add("New York");
            NewYork.Add(AllSalesInNY.Count.ToString());
            NewYork.Add(NewSalesInNY.Count.ToString());


            // 33.NorthCarolina
            List<GarageSale> AllSalesInNC = _context.GarageSales
            .Where(st => st.State == "NC")
            .ToList();
            List<GarageSale> NewSalesInNC = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "NC")
            .ToList();
            var NorthCarolina = new List<string>();
            NorthCarolina.Add("North Carolina");
            NorthCarolina.Add(AllSalesInNC.Count.ToString());
            NorthCarolina.Add(NewSalesInNC.Count.ToString());

            // 34.NorthDakota
            List<GarageSale> AllSalesInND = _context.GarageSales
            .Where(st => st.State == "ND")
            .ToList();
            List<GarageSale> NewSalesInND = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "ND")
            .ToList();
            var NorthDakota = new List<string>();
            NorthDakota.Add("North Dakota");
            NorthDakota.Add(AllSalesInND.Count.ToString());
            NorthDakota.Add(NewSalesInND.Count.ToString());

            // 35.Ohio
            List<GarageSale> AllSalesInOH = _context.GarageSales
            .Where(st => st.State == "OH")
            .ToList();
            List<GarageSale> NewSalesInOH = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "OH")
            .ToList();
            var Ohio = new List<string>();
            Ohio.Add("Ohio");
            Ohio.Add(NewSalesInOH.Count.ToString());
            Ohio.Add(NewSalesInOH.Count.ToString());

            // 36.Oklahoma
            List<GarageSale> AllSalesInOK = _context.GarageSales
            .Where(st => st.State == "OK")
            .ToList();
            List<GarageSale> NewSalesInOK = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "OK")
            .ToList();
            var Oklahoma = new List<string>();
            Oklahoma.Add("Oklahoma");
            Oklahoma.Add(AllSalesInOK.Count.ToString());
            Oklahoma.Add(NewSalesInOK.Count.ToString());

            // 37.Oregon
            List<GarageSale> AllSalesInOR = _context.GarageSales
            .Where(st => st.State == "OR")
            .ToList();
            List<GarageSale> NewSalesInOR = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "OR")
            .ToList();
            var Oregon = new List<string>();
            Oregon.Add("Oregon");
            Oregon.Add(AllSalesInOR.Count.ToString());
            Oregon.Add(NewSalesInOR.Count.ToString());


            // 38.Pennsylvania
            List<GarageSale> AllSalesInPA = _context.GarageSales
            .Where(st => st.State == "PA")
            .ToList();
            List<GarageSale> NewSalesInPA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "PA")
            .ToList();
            var Pennsylvania = new List<string>();
            Pennsylvania.Add("Pennsylvania");
            Pennsylvania.Add(AllSalesInPA.Count.ToString());
            Pennsylvania.Add(NewSalesInPA.Count.ToString());


            // 39.RhodeIsland
            List<GarageSale> AllSalesInRI = _context.GarageSales
            .Where(st => st.State == "RI")
            .ToList();
            List<GarageSale> NewSalesInRI = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "RI")
            .ToList();
            var RhodeIsland = new List<string>();
            RhodeIsland.Add("Rhode Island");
            RhodeIsland.Add(AllSalesInRI.Count.ToString());
            RhodeIsland.Add(NewSalesInRI.Count.ToString());

            // 40.SouthCarolina
            List<GarageSale> AllSalesInSC = _context.GarageSales
            .Where(st => st.State == "SC")
            .ToList();
            List<GarageSale> NewSalesInSC = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "SC")
            .ToList();
            var SouthCarolina = new List<string>();
            SouthCarolina.Add("South Carolina");
            SouthCarolina.Add(AllSalesInSC.Count.ToString());
            SouthCarolina.Add(NewSalesInSC.Count.ToString());

            // 41.SouthDakota
            List<GarageSale> AllSalesInSD = _context.GarageSales
            .Where(st => st.State == "SD")
            .ToList();
            List<GarageSale> NewSalesInSD = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "SD")
            .ToList();
            var SouthDakota = new List<string>();
            SouthDakota.Add("South Dakota");
            SouthDakota.Add(AllSalesInSD.Count.ToString());
            SouthDakota.Add(NewSalesInSD.Count.ToString());

            // 42.Tennessee
            List<GarageSale> AllSalesInTN = _context.GarageSales
            .Where(st => st.State == "TN")
            .ToList();
            List<GarageSale> NewSalesInTN = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "TN")
            .ToList();
            var Tennessee = new List<string>();
            Tennessee.Add("Tennessee");
            Tennessee.Add(AllSalesInTN.Count.ToString());
            Tennessee.Add(NewSalesInTN.Count.ToString());

            // 43.Texas
            List<GarageSale> AllSalesInTX = _context.GarageSales
            .Where(st => st.State == "TX")
            .ToList();
            List<GarageSale> NewSalesInTX = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "TX")
            .ToList();
            var Texas = new List<string>();
            Texas.Add("Texas");
            Texas.Add(AllSalesInTX.Count.ToString());
            Texas.Add(NewSalesInTX.Count.ToString());

            // 44.Utah
            List<GarageSale> AllSalesInUT = _context.GarageSales
            .Where(st => st.State == "UT")
            .ToList();
            List<GarageSale> NewSalesInUT = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "UT")
            .ToList();
            var Utah = new List<string>();
            Utah.Add("Utah");
            Utah.Add(NewSalesInUT.Count.ToString());
            Utah.Add(NewSalesInUT.Count.ToString());

            // 45.Vermont
            List<GarageSale> AllSalesInVT = _context.GarageSales
            .Where(st => st.State == "VT")
            .ToList();
            List<GarageSale> NewSalesInVT = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "VT")
            .ToList();
            var Vermont = new List<string>();
            Vermont.Add("Vermont");
            Vermont.Add(AllSalesInVT.Count.ToString());
            Vermont.Add(NewSalesInVT.Count.ToString());

            // 46.Virginia
            List<GarageSale> AllSalesInVA = _context.GarageSales
            .Where(st => st.State == "VA")
            .ToList();
            List<GarageSale> NewSalesInVA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "VA")
            .ToList();
            var Virginia = new List<string>();
            Virginia.Add("Virginia");
            Virginia.Add(AllSalesInVA.Count.ToString());
            Virginia.Add(NewSalesInVA.Count.ToString());

            // 47.Washington
            List<GarageSale> AllSalesInWA = _context.GarageSales
            .Where(st => st.State == "WA")
            .ToList();
            List<GarageSale> NewSalesInWA = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "WA")
            .ToList();
            var Washington = new List<string>();
            Washington.Add("Washington");
            Washington.Add(AllSalesInWA.Count.ToString());
            Washington.Add(NewSalesInWA.Count.ToString());

            // 48.WestVirginia
            List<GarageSale> AllSalesInWV = _context.GarageSales
            .Where(st => st.State == "WV")
            .ToList();
            List<GarageSale> NewSalesInWV = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "WV")
            .ToList();
            var WestVirginia = new List<string>();
            WestVirginia.Add("West Virginia");
            WestVirginia.Add(AllSalesInWV.Count.ToString());
            WestVirginia.Add(NewSalesInWV.Count.ToString());

            // 49.Wisconsin
            List<GarageSale> AllSalesInWI = _context.GarageSales
            .Where(st => st.State == "WI")
            .ToList();
            List<GarageSale> NewSalesInWI = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "WI")
            .ToList();
            var Wisconsin = new List<string>();
            Wisconsin.Add("Wisconsin");
            Wisconsin.Add(AllSalesInWI.Count.ToString());
            Wisconsin.Add(NewSalesInWI.Count.ToString());

            // 50.Wyoming
            List<GarageSale> AllSalesInWY = _context.GarageSales
            .Where(st => st.State == "WY")
            .ToList();
            List<GarageSale> NewSalesInWY = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == "WY")
            .ToList();
            var Wyoming = new List<string>();
            Wyoming.Add("Wyoming");
            Wyoming.Add(AllSalesInWY.Count.ToString());
            Wyoming.Add(NewSalesInWY.Count.ToString());

            var StateData = new
            {
                AL = Alabama,
                AK = Alaska,
                AZ = Arizona,
                AR = Arkansas,
                CA = California,
                CO = Colorado,
                CT = Connecticut,
                DE = Delaware,
                FL = Florida,
                GA = Georgia,
                HI = Hawaii,
                ID = Idaho,
                IL = Illinois,
                IN = Indiana,
                IA = Iowa,
                KY = Kentucky,
                LA = Louisiana,
                ME = Maine,
                MD = Maryland,
                MA = Massachusetts,
                MI = Michigan,
                MN = Minnesota,
                MS = Mississippi,
                MO = Missouri,
                MT = Montana,
                NE = Nebraska,
                NA = Nevada,
                NH = NewHampshire,
                NJ = NewJersey,
                NM = NewMexico,
                NY = NewYork,
                NC = NorthCarolina,
                ND = NorthDakota,
                OH = Ohio,
                OK = Oklahoma,
                OR = Oregon,
                PA = Pennsylvania,
                RI = RhodeIsland,
                SC = SouthCarolina,
                SD = SouthDakota,
                TN = Tennessee,
                TX = Texas,
                UT = Utah,
                VT = Vermont,
                VA = Virginia,
                WA = Washington,
                WV = WestVirginia,
                WI = Wisconsin,
                WY = Wyoming

            };

            // 5.ADDState
            //     List<GarageSale> AllSalesInXX = _context.GarageSales
            //    .Where(td => td.StartDate >= DateTime.Now)
            //    .Where(st => st.State == "XX")
            //    .ToList();
            //     List<GarageSale> NewSalesInXX = _context.GarageSales
            //     .Where(td => td.StartDate >= DateTime.Now)
            //     .Where(st => st.State == "XX")
            //     .ToList();
            //     var ADDState = new List<int>();
            //     ADDState.Add(AllSalesInXX.Count);
            //     ADDState.Add(NewSalesInXX.Count);


            return Json(new { data = StateData });

        }

        [HttpGet("GetZipCodeBySate")]
        public JsonResult GetZipCodeBySate(GarageSale userSateSelected)
        {
            System.Console.WriteLine("you have reached the backend of get zipcode!!");

            var stateSelected = userSateSelected.State;
            System.Console.WriteLine(stateSelected);


            List<GarageSale> GetZipCodeBySate = _context.GarageSales
            .Where(td => td.StartDate >= DateTime.Now)
            .Where(st => st.State == stateSelected)
            .ToList();
            return Json(new { data = GetZipCodeBySate });
        }




        [HttpGet("GetAllUsersForOverview")]
        public JsonResult GetAllUsersForOverview()
        {
            List<User> GetAllUsersForOverview = _context.Users
            .ToList();
            return Json(new { data = GetAllUsersForOverview });
        }


        [HttpGet("GetBuyersForOverview")]
        public JsonResult GetBuyersForOverview()
        {
            List<User> GetBuyersForOverview = _context.Users
            .Where(us => us.AccountType == AccountType.Buyer)
            .ToList();
            return Json(new { data = GetBuyersForOverview });
        }

        // Count for landing page----------------------
        [HttpGet("ListedGarageSaleCount")]
        public JsonResult ListedGarageSaleCount()
        {
            List<GarageSale> garageSaleItems = _context.GarageSales
            .ToList();
            return Json(new { data = garageSaleItems.Count });
        }

        [HttpGet("SellerCount")]
        public JsonResult SellerCount()
        {
            List<User> sellerCount = _context.Users
            .Where(us => us.AccountType == AccountType.Seller)
            .ToList();
            return Json(new { data = sellerCount.Count });
        }


        [HttpGet("BuyersCount")]
        public JsonResult BuyersCount()
        {
            List<User> BuyersCount = _context.Users
            // .Where(us => us.AccountType == AccountType.Buyer)
            .ToList();
            return Json(new { data = BuyersCount.Count });
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
            // Filter out sales that are in the past
            .Where(d => d.StartDate >= DateTime.Now)
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
            FromForm.County = "";
            FromForm.ProfilePic = "placeholder.png";
            _context.Add(FromForm);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
            HttpContext.Session.SetString("UserState", _context.Users.FirstOrDefault(i => i.State == FromForm.State).State);
            // Still need these for debugging? Console.Writelines should be removed
            Console.WriteLine("You may contine!");
            return RedirectToAction("dashboard");
        }

        [HttpPost("RegisterBuyer")]
        public JsonResult RegisterBuyer(User FromForm)
        {

            System.Console.WriteLine($"You have reached the backend of buyer registration! {FromForm.Email}");
            // DashboardWrapper wMod = new DashboardWrapper();

            if (FromForm.Email == null)
            {
                return Json(new { Status = "Email can not be empty!" });

            }

            if (FromForm.Password == null)
            {
                return Json(new { Status = "Password can not be empty!" });

            }

            if (FromForm.Password != FromForm.Confirm)
            {
                return Json(new { Status = "Password do not match!" });

            }


            if (FromForm.Zipcode == 0)
            {
                return Json(new { Status = "Zipcode can not be empty!" });

            }



            if (_context.Users.Any(u => u.Email == FromForm.Email))
            {
                return Json(new { Status = "Email already in use!" });

            }
            else
            {

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);

                FromForm.AccountType = AccountType.Buyer;
                FromForm.SubscriptionStatus = SubscriptionStatus.Free;
                FromForm.FirstName = "";
                FromForm.LastName = "";
                FromForm.StreetNumber = "";
                FromForm.StreetName = "";
                FromForm.City = "";
                // remove the county empty string
                FromForm.ProfilePic = "placeholder.png";
                _context.Add(FromForm);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", _context.Users.FirstOrDefault(i => i.UserId == FromForm.UserId).UserId);
                HttpContext.Session.SetString("UserState", _context.Users.FirstOrDefault(i => i.State == FromForm.State).State);
                HttpContext.Session.SetString("UserCounty", _context.Users.FirstOrDefault(i => i.County == FromForm.County).County);
                HttpContext.Session.SetInt32("UserZipcode", _context.Users.FirstOrDefault(i => i.Zipcode == FromForm.Zipcode).Zipcode);


                // Still need these for debugging? Console.Writelines should be removed
                Console.WriteLine("You may contine!");
                return Json(new { Status = "Successfully registered buyer!" });

            }




        }


        [HttpPost("SellerRegistration")]
        public JsonResult SellerRegistration(User FromForm)
        {

            System.Console.WriteLine($"You have reach the back end of seller registration {FromForm.Email}");


            if (FromForm.Zipcode == 0)
            {
                return Json(new { Status = "Zipcode can not be empty!" });

            }
            if (FromForm.Email == null)
            {
                return Json(new { Status = "Email can not be empty!" });

            }

            if (FromForm.Password == null)
            {
                return Json(new { Status = "Password can not be empty!" });

            }

            if (FromForm.Password != FromForm.Confirm)
            {
                return Json(new { Status = "Password do not match!" });

            }


            if (_context.Users.Any(u => u.Email == FromForm.Email))
            {
                return Json(new { Status = "Email already in use!" });

            }

            else
            {
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
                HttpContext.Session.SetString("UserCounty", _context.Users.FirstOrDefault(i => i.County == FromForm.County).County);
                HttpContext.Session.SetInt32("UserZipcode", _context.Users.FirstOrDefault(i => i.Zipcode == FromForm.Zipcode).Zipcode);
                // Still need these for debugging? Console.Writelines should be removed
                Console.WriteLine("You may contine!");
                return Json(new { Status = "Successfully registered seller!" });

            }



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
                FromForm.County = "";
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
        // [HttpPost("login")]
        // public IActionResult Login(LoginUser userSubmission)
        // {
        //     DashboardWrapper wMod = new DashboardWrapper();
        //     if (ModelState.IsValid)
        //     {
        //         User userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        //         if (userInDb == null)
        //         {
        //             ModelState.AddModelError("Email", "Invalid Email/Password");
        //             // return View("login");
        //             return RedirectToAction("index");

        //         }
        //         var hasher = new PasswordHasher<LoginUser>();
        //         var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
        //         if (result == 0)
        //         {
        //             // Still need these for debugging? Console.Writelines should be removed
        //             // something else should happer here besides a WriteLine
        //             Console.WriteLine("Password error");
        //             return View("index", wMod);
        //         }
        //         HttpContext.Session.SetInt32("UserId", userInDb.UserId);
        //         HttpContext.Session.SetString("UserState", userInDb.State);
        //         return RedirectToAction("dashboard");
        //     }
        //     return View("index", wMod);
        // }

        [HttpPost("login")]
        public JsonResult Login(LoginUser userSubmission)
        {

            System.Console.WriteLine("you reach the backend!!");
            System.Console.WriteLine($"email {userSubmission.Email}");
            System.Console.WriteLine($"password {userSubmission.Password}");

            DashboardWrapper wMod = new DashboardWrapper();

            if (ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    Console.WriteLine($"email error");

                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return Json(new { Status = "email error" });


                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if (result == 0)
                {
                    // Still need these for debugging? Console.Writelines should be removed
                    // something else should happer here besides a WriteLine
                    Console.WriteLine("Password error");
                    return Json(new { Status = "password error" });


                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserState", userInDb.State);
                Console.WriteLine("Success user is register");

                return Json(new { Status = "Access Granted" });

            }
            Console.WriteLine("No access");

            return Json(new { Status = false });

        }

        [HttpGet("SendToDashboard")]
        public IActionResult SendToDashboard()
        {
            return RedirectToAction("dashboard");
        }


        [HttpGet("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}