using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katas.ValidParentheses
{
        using NUnit.Framework;
  using System;

  [TestFixture]
    public class Tests
    {
        [Test]
        public void SampleTest1()
        {
            Assert.AreEqual(true, Kata.ValidParentheses("()"));
        }

        [Test]
        public void SampleTest2()
        {
            Assert.AreEqual(false, Kata.ValidParentheses(")(((("));
        }

        [Test]
        public void SampleTest3()
        {
            Assert.AreEqual(true, Kata.ValidParentheses("()()()"));
        }
    }
}