using NUnit.Framework;

namespace katas.MorseCode
{
    public class MorseCodeDecoderTest
    {
        [Test]
        public void TestExampleFromDescriptionTest()
        {
            Assert.AreEqual("HEY JUDE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
        }
        
        [Test]
        public void MultipleBitsPerDotTest()
        {
            Assert.AreEqual("HEY", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111100001111000011110000111100000000000011110000000000001111111111110000111100001111111111110000111111111111")));
        }

        [Test]
        public void SingleDotTest()
        {
            Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1")));
        }

        [Test]
        public void SingleLongDotTest()
        {
            Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111")));
        }

        [Test]
        public void EETest()
        {
            Assert.AreEqual("EE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("10001")));
        }
    }
}
