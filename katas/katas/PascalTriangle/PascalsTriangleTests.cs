using System.Collections.Generic;
using NUnit.Framework;

namespace katas.PascalTriangle
{
    [TestFixture]
    public class PascalsTriangleTests
    {
        [Test]
        public static void Level1()
        {
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1, 1, 2, 1, 1, 3, 3, 1 }, Kata.PascalsTriangle(4));
            CollectionAssert.AreEqual(new List<int> { 1 }, Kata.PascalsTriangle(1));
        }
    }
}