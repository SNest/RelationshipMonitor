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

        public ActionResult SignIn(BOL.Entities.User user)
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
                   return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut(BOL.Entities.User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}