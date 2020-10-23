using NUnit.Framework;

namespace katas.ProperFractions
{
    class ProperFractionsSolutionTests
    {
        [Test]
        public void SmallerNumbers()
        {
            Assert.AreEqual(0, ProperFractionsSolution.ProperFractions(1));
            Assert.AreEqual(1, ProperFractionsSolution.ProperFractions(2));
            Assert.AreEqual(4, ProperFractionsSolution.ProperFractions(5));
            Assert.AreEqual(8, ProperFractionsSolution.ProperFractions(15));
            Assert.AreEqual(20, ProperFractionsSolution.ProperFractions(25));
        }
    }
}
