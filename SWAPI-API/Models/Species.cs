using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
    public class Species : StarWarsCategory
    {

        public Species(SWAPIDevInteraction interaction)
        {
            this.interaction = interaction;
        }

        public List<string> vehicles
        {
            get;
            set;
        }


        public string homeworld
        {
            get;
            set;
        }

        public string eye_colors
        {
            get;
            set;
        }


        public string skin_colors
        {
            get;
            set;
        }


        public string url
        {
            get;
            set;
        }


        public string created
        {
            get;
            set;
        }


        public string edited
        {
            get;
            set;
        }


        public List<string> starships
        {
            get;
            set;
        }

        public List<string> films
        {
            get;
            set;
        }


        public List<string> people
        {
            get;
            set;
        }

        public string classification
        {
            get;
            set;
        }


        public string name
        {
            get;
            set;
        }


        public string designation
        {
            get;
            set;
        }


        public string average_height
        {
            get;
            set;
        }


        public string average_lifespane
        {
            get;
            set;
        }


        public string hair_colors
        {
            get;
            set;
        }


        public class SpeciesNameAndCategory
        {
            public string Name { get; set; }
            public string Classification { get; set; }

            public SpeciesNameAndCategory(string name, string classification)
            {
                this.Name = name;
                this.Classification = classification;
            }
        }

        public List<string> getSpeciesClassificationByFilm(List<string> speciesUrls)
        {
            List<Species> selectSpecies = this.getSpeciesByFilm(speciesUrls);

            List<string> uniqueListOfSpeciesCategory = selectSpecies.Select(s => s.classification).Distinct().ToList<string>();
            return uniqueListOfSpeciesCategory;


        }

        public List<SpeciesNameAndCategory> getSpeciesClassificationAndNameByFilm(List<string> speciesUrls)
        {
            List<Species> selectSpecies = this.getSpeciesByFilm(speciesUrls);

            List<SpeciesNameAndCategory> uniqueListOfSpeciesClassification = new List<SpeciesNameAndCategory>();
            selectSpecies.ForEach(s => uniqueListOfSpeciesClassification.Add(new SpeciesNameAndCategory(s.name, s.classification)));
            return uniqueListOfSpeciesClassification;
        }

        private List<Species> getSpeciesByFilm(List<string> speciesUrls)
        {
            // opting for single db call, rather than lots of small calls
            StarWarsCategoryResults<Species> allSpecies = interaction.GetAllSpecies();

            List<Species> filteredresults = allSpecies.results.Where(s => speciesUrls.Contains(s.url)).ToList<Species>();

            return filteredresults;

        }
    }
}
