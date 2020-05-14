using ClienteDotNet.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ClienteDotNet.Controllers
{
    public class LembretesController : Controller
    {
        HttpClient client = new HttpClient();

        public LembretesController()
        {
            client.BaseAddress = new Uri("http://deveup.com.br");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Lembretes
        public ActionResult Index()
        {
            List<Lembrete> lembretes = new List<Lembrete>();
            HttpResponseMessage response = client.GetAsync("/notas/api/notes").Result;
            if (response.IsSuccessStatusCode)
            {
                lembretes = response.Content.ReadAsAsync<List<Lembrete>>().Result;
            }
            return View(lembretes);
        }

        // GET: Lembretes/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/notas/api/notes/{id}").Result;
            Lembrete lembrete = response.Content.ReadAsAsync<Lembrete>().Result;
            if (lembrete != null)
            {
                return View(lembrete);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        // GET: Lembretes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lembretes/Create
        [HttpPost]
        public ActionResult Create(Lembrete lembrete)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync<Lembrete>("/notas/api/notes", lembrete).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao criar o lembrete.";
                    return View();
                }
                               
            }
            catch
            {
                return View();
            }
        }

        // GET: Lembretes/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync($"/notas/api/notes/{id}").Result;
            Lembrete lembrete = response.Content.ReadAsAsync<Lembrete>().Result;
            if (lembrete != null)
                return View(lembrete);
            else
                return HttpNotFound();
        }

        // POST: Lembretes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lembrete lembrete)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync<Lembrete>($"/notas/api/notes/{id}", lembrete).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao editar o lembrete.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Lembretes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lembretes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            HttpResponseMessage response = client.GetAsync($"/notas/api/notes/{id}").Result;
            Lembrete note = response.Content.ReadAsAsync<Lembrete>().Result;
            if (note != null)
                return View(note);
            else
                return HttpNotFound();
        }

        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Lembrete lembrete)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync($"/notas/api/notes/{id}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Error = "Excluir";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
