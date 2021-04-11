using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion_personne_arpilabe.Models;
using System.Net.Http;

namespace Gestion_personne_arpilabe.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            IEnumerable<personne> personneObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/PersonneCrud");

            var consumeapi = hc.GetAsync("PersonneCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<personne>>();
                displaydata.Wait();

                personneObj = displaydata.Result;
            }


            return View(personneObj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]    
        public ActionResult Create(personne insertPersonne)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/PersonneCrud");

            var insertrecord = hc.PostAsJsonAsync<personne>("PersonneCrud", insertPersonne);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

    public ActionResult Details(int id)
        {
            Personne personneObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/");
            var consumeapi = hc.GetAsync("PersonneCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Personne>();
                displaydata.Wait();
                personneObj = displaydata.Result;
            }
            return View(personneObj);
        }

        public ActionResult Edit(int id)
        {
            Personne personneObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/");
            var consumeapi = hc.GetAsync("PersonneCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Personne>();
                displaydata.Wait();
                personneObj = displaydata.Result;
            }
            return View(personneObj);

        }

        [HttpPost]
        public ActionResult Edit(Personne p)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/PersonneCrud");
            var insertrecord = hc.PutAsJsonAsync<Personne>("PersonneCrud", p);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Personne non mise à jour...!";
            }

            return View(p);

        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44319/api/PersonneCrud");

            var delrecord = hc.DeleteAsync("PersonneCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
    }
}