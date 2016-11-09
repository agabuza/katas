using NUnit.Framework;

namespace katas.SumStrings
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("579", Kata.sumStrings("123", "456"));
            Assert.AreEqual("579579579579579579579579579579579579579579579", Kata.sumStrings("123123123123123123123123123123123123123123123", "456456456456456456456456456456456456456456456"));
        }
    }
}