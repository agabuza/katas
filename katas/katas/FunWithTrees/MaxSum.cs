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
}
