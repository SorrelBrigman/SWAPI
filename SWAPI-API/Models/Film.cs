using System;
using System.Xml.Linq;
using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
    public class Film : StarWarsCategory
    {

        public Film(Utilities.SWAPIDevInteraction interaction)
        {
            this.interaction = interaction;

        }

        /// <summary>
        /// The episode number of this film.
        /// </summary>
        public short episode_id
        {
            get;
            set;
        }

        /// <summary>
        /// The vehicle resources featured within this film.
        /// </summary>
        public List<string> vehicles
        {
            get;
            set;
        }

        /// <summary>
        /// The url of this resource
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// An array of starship resources that this person has piloted
        /// </summary>
        public List<string> starships
        {
            get;
            set;
        }

        /// <summary>
        /// The title of this film.
        /// </summary>
        public string title
        {
            get;
            set;
        }

        /// <summary>
        /// The url of the species resource that this person is.
        /// </summary>
        public List<string> species
        {
            get;
            set;
        }

        /// <summary>
        /// The producer(s) of this film.
        /// </summary>
        public string producer
        {
            get;
            set;
        }

        /// <summary>
        /// The planet resources featured within this film.
        /// </summary>
        public List<string> planets
        {
            get;
            set;
        }

        /// <summary>
        /// The director of this film.
        /// </summary>
        public string director
        {
            get;
            set;
        }

        /// <summary>
        /// The people resources featured within this film.
        /// </summary>
        public List<string> characters
        {
            get;
            set;
        }

        /// <summary>
        /// The opening crawl text at the beginning of this film.
        /// </summary>
        public string opening_crawl
        {
            get;
            set;
        }

        public Film? getFilmByTitle(string rawTitle)
        {
            string cleanTitle = Helper.CleanUpString(rawTitle);

            if (cleanTitle != string.Empty)
            {
                StarWarsCategoryResults<Film> allFilms = interaction.GetAllFilms();

                List<Film> filmYoureLookingFor = allFilms.results.Where(p => p.title == cleanTitle).ToList<Film>();

                //In theory should not be more than one record, but just in case
                return filmYoureLookingFor.Count() > 0 ? filmYoureLookingFor[0] : null;
            }

            return null;
        }
    }
}

