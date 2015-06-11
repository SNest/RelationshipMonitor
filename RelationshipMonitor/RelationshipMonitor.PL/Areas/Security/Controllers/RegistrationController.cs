using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RelationshipMonitor.PL.Areas.Security.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Security/Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp(Models.User user)
        {
            try
            {
                if (Membership.ValidateUser(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home", new {area = "Common"});
                }
                else
                {
                    TempData["Msg"] = "Login failed ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Login failed " + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}