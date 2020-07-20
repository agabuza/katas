using NUnit.Framework;
using System.Collections.Generic;

namespace katas.BalancedParetheses
{
    public class BalancedTests
    {
        [Test]
        public void TestExample()
        {
            var warriorsList = new List<string>();
            //test for n = 0
            warriorsList = Balanced.BalancedParens(0);
            Assert.AreEqual(new List<string> { "" }, warriorsList);
            //test for n = 1
            warriorsList = Balanced.BalancedParens(1);
            Assert.AreEqual(new List<string> { "()" }, warriorsList);
            //test for n = 2
            warriorsList = Balanced.BalancedParens(2);
            warriorsList.Sort();
            Assert.AreEqual(new List<string> { "(())", "()()" }, warriorsList);
            //test for n = 3
            warriorsList = Balanced.BalancedParens(3);
            warriorsList.Sort();
            Assert.AreEqual(new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" }, warriorsList);
            //test for n = 4
            warriorsList = Balanced.BalancedParens(4);
            warriorsList.Sort();
            Assert.AreEqual(new List<string> { "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()" }, warriorsList);
        }
    }
}
