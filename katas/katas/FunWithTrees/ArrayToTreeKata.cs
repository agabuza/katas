// https://www.codewars.com/kata/57e5a6a67fbcc9ba900021cd
//You are given a non-null array of integers.Implement the method arrayToTree which creates a binary tree from its values in accordance to their order, while creating nodes by depth from left to right.
//For example, given the array[17, 0, -4, 3, 15] you should create the following tree:

//    17
//   /  \
//  0   -4
// / \
//3   15 

using System.Linq;

namespace katas.FunWithTrees
{
    class ArrayToTreeKata
    {
        internal static TreeNode ArrayToTree(int[] array)
        {
            if (array.Length == 0) return null;

            var nodes = array.Select((x, i) => new { Index = i, Value = x })
                             .ToDictionary((x) => x.Index, x => new TreeNode(x.Value));
            
            var j = 0;
            while (nodes.TryGetValue(j * 2 + 1, out nodes[j].left) && nodes.TryGetValue(j * 2 + 2, out nodes[j].right)) j++;

            return nodes[0];
        }
    }
}
