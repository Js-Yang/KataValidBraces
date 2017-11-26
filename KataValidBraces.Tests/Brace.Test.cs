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
        public void validBraces_Input_Was_Valid_Should_Return_True(string input, bool expected)
        {
            Assert.AreEqual(expected, Brace.validBraces(input));
        }

        [TestCase("{]", false, TestName = "input is {], should return false")]
        [TestCase("[{]", false, TestName = "input is {], should return false")]
        public void validBraces_Input_Was_Invalid_Should_Return_False(string input, bool expected)
        {
            Assert.AreEqual(expected, Brace.validBraces(input));
        }
    }
}