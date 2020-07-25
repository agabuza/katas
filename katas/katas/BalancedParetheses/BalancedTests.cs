using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace katas.BalancedParetheses
{
    public class BalancedTests
    {
        [TestCase(0, "")]
        [TestCase(1, "()")]
        [TestCase(2, "(()),()()")]
        [TestCase(3, "((())),(()()),(())(),()(()),()()()")]
        [TestCase(4, "(((()))),((()())),((())()),((()))(),(()(())),(()()()),(()())(),(())(()),(())()(),()((())),()(()()),()(())(),()()(()),()()()()")]
        public void TestExample(int numberOfPairs, string expectedResult)
        {
            var result = new List<string>();
            result = Balanced.BalancedParens(numberOfPairs);
            Assert.AreEqual(expectedResult, string.Join(",", result));
        }
    }
}
