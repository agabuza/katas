using NUnit.Framework;
using System;
namespace katas.ConwayLife
{
    public class ConwayLifeTests
    {
        [Test]
        public void GliderTest()
        {
            int[][,] gliders =
            {
              new int[,] {{1,0,0},{0,1,1},{1,1,0}},
              new int[,] {{0,1,0},{0,0,1},{1,1,1}}
            };

            Console.WriteLine("Glider");

            int[,] res = ConwayLife.GetGeneration(gliders[0], 1);
            CollectionAssert.AreEqual(gliders[1], res, "Output doesn't match expected");
        }

        [Test]
        public void Glider3GenTest()
        {
            int[][,] gliders =
            {
              new int[,]
              {
                  {1,0,0},
                  {0,1,1},
                  {1,1,0}
              },
              new int[,]
              {
                  {0,1,0},
                  {0,0,1},
                  {1,1,1}
              }
            };

            Console.WriteLine("Glider");

            int[,] res = ConwayLife.GetGeneration(gliders[1], 3);
            CollectionAssert.AreEqual(gliders[0], res, "Output doesn't match expected");
        }
    }
}
