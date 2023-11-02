using System;
namespace SWAPI_API.Utilities
{
	static class Helper
	{
		public static string? CleanUpString(string rawString)
        {
            string stringWithoutUnderscores = rawString.Replace("_", " ").Replace("-", " ");
            string cleanString = stringWithoutUnderscores.Trim().ToUpper();
            return cleanString;
        }

    }
}

