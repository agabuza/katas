using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katas.DisiriumNumbers
{
    using NUnit.Framework;
    [TestFixture]
    class Tests
    {
        [TestCase(89, "Disarium !!")]
        [TestCase(564, "Not !!")]
        [TestCase(1024, "Not !!")]
        [TestCase(135, "Disarium !!")]
        [TestCase(136586, "Not !!")]
        public void BasicTests(int number, string expected)
        {
            Assert.That(Kata.DisariumNumber(number), Is.EqualTo(expected));
        }
    }
}
