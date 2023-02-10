using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Web_Proj.Models;

namespace Test_Web_Proj.Controllers
{
    public class HomeController : Controller
    {
        public ShopWebContext _context { get; set; }
        ShopWebContext db;


        public HomeController(ShopWebContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index_Auth()
        {

            return View();


        }
        public IActionResult Index_Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Auth(string Password, string Email)
        {
            User userLogin = db.Users.FirstOrDefault(p => p.UsersEmail == Email);
                HttpContext.Session.SetString("Id_User", userLogin.IdUsers.ToString());
                Debug.WriteLine(HttpContext.Session.GetString("Id_User"));

                return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Index_Register(string Name, string Fam, string Ot, DateTime Birth, string Gender, DateTime DateStart, DateTime DateStartMPT, DateTime DateStartTeach, string Email, string Password)
        {
            
                User user = new User
                {
                    UsersEmail = Email,
                    UsersLogin = Email,
                    UsersPassword = Password,
                    UsersStatus = "Open",
                };
                db.Users.Add(user);
                db.SaveChanges();

                UsersInfo info = new UsersInfo
                {
                    UsersInfoFio = Fam + " " + Name + " " + Ot,
                    UsersInfoLastName = Fam,
                    UsersInfoName = Name,
                    UsersInfoMiddleName = Ot,
                    UsersInfoDateBirthday = Birth,
                    UsersInfoDateStartWork = DateStart,
                    UsersInfoDateStartWorkMpt = DateStartMPT,
                    UsersInfoDateStartWorkTeacher = DateStartTeach,
                    UsersSId = (db.Users.Where(a => a.UsersEmail == Email).Single().IdUsers),
                    RolesId = 2

                };
                db.UsersInfos.Add(info);
                await db.SaveChangesAsync();
                
                return RedirectToAction("Index_Auth");
           

        }





    }
}