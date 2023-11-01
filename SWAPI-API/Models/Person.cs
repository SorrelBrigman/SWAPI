﻿using System;
using System.Xml.Linq;
using StarWarsApiCSharp;

namespace SWAPI_API.Models
{
	public class Person : StarWarsApiCSharp.Person
	{
        IRepository<Person> personRepo = new Repository<Person>();

        public Person()
		{
		}


		public List<string> getStarshipURLsByPersonName(string name)
		{
			string cleanName = CleanUpName(name);
			Person personRecord = GetPersonByName(cleanName);
			return getStarshipsByPerson(personRecord);
		}


		private string? CleanUpName(string rawName)
		{
			string nameWithoutUnderscores = rawName.Replace("_", " ").Replace("-", " ");
            string cleanName = nameWithoutUnderscores.Trim().ToUpper();
			return cleanName;
        }


		private Person? GetPersonByName(string cleanName)
        {

            if (cleanName != string.Empty)
            {
                ICollection<Person> allPersons = personRepo.GetEntities(1, 20000);

                List<Person> personYoureLookingFor = allPersons.Where(p => p.Name.ToUpper() == cleanName).ToList<Person>();

				//In theory should not be more than one record, but just in case
                return personYoureLookingFor.Count() > 0 ? personYoureLookingFor[0] : null;
            }

            return null;
        }


        private List<string> getStarshipsByPerson(Person? personRecord)
		{

			if (personRecord != null)
			{
				return personRecord.Starships.ToList<string>();
			}

			return new List<string>();

		}

	}
}

