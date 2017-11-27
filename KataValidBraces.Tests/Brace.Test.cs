using NUnit.Framework;

namespace KataValidBraces.Tests
{
    [TestFixture]
    public class KataTest
    {
        [TestCase("[]", TestName = "input is [], should return true")]
        [TestCase("{[]}", TestName = "input is {[]}, should return true")]
        [TestCase("{[()]}", TestName = "input is {[()]}, should return true")]
        [TestCase("{[([])]}", TestName = "input is {[([])]}, should return true")]
        [TestCase("(({{[[]]}}))", TestName = "input is (({{[[]]}})), should return true")]
        [TestCase("{}({})[]", TestName = "input is {}({})[], should return true")]
        public void validBraces_Input_Was_Valid_Should_Return_True(string input)
        {
            Assert.AreEqual(true, Brace.validBraces(input));
        }

        [TestCase("{]", TestName = "input is {], should return false")]
        [TestCase("[{]", TestName = "input is {], should return false")]
        [TestCase("[{]}", TestName = "input is [{]}, should return false")]
        [TestCase(")(}{][", TestName = "input is )(}{][, should return false")]
        [TestCase("())({}}{()][][", TestName = "input is ())({}}{()][][, should return false")]
        public void validBraces_Input_Was_Invalid_Should_Return_False(string input)
        {
            Assert.AreEqual(false, Brace.validBraces(input));
        }
    }
}