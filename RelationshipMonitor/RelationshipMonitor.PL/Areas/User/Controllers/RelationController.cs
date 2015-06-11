using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using RelationshipMonitor.BOL.Entities;
using RestSharp;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class RelationController : Controller
    {
        // GET: User/Relation
        private static RestClient client;
        public RelationController()
        {
            client = new RestClient("http://localhost:19099/API%20services/Concrete/RelationHelperService.svc") { FollowRedirects = false };
        }
        // GET: User/Event
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            RestRequest request = new RestRequest("api/relation/getall", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Relation> model = JsonConvert.DeserializeObject<IEnumerable<Relation>>(response.Content).ToList();

            return View(model);
        }

        // GET: User/Relation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Relation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Relation/Create
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

        // GET: User/Relation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Relation/Edit/5
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

        // GET: User/Relation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Relation/Delete/5
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
