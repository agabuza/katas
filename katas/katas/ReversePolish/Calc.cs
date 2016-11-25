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
