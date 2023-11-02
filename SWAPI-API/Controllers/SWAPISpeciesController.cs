using System;
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
        public ActionResult<IEnumerable<Species.SpeciesNameAndCategory>> GetEpisodeOnesSpecies()
        {

            return GetSpeciesNameClassificationsByFilm("The Phantom Menace");
        }

        [HttpGet("film_title")]
        public ActionResult<IEnumerable<Species.SpeciesNameAndCategory>> GetSpeciesNameClassificationsByFilm(string filmTitle)
        {
            Film? filmObject = filmInstance.getFilmByTitle(filmTitle);
            if (filmObject == null)
            {
                return BadRequest();
            }
            else
            {
                List<string> filmSpeciesUrls = filmObject.species;

                List<Species.SpeciesNameAndCategory> uniquespeciesClassification = speciesInstance.getSpeciesClassificationAndNameByFilm(filmSpeciesUrls);
                return Ok(uniquespeciesClassification);
            }
        }


        //public List<string> GetSpeciesUniqueClassificationsByFilm(string filmTitle)
        //{
        //    Film? filmObject = filmInstance.getFilmByTitle(filmTitle);
        //    if (filmObject == null)
        //    {
        //        //return resource not found exception
        //    }

        //    List<string> filmSpeciesUrls = filmObject.species;

        //    List<string> uniquespeciesClassification = speciesInstance.getSpeciesClassificationByFilm(filmSpeciesUrls);
        //    return uniquespeciesClassification;
        //}
    }
}

