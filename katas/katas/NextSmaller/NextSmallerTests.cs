using NUnit.Framework;

namespace katas.NextSmaller
{
    public class NextSmallerTests
    {
        [TestCase(21, ExpectedResult = 12)]
        [TestCase(907, ExpectedResult = 790)]
        [TestCase(531, ExpectedResult = 513)]
        [TestCase(1027, ExpectedResult = -1)]
        [TestCase(1207, ExpectedResult = 1072)]
        [TestCase(441, ExpectedResult = 414)]
        [TestCase(29009, ExpectedResult = 20990)]
        [TestCase(123456798, ExpectedResult = 123456789)]
        public long FixedTests(long n)
        {
            return NextSmallerKata.NextSmaller(n);
        }
    }
}
