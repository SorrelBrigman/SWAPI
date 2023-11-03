using SWAPI_API.Utilities;

namespace TestsSWAPI_API.TestsUtilities
{

    public class HelpersTests
    {
        [Fact]
        public void TestCleanUpStringRemovesTrailingSpaces()
        {
            string spaceFilledString = "So Many Trailing Spaces          ";
            string expectedString = "So Many Trailing Spaces";

            string cleanedUpString = Helper.CleanUpString(spaceFilledString);

            Assert.Equal(cleanedUpString, expectedString);
        }

        [Fact]
        public void TestCleanUpStringDoesNotRemoveInnerSpaces()
        {
            string spaceFilledString = "So            Many        Inner      Spaces";
            string expectedString = spaceFilledString;

            string cleanedUpString = Helper.CleanUpString(spaceFilledString);

            Assert.Equal(cleanedUpString, expectedString);
        }

        [Fact]
        public void TestTryGetDoubleReturnsValueOfDoubleInString()
        {

            Double myDouble = 123456;
            string myDoubleString = myDouble.ToString();

            Double parsedDoubleString = Helper.tryGetDouble(myDoubleString);

            Assert.Equal(myDouble, parsedDoubleString);
        }


        [Fact]
        public void TestTryGetDoubleReturnsValueOfDoubleInStringIfZero()
        {

            Double myDouble = 0;
            string myDoubleString = myDouble.ToString();

            Double parsedDoubleString = Helper.tryGetDouble(myDoubleString);

            Assert.Equal(myDouble, parsedDoubleString);
        }

        [Fact]
        public void TestTryGetDoubleReturnsZeroIfNotParsable()
        {

            Double expectedResult = 0;
            string myDoubleString = "this string is not a double at all";

            Double parsedDoubleString = Helper.tryGetDouble(myDoubleString);

            Assert.Equal(expectedResult, parsedDoubleString);
        }
    }
}

