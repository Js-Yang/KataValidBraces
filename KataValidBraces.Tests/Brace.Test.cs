using NUnit.Framework;

namespace KataValidBraces.Tests
{
    [TestFixture]
    public class KataTest
    {
        [Test]
        public void validBraces_Input_Was_Valid_Square_Should_Return_True()
        {
            var input = "[]";
            var result = Brace.validBraces(input);

            var expected = true;

            Assert.AreEqual(expected, result);
        }
    }
}