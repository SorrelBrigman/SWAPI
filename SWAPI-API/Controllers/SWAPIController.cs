using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SWAPI_API.Models;
using SWAPI_API.Utilities;


namespace SWAPI_API.Controllers
{
    [Route("api/SWAPI")]
    [ApiController]
	public class SWAPIController : ControllerBase
	{
        Person? personInstance;
        Starship? starshipInstance;
        //Film? filmInstance;
        //Species? speciesInstance;

        HttpClient? DirectSWAPIClient;



        [HttpGet]
		public IEnumerable<Starship> GetLukesStarships()
		{
			SWAPIDevInteraction interaction = new SWAPIDevInteraction();

            Person personInstance = new Person(interaction);
            Starship starshipInstance = new Starship(interaction);
            //Film filmInstance = new Film();
            //Species speciesInstance = new Species();
            //Planet planetInstance = new Planet(DirectSWAPIClient);
            ;

            return GetLukeRelatedStarships(personInstance, starshipInstance);
        }

		

		//public List<Starship> GetRelatedStarshipByCharacterName(string name)
		//{
  //          List<string> starshipUrls = personInstance.getStarshipURLsByPersonName(name);

  //          List<Starship> namesStarships = starshipInstance.GetStarshipsByUrls(starshipUrls);

  //          return namesStarships;
  //      }


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

