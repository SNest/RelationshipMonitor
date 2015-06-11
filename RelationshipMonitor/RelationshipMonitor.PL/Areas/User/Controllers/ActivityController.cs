using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RelationshipMonitor.PL.Models;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    public class ActivityController : Controller
    {
        private static RestClient client;
        public ActivityController()
        {
            client = new RestClient("http://localhost:19099/API%20services/Concrete/ActivityHelperService.svc") { FollowRedirects = false };
        }
        
        // GET: User/Activity
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            RestRequest request = new RestRequest("api/activity/getall", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Activity> model = JsonConvert.DeserializeObject<IEnumerable<Activity>>(response.Content).ToList();

            return View(model);
        }

        // GET: User/Activity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Activity/Create
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

        // GET: User/Activity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Activity/Edit/5
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

        // GET: User/Activity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Activity/Delete/5
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
