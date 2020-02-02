using NUnit.Framework;

namespace katas.FunWithTrees
{
    class ArrayToTreeTests
    {
        [Test]
        public void EmptyArray()
        {
            TreeNode expected = null;
            Assert.AreEqual(expected, ArrayToTreeKata.ArrayToTree(new int[] { }));
        }

        [Test]
        public void ArrayWithMultipleElements()
        {
            TreeNode expected = new TreeNode(17, new TreeNode(0, new TreeNode(3), new TreeNode(15)), new TreeNode(-4));
            Assert.AreEqual(expected, ArrayToTreeKata.ArrayToTree(new int[] { 17, 0, -4, 3, 15 }));
        }
    }
}
