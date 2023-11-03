using SWAPI_API.Utilities;

namespace SWAPI_API.Models
{

    public abstract class StarWarsCategory
	{
        protected ISWAPIDevInteraction interaction
        {
            get;
            set;
        }
    }
}

