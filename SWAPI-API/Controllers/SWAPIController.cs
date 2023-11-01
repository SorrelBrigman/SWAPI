using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SWAPI_API.Models;

namespace SWAPI_API.Controllers
{
	[ApiController]
	public class SWAPIController : ControllerBase
	{

		Person personInstance = new Person();
		Starship starshipInstance = new Starship();

		public List<Starship> GetRelatedStarshipByCharacterName()
		{
		}


		public List<Starship> GetLukeRelatedStarships()
        {
			
			List<string> starshipUrls = personInstance.getStarshipURLsByPersonName("Luke Skywalker");

			List<Starship> lukesStarships = starshipInstance.GetStarshipsByUrls(starshipUrls);

			return lukesStarships;
        }
		
	}
}

