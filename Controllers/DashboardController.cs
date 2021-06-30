using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Controllers
{
   
    public class DashboardController : Controller
    {
  
        public IActionResult Index()
        {
            ViewBag.msg = HttpContext.Session.GetString("Username");
            if (ViewBag.msg != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
        [Authorize]
        public IActionResult DoctorInformation()
        {
            return View();
        }
       
        public IActionResult PatientInformation()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult UserInformation()
        {
            return View();
        }



    }

}
