using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("v1/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class PingController : Controller
    {
        // GET: v1/api/ping
        [HttpGet]
        public JsonResult Get()
        {
            var returnData = new PingModel()
            {
                Status = "running",
                StatusCode = 200
            };
            return Json(returnData);
        }
    }
}
