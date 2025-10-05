using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HundredX.API.Data;
using HundredX.API.Models;

namespace HundredX.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricalRecordsController : ControllerBase
    {
        private readonly HundredxContext _context;

        public HistoricalRecordsController(HundredxContext context)
        {
            _context = context;
        }

        // GET /historicalrecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricalRecord>>> GetAll()
        {
            var records = await _context.HistoricalRecords.ToListAsync();
            return Ok(records);
        }
    }
}
