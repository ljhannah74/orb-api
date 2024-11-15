using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orb_api.Models;

namespace orb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbController : ControllerBase
    {
        private readonly OrbDbContext _context;

        public OrbController(OrbDbContext context)
        {
            _context = context;
        }

          // GET: api/orb
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetStates()
        {
            var states = await _context.Orbs
                    .Where(orb => orb.State != null)
                    .Select(orb => orb.State!)
                    .Distinct()
                    .ToListAsync();

            return Ok(states);
        }

        // GET: api/orb/{state}
        [HttpGet("{state}")]
        public async Task<ActionResult<IEnumerable<string>>> GetCountiesByState(string state)
        {
                var counties = await _context.Orbs
                           .Where(orb => orb.State != null && orb.State == state)
                           .Select(orb => orb.County!)
                           .Where(county => county != null)
                           .Distinct()
                           .ToListAsync();

            return counties.Count > 0 ? Ok(counties) : NotFound();
        }

        // GET: api/orb/{state}/{county}
        [HttpGet("{state}/{county}")]
        public async Task<ActionResult<IEnumerable<string>>> GetOrbsByStateAndCounty(string state, string county)
        {
                var orbs = await _context.Orbs
                           .Where(orb => orb.State != null && orb.State == state)
                           .Where(orb => orb.County != null && orb.County == county)
                           .ToListAsync();

            return orbs.Count > 0 ? Ok(orbs) : NotFound();
        }

        // PUT: api/orb/{state}/{county}
        [HttpPut("{state}/{county}")]
        public async Task<IActionResult> UpdateOrb(string state, string county, Orb orb)
        {
            if (state != orb.State && county != orb.County)
            {
                return BadRequest();
            }

            _context.Entry(orb).State = EntityState.Modified;

            try
            {
                orb.LastUpdate = DateTime.UtcNow.ToShortDateString();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Orbs.Any(e => e.State == state && e.County == county))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
