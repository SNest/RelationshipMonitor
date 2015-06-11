using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RelationshipMonitor.BLL.Business_helpers.Concrete;
using RelationshipMonitor.BOL.Entities;

namespace RelationshipMonitor.PL.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class EventController : Controller
    {
        private readonly UserHelper userHelper;
        private readonly EventHelper eHelper;
        public EventController()
        {
            userHelper = new UserHelper();
            eHelper = new EventHelper();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event e)
        {
            try
            {
                eHelper.Create(e);
                return RedirectToAction("List");
            }
            catch
            {
                return RedirectToAction("List");
            }
        }

        public ViewResult List()
        {
            IEnumerable<Event> events = eHelper.GetAll().Where(x => userHelper.GetById((int)x.CreatorId).Email == System.Web.HttpContext.Current.User.Identity.Name);
            return View(events);
        }

        // GET: Admin/Event/Details/5
        public ActionResult Details(int id)
        {
            BOL.Entities.Event e = eHelper.GetById(id);
            return View(e);
        }


        // GET: Admin/Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event e = eHelper.GetById(id);
            return View(e);
        }

        // POST: Admin/Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BOL.Entities.Event e)
        {
            try
            {
                eHelper.Edit(e);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }

        // GET: Admin/Event/Delete/5
        public ActionResult Delete(int id)
        {
            BOL.Entities.Event e = eHelper.GetById(id);
            return View(e);
        }

        // POST: Admin/Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BOL.Entities.Event e)
        {
            try
            {
                eHelper.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }
    }
}
