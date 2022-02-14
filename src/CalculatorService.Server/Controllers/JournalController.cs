using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalController : Controller
    {
        [HttpPost("query")]
        public ActionResult Query(string id)
        {

            return Ok();
        }
    }
}
