using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RelationshipMonitor.BLL.Business_helpers.Concrete;

namespace RelationshipMonitor.PL.Areas.Security.Controllers
{
     [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly UserHelper userHelper;
        public RegistrationController()
        {
            userHelper = new UserHelper();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(BOL.Entities.User user)
        {
            try
            {
                if (Membership.ValidateUser(user.Email, user.Password))
                {
                    user.Role = "User";
                    userHelper.Create(user);
                    return RedirectToAction("Index", "Home", new {area = "Common"});
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home", new { area = "Common" });
            }
        }

        public ActionResult Profile()
        {
            
            BOL.Entities.User user = userHelper.GetAll().SingleOrDefault(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name);
            return View(user);
        }

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

                return RedirectToAction("Profile");
            }
            catch
            {
                return View("Profile");
            }
        }
    }
}