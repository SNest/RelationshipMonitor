using System;
using System.Web.Mvc;
using System.Web.Security;

namespace RelationshipMonitor.PL.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(Models.User user)
        {
            try
            {
                if (Membership.ValidateUser(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
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

        public ActionResult SignOut(Models.User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}