using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace katas.ConnectFour
{
    [TestFixture]
    public class MyTestConnectFour
    {
        [Test]
        public void FirstTest()
        {
            List<string> myList = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Yellow", ConnectFour.WhoIsWinner(myList), "it should return Yellow");
        }

        [Test]
        public void SecondTest()
        {
            List<string> myList = new List<string>()
            {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            };

            StringAssert.AreEqualIgnoringCase("Yellow", ConnectFour.WhoIsWinner(myList));
        }

        [Test]
        public void ThirdTest()
        {
            List<string> myList = new List<string>()
            {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Red", ConnectFour.WhoIsWinner(myList), "it should return Red");
        }

        [Test]
        public void FourthTest()
        {
            var input = "F_Yellow,G_Red,D_Yellow,C_Red,A_Yellow,A_Red,E_Yellow,D_Red,D_Yellow,F_Red,B_Yellow,E_Red,C_Yellow,D_Red,F_Yellow,D_Red,D_Yellow,F_Red,G_Yellow,C_Red,F_Yellow,E_Red,A_Yellow,A_Red,C_Yellow,B_Red,E_Yellow,C_Red,E_Yellow,G_Red,A_Yellow,A_Red,G_Yellow,C_Red,B_Yellow,E_Red,F_Yellow,G_Red,G_Yellow,B_Red,B_Yellow,B_Red".Split(',').ToList();
            StringAssert.AreEqualIgnoringCase("Red", ConnectFour.WhoIsWinner(input), "it should return Red");
        }
    }
}