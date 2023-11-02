using System;
using System.Xml.Linq;
using StarWarsApiCSharp;
using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
	public class Film : StarWarsApiCSharp.Film
	{
        IRepository<Film> filmRepo;

        public Film()
		{
			this.filmRepo = new Repository<Film>();
        }

		public Film? getFilmByTitle(string rawTitle)
		{
            string cleanTitle = Helper.CleanUpString(rawTitle);

            if (cleanTitle != string.Empty)
            {
                ICollection<Film> allFilms = this.filmRepo.GetEntities(1, int.MaxValue);

                List<Film> filmYoureLookingFor = allFilms.Where(p => p.Title.ToUpper() == cleanTitle).ToList<Film>();

                //In theory should not be more than one record, but just in case
                return filmYoureLookingFor.Count() > 0 ? filmYoureLookingFor[0] : null;
            }

            return null;
        }
	}
}

