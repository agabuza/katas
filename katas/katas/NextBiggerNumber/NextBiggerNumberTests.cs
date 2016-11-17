using System;
using NUnit.Framework;

namespace katas.NextBiggerNumber
{
    [TestFixture]
    public class NextBiggerNumberTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Small Number");
            Assert.AreEqual(1234567908, Kata.NextBiggerNumber(1234567890));
            Assert.AreEqual(169191738, Kata.NextBiggerNumber(169191387));
            Assert.AreEqual(59884848483559, Kata.NextBiggerNumber(59884848459853));

            Assert.AreEqual(21, Kata.NextBiggerNumber(12));
            Assert.AreEqual(531, Kata.NextBiggerNumber(513));
            Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
            Assert.AreEqual(441, Kata.NextBiggerNumber(414));
            Assert.AreEqual(414, Kata.NextBiggerNumber(144));

        }
    }
}