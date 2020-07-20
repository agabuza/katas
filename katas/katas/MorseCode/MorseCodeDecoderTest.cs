﻿using NUnit.Framework;

namespace katas.MorseCode
{
    public class MorseCodeDecoderTest
    {
        [Test]
        public void TestExampleFromDescription()
        {
            Assert.AreEqual("HEY JUDE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
        }
    }
}
