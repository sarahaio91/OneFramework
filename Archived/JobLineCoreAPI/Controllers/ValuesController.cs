using System.Collections.Generic;
using JobLineCoreAPI.Localization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JobLineCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class ValuesController : Controller
    {
        private readonly IStringLocalizer _localizer;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IStringLocalizerFactory factory, IConfiguration configuration, ILogger<ValuesController> logger)
        {
            _localizer = factory.Create(typeof(SharedResource));
            _configuration = configuration;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Listing all items");
            var da = _configuration["ConnectionStrings:DefaultConnection"];
            return new string[] { _localizer["Blue"], _localizer["Blue"] };
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
