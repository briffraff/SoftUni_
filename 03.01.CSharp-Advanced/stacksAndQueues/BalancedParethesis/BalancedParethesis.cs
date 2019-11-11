using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParethesis
{
    class BalancedParethesis
    {
        static void Main(string[] args)
        {

            Stack<char> stackOfParethesis = new Stack<char>();

            string parentheses = Console.ReadLine();

            char[] openParentheses = new char[] { '(', '[', '{' };

            bool isValid = true;

            for (int i = 0; i < parentheses.Length; i++)
            {
                char currentBracket = parentheses[i];

                if (openParentheses.Contains(currentBracket))
                {
                    stackOfParethesis.Push(currentBracket);
                    continue;
                }

                if (stackOfParethesis.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParethesis.Peek() == '(' && currentBracket == ')')
                {
                    stackOfParethesis.Pop();
                }
                else if (stackOfParethesis.Peek() == '[' && currentBracket == ']')
                {
                    stackOfParethesis.Pop();
                }
                else if (stackOfParethesis.Peek() == '{' && currentBracket == '}')
                {
                    stackOfParethesis.Pop();
                }

            }

            if (isValid && stackOfParethesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
