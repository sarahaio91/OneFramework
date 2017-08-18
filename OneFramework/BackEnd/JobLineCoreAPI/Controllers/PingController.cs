using JobLineCoreAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JobLineCoreAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class PingController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var returnData = new PingModel()
            {
                status = "running",
                statusCode = 200
            };
            return Json(returnData);
        }
    }
}
