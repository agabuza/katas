using NUnit.Framework;

namespace katas.FunWithTrees
{
    public class PerfectTreeTest
    {
        [Test]
        public void NullTreeShouldBePerfect()
        {
            TreeNode root = null;
            Assert.AreEqual(true, PerfectTree.IsPerfect(root), "null tree should be perfect");
        }

        /**
         *   0
         *  / \
         * 0   0
         * 
         */
        [Test]
        public void FullOneLevelTreeShouldBePerfect()
        {
            TreeNode root = TreeNode.Leaf().WithLeaves();
            Assert.AreEqual(true, PerfectTree.IsPerfect(root), "root with two leaves should be perfect");
        }

        /**
         *   0
         *  /
         * 0
         * 
         */
        [Test]
        public void OneChildTreeShouldNotBePerfect()
        {
            TreeNode root = TreeNode.Leaf().WithLeftLeaf();
            Assert.AreEqual(false, PerfectTree.IsPerfect(root), "root with single leaf should not be perfect");
        }
    }
}
