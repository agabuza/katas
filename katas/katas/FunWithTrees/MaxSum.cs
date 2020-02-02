using System;

namespace katas.FunWithTrees
{
    public static class MaxSumKata
    {
        internal static int MaxSum(TreeNode root)
        {
            if (root == null) return 0;

            var leftSum = MaxSum(root.left);
            var rightSum = MaxSum(root.right);

            return leftSum > rightSum ? root.value + leftSum : root.value + rightSum;
        }
    }

    internal class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }

        public TreeNode(int value, TreeNode left, TreeNode right) 
            : this(value)
        {
            this.left = left;
            this.right = right;
        }

        internal static TreeNode Leaf(int value)
        {
            return new TreeNode(value);
        }

        internal static TreeNode Join(int value, TreeNode left, TreeNode right)
        {
            return new TreeNode(value, left, right);
        }

        internal TreeNode WithLeaves(int left, int right)
        {
            this.left = new TreeNode(left);
            this.right = new TreeNode(right);

            return this;
        }
    }
}
