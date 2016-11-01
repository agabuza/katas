using System;
using NUnit.Framework;
using Population;

[TestFixture]
public static class ArgeTests
{
    private static void testing(int actual, int expected)
    {
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void test1()
    {
        Console.WriteLine("Testing NbYear");
        testing(Arge.NbYear(1500, 5, 100, 5000), 15);
        testing(Arge.NbYear(1500000, 2.5, 10000, 2000000), 10);
        testing(Arge.NbYear(1500000, 0.25, 1000, 2000000), 94);
    }
}