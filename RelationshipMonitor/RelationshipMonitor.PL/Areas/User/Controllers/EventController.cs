using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RelationshipMonitor.BOL.Entities;
using RestSharp;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class EventController : Controller
    {
        private static RestClient client;
        public EventController()
        {
            client = new RestClient("http://localhost:19099/API%20services/Concrete/EventHelperService.svc") { FollowRedirects = false };
        }
        // GET: User/Event
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            RestRequest request = new RestRequest("api/event/getall", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Event> model = JsonConvert.DeserializeObject<IEnumerable<Event>>(response.Content).ToList();

            return View(model);
        }

        // GET: User/Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Event/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
