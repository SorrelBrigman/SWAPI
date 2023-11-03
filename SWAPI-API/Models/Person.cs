using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{
	public class Person : StarWarsCategory
    {


        public Person(ISWAPIDevInteraction interaction)
        {
            this.interaction = interaction;
        }
         
            public List<string> vehicles
            {
                get;
                set;
            }

            public string gender
            {
                get;
                set;
            }

            public string url
            {
                get;
                set;
            }

            public string height
            {
                get;
                set;
            }

            public string hair_color
            {
                get;
                set;
            }

            public string skin_color
            {
                get;
                set;
            }


            public List<string> starships
            {
                get;
                set;
            }


            public string name
            {
                get;
                set;
            }


            public List<string> films
            {
                get;
                set;
            }


            public string birth_year
            {
                get;
                set;
            }

            public string homeworld
            {
                get;
                set;
            }


            public List<string> species
            {
                get;
                set;
            }

            public string eye_color
            {
                get;
                set;
            }


        public string mass
        {
            get;
            set;
        }


		public List<string> getStarshipURLsByPersonName(string name)
		{
            string? cleanName = Helper.CleanUpString(name);
			Person? personRecord = GetPersonByName(cleanName);
            return  personRecord != null ?  getStarshipsByPerson(personRecord) : new List<string>();
		}



		private Person? GetPersonByName(string cleanName)
        {

            if (cleanName != string.Empty)
            {
                
                StarWarsCategoryResults<Person> allPeople = interaction.GetAllPeople();

                List<Person> allPersons = allPeople.results;

                List<Person> personYoureLookingFor = allPersons.Where(p => p.name == cleanName).ToList<Person>();

				//In theory should not be more than one record, but just in case
                return personYoureLookingFor.Count() > 0 ? personYoureLookingFor[0] : null;
            }

            return null;
        }


        private List<string> getStarshipsByPerson(Person? personRecord)
        {

            if (personRecord != null)
            {
                return personRecord.starships;
            }

            return new List<string>();

        }

	}
}

