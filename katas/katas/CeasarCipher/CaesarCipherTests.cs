using System.Collections.Generic;
using NUnit.Framework;

namespace katas.CeasarCipher
{
    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        public void Test1()
        {
            string u = "I should have known that you would have a perfect answer for me!!!";
            var caesarCode = new List<string>
            {
                "J vltasl rlhr",
                "zdfog odxr ypw",
                "atasl rlhr p",
                "gwkzzyq zntyhv",
                "lvz wp!!!"
            };
            Assert.AreEqual(caesarCode, CaesarCipher.movingShift(u,1));
            Assert.AreEqual(u, CaesarCipher.demovingShift(caesarCode, 1));
            Assert.AreEqual(u, CaesarCipher.demovingShift(CaesarCipher.movingShift(u, 1), 1));
        }

        [Test]
        public void DecryptionTest()
        {
            var str = "... tread, Walk the deck my Captain lies, Fallen cold and dead. ";

        }        
    }
}
