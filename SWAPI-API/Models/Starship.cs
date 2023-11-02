using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{

    public class Starship : Vehicle
	{

        public Starship(SWAPIDevInteraction interaction)
		{
			this.interaction = interaction;
        }

		public List<Starship> GetStarshipsByUrls(List<string> theseAreTheShipsYoureLookingFor)
		{
            // opting for single db call, rather than lots of small calls
            StarWarsCategoryResults<Starship> allStarships = interaction.GetAllStarships();

			List<Starship> filteredresults = allStarships.results.Where(s => theseAreTheShipsYoureLookingFor.Contains(s.url)).ToList<Starship>();

			return filteredresults;

		}
	}
}

