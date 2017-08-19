using System.Web.Http;
using System.Web.Http.Results;
using JobLineAPI.Models;

namespace JobLineAPI.Controllers.API
{
    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        public JsonResult<PingModel> Get()
        {
            PingModel returnData = new PingModel()
            {
                status = "running",
                statusCode = 200
            };
            return Json(returnData);
        }
    }
}
