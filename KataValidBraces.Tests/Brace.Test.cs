using NUnit.Framework;

namespace KataValidBraces.Tests
{
    [TestFixture]
    public class KataTest
    {
        [TestCase("[]", true, TestName = "input is [], should return true")]
        [TestCase("{[]}", true, TestName = "input is {[]}, should return true")]
        [TestCase("{[()]}", true, TestName = "input is {[()]}, should return true")]
        [TestCase("{[([])]}", true, TestName = "input is {[([])]}, should return true")]
        public void validBraces_Input_Was_Valid_Square_Should_Return_True(string input, bool expected)
        {
            Assert.AreEqual(expected, Brace.validBraces(input));
        }
    }
}