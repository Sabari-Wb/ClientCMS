using ClientCMS.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class DoctorClientController : Controller
    {
        string Baseurl = "https://localhost:44301/";

        public async Task<IActionResult> Getalldoctordetails()
        {
         
                List<DoctorClient> DoctorInfo = new List<DoctorClient>();

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Doctors/Doctorsdetail");

                    if (Res.IsSuccessStatusCode)
                    {
                        var doctorResponse = Res.Content.ReadAsStringAsync().Result;
                        DoctorInfo = JsonConvert.DeserializeObject<List<DoctorClient>>(doctorResponse);

                    }
                    return View(DoctorInfo);

                }
           

        }

        public IActionResult DCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DCreate(DoctorClient d)
        {
            DoctorClient Dobj = new DoctorClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Doctors", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Dobj = JsonConvert.DeserializeObject<DoctorClient>(apiResponse);
                }
            }
            return RedirectToAction("Getalldoctordetails");
        }

        public async Task<IActionResult> DEdit(int id)
        {
            DoctorClient d = new DoctorClient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44301/api/Doctors/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    d = JsonConvert.DeserializeObject<DoctorClient>(apiResponse);
                }
            }
            return View(d);

        }

        [HttpPost]
        public async Task<IActionResult> DEdit(DoctorClient d)
        {
            DoctorClient d1;
            using (var httpClient = new HttpClient())
            {
                int id = d.DoctorID;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44301/api/Doctors/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    d1 = JsonConvert.DeserializeObject<DoctorClient>(apiResponse);
                }
            }
            return RedirectToAction("Getalldoctordetails");
        }

        [HttpGet]
        public async Task<ActionResult> DDelete(int id)
        {
            TempData["DoctorID"] = id;
            DoctorClient e = new DoctorClient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44301/api/Doctors/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<DoctorClient>(apiResponse);
                }
            }
            return View(e);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(DoctorClient e)
        {
            int DoctorId = Convert.ToInt32(TempData["DoctorID"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44301/api/Doctors/" + DoctorId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Getalldoctordetails");
        }

    }
}
