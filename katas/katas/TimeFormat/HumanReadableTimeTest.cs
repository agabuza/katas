using NUnit.Framework;

namespace katas.TimeFormat
{
    [TestFixture]
    public class HumanReadableTimeTest
    {
        [Test]
        public void HumanReadableTest()
        {
            Assert.AreEqual(TimeFormat.GetReadableTime(0), "00:00:00");
            Assert.AreEqual(TimeFormat.GetReadableTime(5), "00:00:05");
            Assert.AreEqual(TimeFormat.GetReadableTime(60), "00:01:00");
            Assert.AreEqual(TimeFormat.GetReadableTime(86399), "23:59:59");
            Assert.AreEqual(TimeFormat.GetReadableTime(359999), "99:59:59");
        }
    }
}