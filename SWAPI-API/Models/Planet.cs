using System;
using StarWarsApiCSharp;

namespace SWAPI_API.Models
{
	public class Planet : StarWarsApiCSharp.Planet
	{
        IRepository<Planet> planetRepo;
        int population;
        HttpClient swapiClient;

        public Planet(HttpClient swapiClient)
		{
			this.planetRepo = new Repository<Planet>();
            this.swapiClient = swapiClient;
		}

        public int getTotalPopulationOfGalaxyLivingOnPlanets(List<Planet> allGalaxysPlanets)
        {

            List<int> planetPopulationList = allGalaxysPlanets.Select(p => p.population).ToList<int>();
            return planetPopulationList.Sum();
        }

        //private List<Planet> getAllPlanets()
        //{
        //    ICollection<Planet> allPlanets = swapiClient.GetAsync<Planet>("planet/"); //look into this, not fully fleshed out

        //    return allPlanets.ToList<Planet>();
        //}
    }



}

