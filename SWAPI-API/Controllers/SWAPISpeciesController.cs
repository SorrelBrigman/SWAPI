using Microsoft.AspNetCore.Mvc;
using SWAPI_API.Models;
using SWAPI_API.Utilities;

namespace SWAPI_API.Controllers
{
    [Route("api/SWAPI/species/film")]
    [ApiController]
    public class SWAPISpeciesController : ControllerBase
    {
        SWAPIDevInteraction interaction;

        Film filmInstance;
        Species speciesInstance;

        public SWAPISpeciesController()
		{
            SWAPIDevInteraction interaction = new SWAPIDevInteraction();

            this.filmInstance = new Film(interaction);
            this.speciesInstance = new Species(interaction);
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Species.SpeciesNameAndCategory>))]
        public ActionResult<IEnumerable<Species.SpeciesNameAndCategory>> GetEpisodeOnesSpecies()
        {

            return GetSpeciesNameClassificationsByFilm("The Phantom Menace");
        }

        [HttpGet("film_title")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Starship>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest )]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Species.SpeciesNameAndCategory>> GetSpeciesNameClassificationsByFilm(string filmTitle)
        {
            if (String.IsNullOrEmpty(filmTitle))
                return BadRequest();

            Film? filmObject = filmInstance.getFilmByTitle(filmTitle);

            if (filmObject == null)
            {
                return NotFound();
            }
            else
            {
                List<string> filmSpeciesUrls = filmObject.species;

                List<Species.SpeciesNameAndCategory> uniquespeciesClassification = speciesInstance.getSpeciesClassificationAndNameByFilm(filmSpeciesUrls);
                return Ok(uniquespeciesClassification);
            }
        }

    }
}

