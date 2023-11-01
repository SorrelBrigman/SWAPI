using System;
using StarWarsApiCSharp;
using System.Linq;

namespace SWAPI_API.Models
{

    public class Starship : StarWarsApiCSharp.Starship
	{
        IRepository<Starship> starshipRepo = new Repository<Starship>();

		public Starship()
		{
		}

		public List<Starship> GetStarshipsByUrls(List<string> theseAreTheShipsYoureLookingFor)
		{
			//opting to return up to 1000 starships, expecting that will include all records
			// opting for single db call, rather than lots of small calls
			ICollection<Starship> allStarships = starshipRepo.GetEntities(1, 1000);

			List<Starship> filteredresults = allStarships.Where(s => theseAreTheShipsYoureLookingFor.Contains(s.Url)).ToList<Starship>();

			return filteredresults;

		}
	}
}

