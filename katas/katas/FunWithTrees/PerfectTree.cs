
//A perfect binary tree is a binary tree in which all interior nodes have two children and all leaves have the same depth or same level.
//You are given a class called TreeNode.Implement the method isPerfect which determines if a given tree denoted by its root node is perfect.

namespace katas.FunWithTrees
{
    class PerfectTree
    {
        internal static bool IsPerfect(TreeNode root)
        {
            if (root == null) return true;

            if (root.left != null && root.right != null)
            {
                return IsPerfect(root.left) && IsPerfect(root.right) && SiblingsCount(root.left) == SiblingsCount(root.right);
            }
            else
            {
                return root.left == null && root.right == null;
            }
        }

        internal static int SiblingsCount(TreeNode root)
        {
            return (root.left == null ? 0 : 1) + 
                    (root.right == null ? 0 : 1);
        }
    }
}
