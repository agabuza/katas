using NUnit.Framework;
using System;

namespace katas.EulersODE
{
    [TestFixture]
    public static class EulerOdeTests
    {
        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing ExEuler");
            Assert.AreEqual(0.5, EulerOde.ExEuler(1));
            Assert.AreEqual(0.026314, EulerOde.ExEuler(10));
            Assert.AreEqual(0.015193, EulerOde.ExEuler(17));
            Assert.AreEqual(0.005073, EulerOde.ExEuler(50));
            Assert.AreEqual(0.002524, EulerOde.ExEuler(100));
        }
    }
}
