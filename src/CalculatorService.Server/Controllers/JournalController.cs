using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalController : Controller
    {
        [HttpGet("query")]
        public ActionResult Query(string id)
        {

            return Ok();
        }
    }
}
