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
        public TreeNode()
        {
            this.value = 0;
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

        internal static TreeNode Leaf()
        {
            return new TreeNode();
        }
        
        internal static TreeNode Join(TreeNode left, TreeNode right)
        {
            return new TreeNode().WithChildren(left, right);
        }
        
        internal TreeNode WithLeft(TreeNode left)
        {
            this.left = left;
            return this;
        }
        
        internal TreeNode WithRight(TreeNode right)
        {
            this.right = right;
            return this;
        }
        
        internal TreeNode WithChildren(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
            return this;
        }
        
        internal TreeNode WithLeftLeaf()
        {
            return WithLeft(Leaf());
        }
        
        internal TreeNode WithRightLeaf()
        {
            return WithRight(Leaf());
        }
        
        internal TreeNode WithLeaves()
        {
            return WithChildren(Leaf(), Leaf());
        }
    }
}
