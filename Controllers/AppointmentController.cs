
using ClientCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientCMS.Controllers
{
    public class AppointmentController : Controller
    {
        string Baseurl = "https://localhost:44336/";

       

        public async Task<IActionResult> GetallAppointmentdetails()
        {
            List<ScheduleAppointment> AppointmentInfo = new List<ScheduleAppointment>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Appointments/Appointmentsdetail");

                if (Res.IsSuccessStatusCode)
                {
                    var AppointmentResponse = Res.Content.ReadAsStringAsync().Result;
                    AppointmentInfo = JsonConvert.DeserializeObject<List<ScheduleAppointment>>(AppointmentResponse);

                }
                return View(AppointmentInfo);

            }
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ScheduleAppointment d)
        {
         
           
            
                ScheduleAppointment Dobj = new ScheduleAppointment();
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Baseurl);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("api/Appointments", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Dobj = JsonConvert.DeserializeObject<ScheduleAppointment>(apiResponse);
                    }
                }
                return RedirectToAction("GetallAppointmentdetails");
            
           

        }

       

        public async Task<IActionResult> Edit(int id)
        {
            ScheduleAppointment d = new ScheduleAppointment();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Appointments/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    d = JsonConvert.DeserializeObject<ScheduleAppointment>(apiResponse);
                }
            }

            return View(d);
            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ScheduleAppointment d)
        {
           
                ScheduleAppointment d1;
                using (var httpClient = new HttpClient())
                {
                    int id = d.AppointmentID;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://localhost:44336/api/Appointments/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        d1 = JsonConvert.DeserializeObject<ScheduleAppointment>(apiResponse);
                    }
                }
                return RedirectToAction("GetallAppointmentdetails");
            
           

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["AppointmentID"] = id;
            ScheduleAppointment e = new ScheduleAppointment();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44336/api/Appointments/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<ScheduleAppointment>(apiResponse);
                }
            }
            return View(e);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(ScheduleAppointment e)
        {
            int Appointmentid = Convert.ToInt32(TempData["AppointmentID"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44336/api/Appointments/" + Appointmentid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetallAppointmentdetails");
        }
    }
}
