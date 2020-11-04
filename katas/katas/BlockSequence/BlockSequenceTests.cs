using NUnit.Framework;

namespace katas.BlockSequence
{
    class BlockSequenceTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(1, BlockSequence.solve(1));
            Assert.AreEqual(1, BlockSequence.solve(2));
            Assert.AreEqual(2, BlockSequence.solve(3));
            Assert.AreEqual(1, BlockSequence.solve(4));
            Assert.AreEqual(2, BlockSequence.solve(5));
            Assert.AreEqual(4, BlockSequence.solve(10));
            Assert.AreEqual(1, BlockSequence.solve(100));
            Assert.AreEqual(2, BlockSequence.solve(2100));
            Assert.AreEqual(2, BlockSequence.solve(3100));
            Assert.AreEqual(1, BlockSequence.solve(55));
            Assert.AreEqual(6, BlockSequence.solve(123456));
            Assert.AreEqual(3, BlockSequence.solve(123456789));
        }

        [Test]
        public void PerformanceTests()
        {
            Assert.AreEqual(1, BlockSequence.solve(1000000000000000000));
            Assert.AreEqual(7, BlockSequence.solve(999999999999999993));
        }
    }
}
