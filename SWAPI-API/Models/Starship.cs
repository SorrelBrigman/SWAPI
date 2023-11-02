using System;
using StarWarsApiCSharp;
using System.Linq;

namespace SWAPI_API.Models
{

    public class Starship : StarWarsApiCSharp.Starship
	{
		IRepository<Starship> starshipRepo;

		public Starship()
		{
			this.starshipRepo = new Repository<Starship>();
        }

		public List<Starship> GetStarshipsByUrls(List<string> theseAreTheShipsYoureLookingFor)
		{
			// opting for single db call, rather than lots of small calls
			ICollection<Starship> allStarships = starshipRepo.GetEntities(1, int.MaxValue);

			List<Starship> filteredresults = allStarships.Where(s => theseAreTheShipsYoureLookingFor.Contains(s.Url)).ToList<Starship>();

			return filteredresults;

		}
	}
}

