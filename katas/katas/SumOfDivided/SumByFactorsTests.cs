using NUnit.Framework;

/// <summary>
/// https://www.codewars.com/kata/54d496788776e49e6b00052f
/// </summary>
namespace katas.SumOfDivided
{
    class SumByFactorsTests
    {
        [Test]
        public void Test12and15()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.AreEqual("(2 12)(3 27)(5 15)", SumByFactors.sumOfDivided(lst));
        }
    }
}
