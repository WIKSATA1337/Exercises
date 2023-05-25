namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
    using System.Linq;
    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char character = parentheses[i];

                if (character == '[' || character == '{' || character == '(')
                {
                    stack.Push(character);
                }
                else if (character == ']' || character == '}' || character == ')')
                {
                    if (stack.Any() == false)
                    {
                        return false;
                    }
                        
                    switch (character)
                    {
                        case ']':
                            if (stack.Pop() != '[')
                                return false;
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                                return false;
                            break;
                        case ')':
                            if (stack.Pop() != '(')
                                return false;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (stack.Any() == false)
            {
                return true;
            }
                
            return false;
        }
    }
}
