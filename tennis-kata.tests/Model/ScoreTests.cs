using NUnit.Framework;
using tennis_kata.core.Model;

namespace tennis_kata.tests.Model
{
    [TestFixture]
    public class ScoreTests
    {
        [Test]
        public void Whether_Score_FormatsCorrectString_On_ToString()
        {
            var score = new Score(Points._15, Points._A);

            var scoreStr = score.ToString();

            Assert.That(scoreStr == "15:A");
        }
    }
}
