using NUnit.Framework;

namespace katas.RomanNumeralsDecoder
{
    [TestFixture]
    public class RomanDecodeTests
    {
        [TestCase(1, "I")]
        [TestCase(4, "IV")]
        [TestCase(29, "XXIX")]
        [TestCase(524, "DXXIV")]
        [TestCase(3011, "MMMIXII")]
        public void Test(int expected, string roman)
        {
            Assert.AreEqual(expected, RomanDecode.Solution(roman));
        }
    }
}
