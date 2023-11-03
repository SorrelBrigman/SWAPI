using System;
using Newtonsoft.Json;
using SWAPI_API.Models;

namespace SWAPI_API.Utilities
{
	public interface ISWAPIDevInteraction
	{
        //T GetSingleByUrl<T>(string url) where T : StarWarsCategory;


        Person GetPerson(string id);

        Person GetPersonByName(string name);

        StarWarsCategoryResults<Person> GetAllPeople();


        Film GetFilm(string id);


        StarWarsCategoryResults<Film> GetAllFilms();


        Planet GetPlanet(string id);


        StarWarsCategoryResults<Planet> GetAllPlanets();


        Species GetSpecie(string id);


        StarWarsCategoryResults<Species> GetAllSpecies();


        Starship GetStarship(string id);


        StarWarsCategoryResults<Starship> GetAllStarships();
    }


}

