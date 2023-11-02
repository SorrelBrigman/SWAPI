using System;
namespace SWAPI_API.Models
{
	public class StarWarsCategoryResults<T> : StarWarsCategory where T : StarWarsCategory
    {
		public StarWarsCategoryResults()
		{
		}

        public string previous
        {
            get;
            set;
        }

        public string next
        {
            get;
            set;
        }

        public string previousPageNo
        {
            get;
            set;
        }

        public string nextPageNo
        {
            get;
            set;
        }

        public Int64 count
        {
            get;
            set;
        }

        public List<T> results
        {
            get;
            set;
        }
    }
}

