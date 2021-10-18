using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katas.ParseIntReload
{
    public class ParserTests
    {
        [Test]
        public void FixedTests()
        {
            Assert.AreEqual(1, Parser.ParseInt("one"));
            Assert.AreEqual(20, Parser.ParseInt("twenty"));
            Assert.AreEqual(246, Parser.ParseInt("two hundred forty-six"));
        }
    }
}
