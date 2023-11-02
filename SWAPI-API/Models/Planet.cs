using System;
using System.Linq;
using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
    public class Planet : StarWarsCategory
    {

        public Planet(Utilities.SWAPIDevInteraction interaction)
        {
            this.interaction = interaction;
        }

        public List<string> residents
        {
            get;
            set;
        }

        public List<string> films
        {
            get;
            set;
        }


        public string rotation_period
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }

        public string gravity
        {
            get;
            set;
        }

        public string terrain
        {
            get;
            set;
        }


        public string climate
        {
            get;
            set;
        }


        public string diameter
        {
            get;
            set;
        }


        public string created
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string surface_water
        {
            get;
            set;
        }


        public string population
        {
            get;
            set;
        }

        public string orbital_period
        {
            get;
            set;
        }

        public string edited
        {
            get;
            set;
        }

        public class PopulationResult
        {
            public double population { get; set; }

            public PopulationResult(double population)
            {
                this.population = population;
            }
        }


        public PopulationResult getTotalPopulationOfGalaxyLivingOnPlanets()
        {
            List<Planet> allPlanets = getAllPlanets();
            return sumUpAllPlanetsPopulation(allPlanets);


        }

        private List<Planet> getAllPlanets()
        {
            StarWarsCategoryResults<Planet> allPlanets = interaction.GetAllPlanets();

            return allPlanets.results;
        }

        //private PopulationResult sumUpAllPlanetsPopulation(List<Planet> allGalaxysPlanets)
        //{
        //    int a;
        //    List<Planet> planets = allGalaxysPlanets.Count > 0 ? allGalaxysPlanets: new List<Planet>();

        //    List<int> planetPopulationList = new List<int>();
        //    List<Planet> planetsWithValidPopulations = allGalaxysPlanets.Select<Planet>(ForEach(action: p => planetPopulationList.Add(TryGetInt(p.population)));
        //    //planetPopulationList = planets.Where(p => Int32.TryParse(p.population, out a));
        //    //planetsWithValidPopulations.ForEach(p => planetPopulationList.Add(Int32.Parse(p.population)));
        //    return new PopulationResult(planetPopulationList.Sum());

        //}


        private PopulationResult sumUpAllPlanetsPopulation(List<Planet> allGalaxysPlanets)
        {
            List<double> planetPopulationList = new List<double>();
            foreach (Planet planet in allGalaxysPlanets)
            {
                planetPopulationList.Add(Helper.tryGetDouble(planet.population));
            }

            return new PopulationResult(planetPopulationList.Sum());

        }
    }

}

