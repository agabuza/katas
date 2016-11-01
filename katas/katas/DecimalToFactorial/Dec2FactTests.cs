using NUnit.Framework;

namespace katas.DecimalToFactorial
{
    [TestFixture]
    public class Dec2FactTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("341010", Dec2Fact.dec2FactString(463));
            Assert.AreEqual(463, Dec2Fact.factString2Dec("341010"));
        }
    }
}