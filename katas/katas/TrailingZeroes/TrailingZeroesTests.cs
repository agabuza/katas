using NUnit.Framework;

namespace katas.TrailingZeroes
{
    [TestFixture]
    public class TrailingZeroesTests
    {
        [Test]
        public void FactorialTrailingZeroesTest()
        {
            Assert.That(TrailingZeroes.GetTrailingFactorialZeroes(1), Is.EqualTo(0));
            Assert.That(TrailingZeroes.GetTrailingFactorialZeroes(12), Is.EqualTo(2));
            Assert.That(TrailingZeroes.GetTrailingFactorialZeroes(25), Is.EqualTo(6));
            Assert.That(TrailingZeroes.GetTrailingFactorialZeroes(531), Is.EqualTo(131));
            Assert.That(TrailingZeroes.GetTrailingFactorialZeroes(2000), Is.EqualTo(499));
        }
    }
}
