using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrbDataModels.BLL;
using OrbDataModels.DTOs;

namespace orb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbController : ControllerBase
    {
        private OrbBLL _orbBLL;
        string connectionString = "Server=localhost;Database=orb_db;User ID=lewisjhannah;Password=precious5;Port=3306;";


        public OrbController()
        {
            _orbBLL = new OrbBLL(connectionString);
        }
        [HttpGet]
        public ActionResult<List<StateDTO>> GetStates() 
        {
            return Ok(_orbBLL.GetAllStates());
        }

        [HttpGet]
        [Route("{StateID}")]
        public ActionResult<List<CountyDTO>> GetCountiesByState(int StateID)
        {
            return Ok(_orbBLL.GetCountiesByState(StateID));
        }

        [HttpGet]
        [Route("{StateID}/{CountyID}")]
        public ActionResult<OrbDTO> GetOrbByStateCounty(int StateID, int CountyID)
        {
            return Ok(_orbBLL.GetOrbsByStateCounty(StateID, CountyID));
        }

        [HttpPut]
        public ActionResult<bool> UpdateOrb(OrbDTO orbDTO)
        {
            return Ok(_orbBLL.UpdateOrb(orbDTO));
        }
    }
}
