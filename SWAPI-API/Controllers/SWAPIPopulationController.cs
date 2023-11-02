using Microsoft.AspNetCore.Mvc;
using SWAPI_API.Models;
using SWAPI_API.Utilities;

namespace SWAPI_API.Controllers
{

    [Route("api/SWAPI/population")]
    [ApiController]
    public class SWAPIPopulationController: ControllerBase
	{

        SWAPIDevInteraction interaction;

        Planet planetInstance;

        public SWAPIPopulationController()
		{
            this.interaction = new SWAPIDevInteraction();

            this.planetInstance = new Planet(interaction);

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Planet.PopulationResult>))]
        public ActionResult<IEnumerable<Planet.PopulationResult>> GetGalaxyPlanetPopulation()
        {
            Planet.PopulationResult populationResult = planetInstance.getTotalPopulationOfGalaxyLivingOnPlanets();
            return Ok(populationResult);
        }
    }
}

