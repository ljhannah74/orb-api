using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orb_api.DTOs;
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
            return 
                Ok(new string[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
        }

        [HttpGet("counties/{state}")]
        public async Task<ActionResult<IEnumerable<string>>> GetCounties(string state)
        {
            var counties = await _context.Orbs.Where(c => c.State == state).Select(c => c.County).ToListAsync();

            if (counties.Count == 0)
            {
                return NotFound();
            }
            return Ok(counties);
        }

        [HttpGet("resources/{state}/{county}")]
        public async  Task<ActionResult<OrbDTO>> GetResources(string state, string county)
        {
            if (string.IsNullOrEmpty(state) || string.IsNullOrEmpty(county))
                return BadRequest("State and County are required");

            var orb = await _context.Orbs
                .FirstOrDefaultAsync(o => o.State == state && o.County == county);

            if (orb == null)
            {
                return NotFound($"No resources found for {county} County, {state}");
            }

            var result = new OrbDTO
            {
                Id = orb.Id,
                State = orb.State,
                County = orb.County,
                Resources = new List<ResourceInfo>
            {
                    new ResourceInfo{ Type = "Land Records", Url = orb.LandUrl ?? string.Empty, User = orb.CountyUser ?? string.Empty, Password = orb.CountyPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Land Records (alt)", Url = orb.LandUrl2 ?? string.Empty, User = orb.LandUser2 ?? string.Empty, Password = orb.LandPwd2 ?? string.Empty },
                    new ResourceInfo{ Type = "Assessor", Url = orb.AssessorUrl ?? string.Empty, User = orb.AssessorUser ?? string.Empty, Password = orb.AssessorPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Tax Collector", Url = orb.TaxUrl ?? string.Empty, User = orb.TaxUser ?? string.Empty, Password = orb.TaxPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Tax Collector (alt)", Url = orb.Tax2Url ?? string.Empty, User = orb.Tax2User ?? string.Empty, Password = orb.Tax2Pwd ?? string.Empty },
                    new ResourceInfo{ Type = "Delinquent Taxes", Url = orb.DelinqTaxUrl ?? string.Empty, User = orb.Tax3User ?? string.Empty, Password = orb.Tax3Pwd ?? string.Empty },
                    new ResourceInfo{ Type = "Ucc", Url = orb.UccUrl ?? string.Empty, User = string.Empty, Password = string.Empty },
                    new ResourceInfo{ Type = "Municipal Court", Url = orb.MuniCourtUrl ?? string.Empty, User = orb.MuniUser ?? string.Empty, Password = orb.MuniPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Prothonotary", Url = orb.ProthonUrl ?? string.Empty, User = orb.ProUser ?? string.Empty, Password = orb.ProPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Sheriff", Url = orb.SheriffUrl ?? string.Empty, User = string.Empty, Password = string.Empty },
                    new ResourceInfo{ Type = "Court Records", Url = orb.CourtUrl ?? string.Empty, User = orb.CourtUser ?? string.Empty, Password = orb.CourtPwd ?? string.Empty },
                    new ResourceInfo{ Type = "Foreclosure", Url = orb.ForeclosureUrl ?? string.Empty, User = string.Empty, Password = string.Empty },
                    new ResourceInfo{ Type = "Probate Records", Url = orb.ProbateUrl ?? string.Empty, User = orb.ProbateUser ?? string.Empty, Password = orb.ProbatePwd ?? string.Empty },
                    new ResourceInfo{ Type = "Mapping Records", Url = orb.MapUrl ?? string.Empty, User = string.Empty, Password = string.Empty },
                    new ResourceInfo{ Type = "Plats", Url = orb.PlatUrl ?? string.Empty, User = string.Empty, Password = string.Empty },
                    new ResourceInfo{ Type = "Other", Url = orb.OtherUrl ?? string.Empty, User = orb.OtherUser ?? string.Empty, Password = orb.OtherPwd ?? string.Empty }
                }.Where(r => r.Url != string.Empty).ToList() // Exclude null URLs
            };

            return Ok(result);
        }
    }
}
