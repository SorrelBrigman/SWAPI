namespace SWAPI_API.Utilities
{
    public static class Helper
    {
        public static string? CleanUpString(string rawString)
        {
            string stringWithoutUnderscores = rawString.Replace("_", " ").Replace("-", " ");
            string cleanString = stringWithoutUnderscores.Trim();
            return cleanString;
        }

        public static double tryGetDouble(this string item)
        {
            double i;
            bool success = double.TryParse(item, out i);
            return success ? i : 0;
        }

    }
}

