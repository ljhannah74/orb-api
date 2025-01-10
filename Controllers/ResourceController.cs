using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using orb_api.Models;

namespace orb_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly OrbDatabaseContext _context;

        public ResourceController(OrbDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("states")]
        public ActionResult<IEnumerable<string>> GetStates()
        {
            return Ok(new string[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
        }

        [HttpGet("states/{state}/counties")]
        public ActionResult<IEnumerable<string>> GetCounties(string state)
        {
            var counties = _context.Orbs.Where(c => c.State == state).Select(c => c.County).ToList();

            return Ok(counties);
        }
    }
}
