//Your job is to create a calculator which evaluates expressions in Reverse Polish notation.
//For example expression 5 1 2 + 4 * + 3 - (which is equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) should evaluate to 14.
//For your convenience, the input is formatted such that a space is provided between every token.
//Empty expression should evaluate to 0.
//Valid operations are +, -, *, /.
//You may assume that there won't be exceptional situations (like stack underflow or division by zero).

using System.Collections.Generic;
using System.Globalization;

namespace katas.ReversePolish
{
    public class Calc
    {
        public double evaluate(string expr)
        {
            if (string.IsNullOrEmpty(expr)) return 0;

            var stack = new Stack<double>();
            double number = 0;

            foreach (string elem in expr.Split(' '))
            {
                if (double.TryParse(elem, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    var rightOperand = stack.Pop();
                    var leftOperand = stack.Pop();
                    stack.Push(PerformOperation(leftOperand, rightOperand, elem));
                }
            }

            return stack.Pop();
        }

        private double PerformOperation(double leftOperand, double rightOperand, string op)
        {
            switch (op)
            {
                case "+":
                    return leftOperand + rightOperand;
                case "-":
                    return leftOperand - rightOperand;
                case "*":
                    return leftOperand * rightOperand;
                case "/":
                    return leftOperand / rightOperand;
                default:
                    return 0;
            }
        }
    }
}
