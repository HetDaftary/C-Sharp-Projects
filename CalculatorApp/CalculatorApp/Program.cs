using System;

namespace CalculatorApp
{
    class Program
    {
        /**
         * @breif gives the precedence of the operator
         * Higher precedence value means higher priority
         * @param op: operator in char format.
         * @return: precedence in int type.
         */
        private static int precedence(char op)
        {
            if (op == '+' || op == '-')
            {
                return 1;
            }
            if (op == '*' || op == '/')
            {
                return 2;
            }
            return 0;
        }

        /**
         * @breif Evaluates an operation.
         * @param a: an operand 
         * @param b: an operand
         * @param op: operator in char format.
         * @return answer.
         */
        private static int applyOp(int a, int b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
            } return 0;
        }

        /**
         * @breif Returs if the character is digit or not
         * @param c: the char to check
         * @return: Boolean if the char c is digit or not?
         */
        private static bool isdigit(char c)
        {
            int cVal = c;

            if (47 < cVal && cVal < 58)
            {
                return true;
            }
            return false;
        }

        /**
         * @breif A function to evalutate a string expression.
         * This solves an infix operation which means normal string expression that we type in calculator.
         * @param toEval: The string to evaluate.
         * @return Answer in double format.
         */
        public static int eval(string tokens)
        {
            int i;

            Stack<int> values = new Stack<int>(tokens.Length);
            Stack<char> ops = new Stack<char>(tokens.Length);

            for (i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ' ')
                    continue;

                else if (tokens[i] == '(')
                {
                    ops.push(tokens[i]);
                }

                else if (isdigit(tokens[i]))
                {
                    int val = 0;

                    while (i < tokens.Length && isdigit(tokens[i]))
                    {
                        val = (val * 10) + (tokens[i] - '0');
                        i++;
                    }

                    values.push(val);

                    i--;
                }

                else if (tokens[i] == ')')
                {
                    while (!ops.empty() && ops.top() != '(')
                    {
                        int val2 = values.top();
                        values.pop();

                        int val1 = values.top();
                        values.pop();

                        char op = ops.top();
                        ops.pop();

                        values.push(applyOp(val1, val2, op));
                    }

                    if (!ops.empty())
                    {
                        ops.pop();
                    }
                }

                else
                {
                    while (!ops.empty() && precedence(ops.top()) >= precedence(tokens[i]))
                    {
                        int val2 = values.top();
                        values.pop();

                        int val1 = values.top();
                        values.pop();

                        char op = ops.top();
                        ops.pop();

                        values.push(applyOp(val1, val2, op));
                    }

                    ops.push(tokens[i]);
                }
            }

            while (!ops.empty())
            {
                int val2 = values.top();
                values.pop();

                int val1 = values.top();
                values.pop();

                char op = ops.top();
                ops.pop();

                values.push(applyOp(val1, val2, op));
            }

            return values.top();
        }

        static void Main(string[] args)
        {
            string toEval;

            do
            {
                Console.Write("Enter the expression or q to quit: ");
                toEval = Console.ReadLine();

                Console.WriteLine($"Answer is {eval(toEval)}");
            } while (toEval != "q");
        }
    }
}
