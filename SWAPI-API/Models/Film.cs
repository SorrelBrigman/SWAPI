using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
    public class Film : StarWarsCategory
    {

        public Film(SWAPIDevInteraction interaction)
        {
            this.interaction = interaction;

        }

        public short episode_id
        {
            get;
            set;
        }

        public List<string> vehicles
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }

        public List<string> starships
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }

        public List<string> species
        {
            get;
            set;
        }

        public string producer
        {
            get;
            set;
        }

        public List<string> planets
        {
            get;
            set;
        }

        public string director
        {
            get;
            set;
        }

        public List<string> characters
        {
            get;
            set;
        }

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

