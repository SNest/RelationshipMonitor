using System.Web.Mvc;

namespace RelationshipMonitor.PL.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}