using NUnit.Framework;

namespace katas.BirdMountain
{
    public class BirdMountainRiverTests
    {
        [Test]
        public void Ex()
        {
            char[][] terrain =
            {
                "  ^^^^^^             ".ToCharArray(),
                "^^^^^^^^       ^^^   ".ToCharArray(),
                "^^^^^^^  ^^^         ".ToCharArray(),
                "^^^^^^^  ^^^         ".ToCharArray(),
                "^^^^^^^  ^^^         ".ToCharArray(),
                "---------------------".ToCharArray(),
                "^^^^^                ".ToCharArray(),
                "   ^^^^^^^^  ^^^^^^^ ".ToCharArray(),
                "^^^^^^^^     ^     ^ ".ToCharArray(),
                "^^^^^        ^^^^^^^ ".ToCharArray()
            };

            Assert.AreEqual(new int[] { 189, 99, 19, 3 }, BirdMountainRiver.DryGround(terrain));
        }

        [Test]
        public void DesertTest()
        {
            char[][] terrain =
             {
            "          ".ToCharArray(),
            "          ".ToCharArray(),
            "          ".ToCharArray(),
            "          ".ToCharArray(),
            "          ".ToCharArray(),
            "          ".ToCharArray()
            };

            Assert.AreEqual(new int[] { 60, 60, 60, 60 }, BirdMountainRiver.DryGround(terrain));
        }

        [Test]
        public void FlashFlood()
        {
            char[][] terrain =
            {
                "^^^^^^^^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
                "----------------------------".ToCharArray(),
                "^^^^^^^^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
                "^^^^ ^^^^^^^^ ^^^^^^^^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^ ^^  ^  ^  ^  ^  ^^ ^^^^".ToCharArray(),
                "^^^^^^^^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
                "^^^^^^^^^^^^^^^^^^^^^^^^^^^^".ToCharArray()
            };
            Assert.AreEqual(new int[] { 420, 420, 63, 0 }, BirdMountainRiver.DryGround(terrain));

        }
    }
}
