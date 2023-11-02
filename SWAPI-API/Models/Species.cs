//using System;

//namespace SWAPI_API.Models
//{
//	public class Species : StarWarsApiCSharp.Specie
//	{
//		IRepository<Species> speciesRepo;

//		public Species()
//		{
//			this.speciesRepo = new Repository<Species>();
//		}

//		public class SpeciesNameAndCategory
//		{
//			string Name { get; set; }
//			string Classification { get; set; }

//            public SpeciesNameAndCategory(string name, string classification)
//            {
//                this.Name = name;
//                this.Classification = classification;
//            }
//		}

//		public List<string> getSpeciesClassificationByFilm(List<string> speciesUrls)
//		{
//            List<Species> selectSpecies = this.getSpeciesByFilm(speciesUrls);

//            List<string> uniqueListOfSpeciesCategory = selectSpecies.Select(s => s.Classification).Distinct().ToList<string>();
//            return uniqueListOfSpeciesCategory;
            

//        }

//        public List<SpeciesNameAndCategory> getSpeciesClassificationAndNameByFilm(List<string> speciesUrls)
//        {
//            List<Species> selectSpecies = this.getSpeciesByFilm(speciesUrls);

//            List<SpeciesNameAndCategory> uniqueListOfSpeciesClassification = selectSpecies.Select(s => new SpeciesNameAndCategory(s.Name, s.Classification)).ToList<SpeciesNameAndCategory>();
//            return uniqueListOfSpeciesClassification;
//        }

//        private List<Species> getSpeciesByFilm(List<string> speciesUrls)
//        {
//            // opting for single db call, rather than lots of small calls
//            ICollection<Species> allSpecies = speciesRepo.GetEntities(1, int.MaxValue);

//            List<Species> filteredresults = allSpecies.Where(s => speciesUrls.Contains(s.Url)).ToList<Species>();

//            return filteredresults;

//        }
//    }
//}

