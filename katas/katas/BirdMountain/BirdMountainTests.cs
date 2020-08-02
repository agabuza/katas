using NUnit.Framework;

namespace katas.BirdMountain
{
    public class BirdMountainTests
    {
        [Test]
        public void Ex()
        {
            char[][] mountain =
            {
                "^^^^^^        ".ToCharArray(),
                " ^^^^^^^^     ".ToCharArray(),
                "  ^^^^^^^     ".ToCharArray(),
                "  ^^^^^       ".ToCharArray(),
                "  ^^^^^^^^^^^ ".ToCharArray(),
                "  ^^^^^^      ".ToCharArray(),
                "  ^^^^        ".ToCharArray()
            };

            Assert.AreEqual(3, BirdMountain.PeakHeight(mountain));
        }
    }
}
