using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RestSharp;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class ActivityController : Controller
    {
        private static RestClient client;
        private UserHelper userHelper;
        private ActivityHelper activityHelper;
        public ActivityController()
        {
            client = new RestClient("http://localhost:19099/API%20services/Concrete/ActivityHelperService.svc") { FollowRedirects = false };
            userHelper = new UserHelper();
            activityHelper = new ActivityHelper();
        }
        
        // GET: User/Activity
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            IEnumerable<Activity> activities = activityHelper.GetAll().Where(x => userHelper.GetById((int)x.CreatorId).Email == System.Web.HttpContext.Current.User.Identity.Name);
            return View(activities);
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
