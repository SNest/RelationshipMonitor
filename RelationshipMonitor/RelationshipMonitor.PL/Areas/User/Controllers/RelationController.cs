using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.BOL.Entities;
using RestSharp;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class RelationController : Controller
    {
        private readonly UserHelper userHelper;
        private readonly RelationHelper relationHelper;
        public RelationController()
        {
            userHelper = new UserHelper();
            relationHelper = new RelationHelper();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Relation relation)
        {
            try
            {
                relationHelper.Create(relation);
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return RedirectToAction("List");
            }
        }

        public ViewResult List()
        {
            IEnumerable<Relation> relations = relationHelper.GetAll().Where(x => userHelper.GetById((int)x.Partner1Id).Email == System.Web.HttpContext.Current.User.Identity.Name);
            return View(relations);
        }

        // GET: Admin/Relation/Details/5
        public ActionResult Details(int id)
        {
            BOL.Entities.Relation relation = relationHelper.GetById(id);
            return View(relation);
        }


        // GET: Admin/Relation/Edit/5
        public ActionResult Edit(int id)
        {
            Relation relation = relationHelper.GetById(id);
            return View(relation);
        }

        // POST: Admin/Relation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BOL.Entities.Relation relation)
        {
            try
            {
                relationHelper.Edit(relation);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }

        // GET: Admin/Relation/Delete/5
        public ActionResult Delete(int id)
        {
            BOL.Entities.Relation relation = relationHelper.GetById(id);
            return View(relation);
        }

        // POST: Admin/Relation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BOL.Entities.Relation relation)
        {
            try
            {
                relationHelper.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }
        
        
    }
}
