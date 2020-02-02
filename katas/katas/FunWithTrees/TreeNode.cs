namespace katas.FunWithTrees
{
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
