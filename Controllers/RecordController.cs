using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JonaJob.Models;
using System.Text;

namespace JonaJob.Controllers
{
    public class RecordController : Controller
    {
        // GET: RecordController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7034/api/Job";
            List<Job> jobs = new List<Job>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var result = await response.Content.ReadAsStringAsync();
                jobs = JsonConvert.DeserializeObject<List<Job>>(result);
            }
            return View(jobs);
        }

        // GET: RecordController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Job job)
        {
            string apiUrl = "https://localhost:7034/api/Job";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(job);
        }

        // GET: RecordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
