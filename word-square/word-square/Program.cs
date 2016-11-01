using NUnit.Framework;
using System;
using System.Linq;

namespace word_square
{
    class Kata
    {
        public bool WordSquare(string letters)
        {
            var size = Math.Sqrt(letters.Length);
            if (size % 1 != 0) return false;

            var letterGroups = letters.ToArray().GroupBy(x => x)
                                      .ToLookup(x => x.Count() % 2 == 0); // paired == true

            if (letterGroups[false].Count() == size) return true;

            var diagLetters = letterGroups[false].Count();

            if ((size > diagLetters) 
                && ((size - diagLetters) % 2 == 0)) return true;

            return false;
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void BasicTest()
        {
            var kata = new Kata();
            Assert.AreEqual(true, kata.WordSquare("SATORAREPOTENETOPERAROTAS"));
            Assert.AreEqual(false, kata.WordSquare("NOTSQUARE"));
            Assert.AreEqual(true, kata.WordSquare("BITICETEN"));
            Assert.AreEqual(false, kata.WordSquare("CODEWARS"));
            Assert.AreEqual(true, kata.WordSquare("AAAAACEEELLRRRTT"));
            Assert.AreEqual(true, kata.WordSquare("AAACCEEEEHHHMMTT"));
            Assert.AreEqual(false, kata.WordSquare("AAACCEEEEHHHMMTTXXX"));
            Assert.AreEqual(false, kata.WordSquare("ABCD"));
            Assert.AreEqual(true, kata.WordSquare("GHBEAEFGCIIDFHGG"));
        }
    }
}
