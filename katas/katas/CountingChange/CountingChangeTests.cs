using NUnit.Framework;

namespace katas.CountingChange
{
    class CountingChangeTests
    {
        [Test]
        public static void SimpleCase()
        {
            Assert.AreEqual(3, Kata.CountCombinations(4, new[] { 1, 2 }));
        }

        [Test]
        public static void AnotherSimpleCase()
        {
            Assert.AreEqual(4, Kata.CountCombinations(10, new[] { 5, 2, 3 }));
        }

        [Test]
        public static void NoChange()
        {
            Assert.AreEqual(0, Kata.CountCombinations(11, new[] { 5, 7 }));
        }
    }
}
