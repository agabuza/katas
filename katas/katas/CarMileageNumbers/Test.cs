using System.Collections.Generic;
using NUnit.Framework;

namespace katas.CarMileageNumbers
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void IsPlaindromeTest()
        {
            Assert.That(Kata.IsPalindrome("1234321"), Is.True);
            Assert.That(Kata.IsPalindrome("1221"), Is.True);
            Assert.That(Kata.IsPalindrome("12212"), Is.False);
        }

        [Test]
        public void ShouldWorkTest()
        {
            Assert.AreEqual(2, Kata.IsInteresting(3210, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, Kata.IsInteresting(109, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, Kata.IsInteresting(3, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, Kata.IsInteresting(98, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, Kata.IsInteresting(1336, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, Kata.IsInteresting(1234, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, Kata.IsInteresting(1337, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, Kata.IsInteresting(11208, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, Kata.IsInteresting(11209, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, Kata.IsInteresting(11211, new List<int>() { 1337, 256 }));
        }
    }
}