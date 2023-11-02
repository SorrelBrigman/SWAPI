using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SWAPI_API.Models;
using SWAPI_API.Utilities;


namespace SWAPI_API.Controllers
{
	[Route("api/SWAPI/person/starships")]
	[ApiController]
	public class SWAPIPersonController : ControllerBase
	{

		SWAPIDevInteraction interaction;

		Person personInstance;
		Starship starshipInstance;

        public SWAPIPersonController()
        {
            this.interaction = new SWAPIDevInteraction();

            this.personInstance = new Person(interaction);
            this.starshipInstance = new Starship(interaction);
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Starship>))]
        public ActionResult<IEnumerable<Starship>> GetLukesStarships()
		{
			//SWAPIDevInteraction interaction = new SWAPIDevInteraction();

			//Person personInstance = new Person(interaction);
			//Starship starshipInstance = new Starship(interaction);
			////Film filmInstance = new Film();
			////Species speciesInstance = new Species();
			////Planet planetInstance = new Planet(DirectSWAPIClient);
			;


			return Ok(GetLukeRelatedStarships(this.personInstance, this.starshipInstance));
		}

		[HttpGet("character_name")]
		[ProducesResponseType(StatusCodes.Status200OK, Type =typeof(IEnumerable<Starship>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<Starship>> GetStarshipsByCharacter(string name)
		{
			SWAPIDevInteraction interaction = new SWAPIDevInteraction();

			Person personInstance = new Person(interaction);
			Starship starshipInstance = new Starship(interaction);

			IEnumerable<Starship> results = GetRelatedStarshipByCharacterName(name, personInstance, starshipInstance);

			if (results.Count() < 1)
			{
				return NotFound();
			}

            return Ok(results);
		}



		private List<Starship> GetRelatedStarshipByCharacterName(string name, Person personInstance, Starship starshipInstance)
		{
			List<string> starshipUrls = personInstance.getStarshipURLsByPersonName(name);
		

			List<Starship> namesStarships = starshipInstance.GetStarshipsByUrls(starshipUrls);

			return namesStarships;
		}


		private List<Starship> GetLukeRelatedStarships(Person personInstance, Starship starshipInstance)
        {
			
			List<string> starshipUrls = personInstance.getStarshipURLsByPersonName("Luke Skywalker");

			List<Starship> lukesStarships = starshipInstance.GetStarshipsByUrls(starshipUrls);

			return lukesStarships;
        }

		//public List<Species.SpeciesNameAndCategory> GetSpeciesNameClassificationsByFile(string filmTitle)
		//{
		//	Film filmObject = filmInstance.getFilmByTitle(filmTitle);
		//	if (filmObject == null)
		//	{
		//		//return resource not found exception
		//	}

		//	List<string> filmSpeciesUrls = filmObject.Species.ToList<string>();

		//	List<Species.SpeciesNameAndCategory> uniquespeciesClassification = speciesInstance.getSpeciesClassificationAndNameByFilm(filmSpeciesUrls);
		//	return uniquespeciesClassification;
		//}

  //      public List<string> GetSpeciesUniqueClassificationsByFile(string filmTitle)
  //      {
  //          Film filmObject = filmInstance.getFilmByTitle(filmTitle);
  //          if (filmObject == null)
  //          {
  //              //return resource not found exception
  //          }

  //          List<string> filmSpeciesUrls = filmObject.Species.ToList<string>();

  //          List<string> uniquespeciesClassification = speciesInstance.getSpeciesClassificationByFilm(filmSpeciesUrls);
		//	return uniquespeciesClassification;
		//}

    }
}

