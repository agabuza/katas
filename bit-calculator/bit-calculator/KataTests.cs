using NUnit.Framework;

namespace bit_calculator
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(2, Kata.Calculate("1", "1"));
            Assert.AreEqual(4, Kata.Calculate("10", "10"));
            Assert.AreEqual(2, Kata.Calculate("10", "0"));
            Assert.AreEqual(3, Kata.Calculate("10", "1"));
        }
    }
}
