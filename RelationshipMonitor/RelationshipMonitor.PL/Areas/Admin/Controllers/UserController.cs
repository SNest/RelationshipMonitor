using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace RelationshipMonitor.PL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private static RestClient client;
        public UserController()
        {
            client = new RestClient("http://localhost:19099/API%20services/Concrete/UserHelperService.svc") { FollowRedirects = false };
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            RestRequest request = new RestRequest("api/user/getall", Method.GET);
            IRestResponse response = client.Execute(request);
            List<Models.User> model = JsonConvert.DeserializeObject<IEnumerable<Models.User>>(response.Content).ToList();

            return View(model);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
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

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/User/Edit/5
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

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/User/Delete/5
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
