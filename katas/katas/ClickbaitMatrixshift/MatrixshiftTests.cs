using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katas.ClickbaitMatrixshift
{
    public class MatrixshiftTests
    {
        private static string MapToString(char[][] map) => string.Concat(map.Select(x => new string(x)));

        [Test]
        public void Test0()
        {
            char[][] a = new char[][]
            {
                new []{'a','b','c','d'},
                new []{'1','2','3','4'},
                new []{'c','o','d','e'},
                new []{'b','l','a','h'}
            };

            char[][] b = new char[][]
            {
                new []{'h','a','b','c'},
                new []{'d','1','2','3'},
                new []{'4','c','o','d'},
                new []{'e','b','l','a'}
            };
            Assert.AreEqual(MapToString(b), MapToString(MatrixShift.Shift(a, 1)));
        }

        [Test]
        public void Test1()
        {
            char[][] a = new char[][] { new[] { 'b', 'o', 'o', 'b' } };
            char[][] b = new char[][] { new[] { 'o', 'b', 'b', 'o' } };
            Assert.AreEqual(MapToString(b), MapToString(MatrixShift.Shift(a, 2)));
        }

        [Test]
        public void Test2()
        {
            char[][] a = new char[][] { new[] { 'm', 'm', 'm' }, new[] { 'y', 'e', 'a' } };
            char[][] b = new char[][] { new[] { 'y', 'e', 'a' }, new[] { 'm', 'm', 'm' } };
            Assert.AreEqual(MapToString(b), MapToString(MatrixShift.Shift(a, 3)));
        }
    }
}
