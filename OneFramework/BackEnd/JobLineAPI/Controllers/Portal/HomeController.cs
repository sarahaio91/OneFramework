using System.Web.Mvc;

namespace JobLineAPI.Controllers.Portal
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
