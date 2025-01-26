using System;
using System.Collections.Generic;

class Program
{
    static bool isBalanced(string expr)
    {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in expr)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0 || !isMatchingPair(stack.Pop(), c))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    static bool isMatchingPair(char opening, char closing)
    {
        if (opening == '(' && closing == ')')
            return true;
        if (opening == '{' && closing == '}')
            return true;
        if (opening == '[' && closing == ']')
            return true;
        return false;
    }

    static void Main(string[] args)
    {
        string expr = "{7+(8*5)-[(9-7)+(4+1)]}";
        if (isBalanced(expr))
            Console.WriteLine("La expresión está balanceada");
        else
            Console.WriteLine("La expresión no está balanceada");
    }
}
