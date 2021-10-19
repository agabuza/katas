using System.Collections.Generic;

namespace katas.ValidParentheses
{
    internal class Kata
    {
        public static bool ValidParentheses(string input)
        {
            var currentNode = new Node();
            var stack = new Stack<Node>();
            var nodes = new List<Node>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    currentNode = new Node
                    {
                        leftPos = i
                    };

                    stack.Push(currentNode);
                    nodes.Add(currentNode);
                }
                else if (input[i] == ')' && stack.Count > 0)
                {
                    currentNode.rightPos = i;
                    currentNode = stack.Pop();
                }
                else return false;
            }

            return stack.Count == 0;
        }

        public class Node
        {
            public int leftPos { get; set; }
            public int rightPos { get; set; }
        }
    }
}
