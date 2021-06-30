
using ClientCMS.Data;
using ClientCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly CMSClientContext _db;
        public LoginController(CMSClientContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login l)
         {

            User obj = (from i in _db.Users where i.Username == l.UserName && i.Password == l.Password select i).FirstOrDefault();
            if (obj != null)
            {
                string Username = obj.Username;
                HttpContext.Session.SetString("Username", Username);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid username or Password";
                return View();
            }

        }
    }
}
