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
    public class PatientClientController : Controller
    {
        string Baseurl = "https://localhost:44315/";

        public async Task<IActionResult> Getallpatientdetails()
        {


            List<Patient> PatientInfo = new List<Patient>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patients/patientdetails");

                if (Res.IsSuccessStatusCode)
                {
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;
                    PatientInfo = JsonConvert.DeserializeObject<List<Patient>>(ProductResponse);

                }
                return View(PatientInfo);

            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient p)
        {
            Patient Pobj = new Patient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Patients/insertpatient", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pobj = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return RedirectToAction("Getallpatientdetails");
        }
       

        public async Task<IActionResult> Edit(int id)
        {
            Patient p = new Patient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44315/api/Patients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return View(p);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Patient p)
        {
            Patient p1;
            using (var httpClient = new HttpClient())
            {
                int id = p.PatientID;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44315/api/Patients/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    p1 = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return RedirectToAction("Getallpatientdetails");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["PatientID"] = id;
            Patient e = new Patient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44315/api/Patients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return View(e);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Patient e)
        {
            int PatientId = Convert.ToInt32(TempData["PatientID"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44315/api/Patients/" + PatientId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Getallpatientdetails");
        }
    }





    
}
