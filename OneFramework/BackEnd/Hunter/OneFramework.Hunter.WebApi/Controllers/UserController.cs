using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneFramework.Auth.WebApi.Response;
using OneFramework.Hunter.Domain.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneFramework.Auth.WebApi.Controllers
{
    [Route("v1/[controller]")]
    public class UserController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = AuthTokenOption.TokenType)]
        public JsonResult Get()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
            return Json(new Result()
            {
                State = RequestState.Success,
                Message = "User logged in.",
                Data = new UserData()
                {
                    //requestAt = requestAt,
                    ExpireIn = AuthTokenOption.ExpiresSpan.TotalSeconds,
                    TokenType = AuthTokenOption.TokenType,
                    //accessToken = token,
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
