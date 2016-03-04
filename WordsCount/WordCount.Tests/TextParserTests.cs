using NUnit.Framework;
using System;
using System.Linq;
using WordsCount.Core;

namespace WordsCount.Tests
{
    [TestFixture]
    public class TextParserTests
    {
        [Test]
        public void Whether_TextParser_ThrowsException_On_GetOccurrenceNull()
        {
            var parser = new TextParser();
            Assert.Throws(typeof(ArgumentException), () => parser.GetOccurrence(null));
        }

        [Test]
        public void Whether_TextParser_ThrowsException_On_GetWordsNull()
        {
            var parser = new TextParser();
            Assert.Throws(typeof(ArgumentException), () => parser.GetWords(null));
        }

        [Test]
        public void Whether_TextParser_ReturnsEmpty_On_GetOccurrenceEmpty()
        {
            var parser = new TextParser();

            var result = parser.GetOccurrence(string.Empty);

            Assert.That(result != null);
            Assert.That(result.Count == 0);
        }

        [TestCase("Hello ello, llo lo o.", 5)]
        [TestCase("Hello hello, ello; llo lo o.", 6)]
        [TestCase("..!;,", 0)]
        [TestCase("one..two!; ", 2)]
        public void Whether_TextParser_ReturnsCorrectNumberOfWords_On_GetWords(string text, int expecedNumberOfwords)
        {
            var parser = new TextParser();

            var result = parser.GetWords(text);

            Assert.That(result.Count() == expecedNumberOfwords);
        }

        [TestCase("This is a statement, and so is this.", "this", 2)]
        [TestCase("holo lolo lo holo.", "lo", 1)]
        [TestCase("Random words, to; calculate random randomness; of radnomizer.", "random", 2)]
        public void Whether_TextParser_CalculatesNumberOfMatches_On_GetOccurrence(string text, string word, int numberOfOccur)
        {
            var parser = new TextParser();

            var result = parser.GetOccurrence(text);

            Assert.That(result[word] == numberOfOccur);
        }
    }
}
