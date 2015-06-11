using System;
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
        private readonly UserHelper userHelper;
        private readonly ActivityHelper activityHelper;
        public ActivityController()
        {
            userHelper = new UserHelper();
            activityHelper = new ActivityHelper();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            try
            {
                activityHelper.Create(activity);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return RedirectToAction("List");
            }
        }

        public ViewResult List()
        {
            IEnumerable<Activity> activities = activityHelper.GetAll().Where(x => userHelper.GetById((int)x.CreatorId).Email == System.Web.HttpContext.Current.User.Identity.Name);
            return View(activities);
        }

        // GET: Admin/Activity/Details/5
        public ActionResult Details(int id)
        {
            BOL.Entities.Activity activity = activityHelper.GetById(id);
            return View(activity);
        }


        // GET: Admin/Activity/Edit/5
        public ActionResult Edit(int id)
        {
            Activity activity = activityHelper.GetById(id);
            return View(activity);
        }

        // POST: Admin/Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BOL.Entities.Activity activity)
        {
            try
            {
                activityHelper.Edit(activity);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }

        // GET: Admin/Activity/Delete/5
        public ActionResult Delete(int id)
        {
            BOL.Entities.Activity activity = activityHelper.GetById(id);
            return View(activity);
        }

        // POST: Admin/Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BOL.Entities.Activity activity)
        {
            try
            {
                activityHelper.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }
       
        
    }
}
