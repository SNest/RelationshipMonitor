using System.Collections.Generic;
using System.Web.Mvc;
using RelationshipMonitor.BLL.Business_helpers.Concrete;

namespace RelationshipMonitor.PL.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserHelper userHelper;
        public UserController()
        {
            userHelper = new UserHelper();
        }

        public ViewResult List()
        {
            IEnumerable<BOL.Entities.User> users = userHelper.GetAll();
            return View(users);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            BOL.Entities.User user = userHelper.GetById(id);
            return View(user);
        }

       
        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            BOL.Entities.User user = userHelper.GetById(id);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BOL.Entities.User user)
        {
            try
            {
                userHelper.Edit(user);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            BOL.Entities.User user = userHelper.GetById(id);
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BOL.Entities.User user)
        {
            try
            {
                userHelper.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }
    }
}
