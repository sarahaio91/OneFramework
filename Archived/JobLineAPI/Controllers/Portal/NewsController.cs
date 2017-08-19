using System.Web.Http.Cors;
using System.Web.Mvc;

namespace JobLineAPI.Controllers.Portal
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}