using NUnit.Framework;

namespace katas.StripComments
{
    public class StripCommentsTests
    {
        [Test]
        public void StripCommentsTest()
        {
            Assert.AreEqual(
                    "apples, pears\ngrapes\nbananas",
                    StripCommnetsKata.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
        }

        [Test]
        public void StripCommentsRandomTest()
        {
            Assert.AreEqual("a\nc\nd", StripCommnetsKata.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        }
    }
}
