using CalculatorService.Domain.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalController : Controller
    {
        private readonly IJournalQuery _journalQuery;

        public JournalController(IJournalQuery journalQuery)
        {
            _journalQuery = journalQuery;
        }

        [HttpGet("query")]
        public ActionResult JournalQuery(string id)
        {
            var records = _journalQuery.Execute(id);

            return Ok(records);
        }
    }
}
