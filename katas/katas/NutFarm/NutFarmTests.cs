using NUnit.Framework;

namespace katas.NutFarm
{
    [TestFixture]
    public class NutFarmTests
    {
        private static object[] Basic_Test_Cases = new object[]
        {
            new object[]
            {
              new string[]
              {
                " o o o  ",
                " /    / ",
                "   /    ",
                "  /  /  ",
                "   ||   ",
                "   ||   ",
                "   ||   "
              },
              new int[] {1,1,0,0,1,0,0,0},
              "Coconuts should bounce left",
            },
            new object[]
            {
              new string[]
              {
                " o o o  ",
                " \\    \\ ",
                "   \\    ",
                "  \\  \\  ",
                "   ||   ",
                "   ||   ",
                "   ||   ",
              },
              new int[] {0,0,0,1,1,0,1,0},
              "Coconuts should bounce right"
            },
            new object[]
            {
              new string[]
              {
                " o o o  ",
                " _      ",
                "   _ _  ",
                "   ||   ",
                "   ||   ",
                "   ||   ",
              },
              new int[] {0,0,0,0,0,0,0,0},
              "Coconuts should get stuck"
            },
        };

        [Test, TestCaseSource(typeof(NutFarmTests), "Basic_Test_Cases")]
        public void Basic_Test(string[] test, int[] expected, string warning)
        {
            int[] actual = NutFarm.ShakeTree(test);
            Assert.AreEqual(expected, actual, warning);
        }
    }
}
