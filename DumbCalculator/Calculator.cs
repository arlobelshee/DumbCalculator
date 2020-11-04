using System;
using System.Collections.Generic;

namespace DumbCalculator
{
    public class Calculator
    {
        private const string HelpInfo = @"Supported commands:
	? -> print this help.
	q -> quit.
	dump -> dump the contents of the stack and all variables.
	[any decimal number] -> push that number onto the stack.
	+ -> Pop the top 2 items on the stack, add them, push result onto the stack.
	- -> Pop the top 2 items on the stack, subtract the top from the one under it, push result onto the stack.
	* -> Pop the top 2 items on the stack, multiply them, push result onto the stack.
	/ -> Pop the top 2 items on the stack, divide the top into the one under it, push result onto the stack.
	=[name] -> pop the top of the stack and store it into a variable named `name`.
	$[name] -> retrieve the value of the variable named `name` and push it onto the stack.";

        public IEnumerable<decimal> StackContents { get { return Stack; } }

        private readonly Stack<decimal> Stack = new Stack<decimal>();
        private readonly Dictionary<string, decimal> Variables = new Dictionary<string, decimal>();

        public bool HandleOneUserInput(string input)
        {
            if (decimal.TryParse(input, out decimal number))
            {
                Stack.Push(number);
                return true;
            }
            var result = HandleVariables(input);
            if (result.HasValue) return result.Value;
            switch (input)
            {
                case "?":
                    Console.WriteLine(HelpInfo);
                    break;
                case "+":
                    if (Stack.Count < 2)
                    {
                        Console.WriteLine("Not enough values to add! Please push more onto the stack and try again.");
                    }
                    else
                    {
                        var top = Stack.Pop();
                        var second = Stack.Pop();
                        Stack.Push(second + top);
                    }
                    break;
                case "-":
                    if (Stack.Count < 2)
                    {
                        Console.WriteLine("Not enough values to subtract! Please push more onto the stack and try again.");
                    }
                    else
                    {
                        var top = Stack.Pop();
                        var second = Stack.Pop();
                        Stack.Push(second - top);
                    }
                    break;
                case "*":
                    if (Stack.Count < 2)
                    {
                        Console.WriteLine("Not enough values to multiply! Please push more onto the stack and try again.");
                    }
                    else
                    {
                        var top = Stack.Pop();
                        var second = Stack.Pop();
                        Stack.Push(second * top);
                    }
                    break;
                case "/":
                    if (Stack.Count < 2)
                    {
                        Console.WriteLine("Not enough values to divide! Please push more onto the stack and try again.");
                    }
                    else
                    {
                        var top = Stack.Pop();
                        var second = Stack.Pop();
                        Stack.Push(second / top);
                    }
                    break;
                case "dump":
                    Console.WriteLine("Variables:");
                    foreach (var variable in Variables)
                    {
                        Console.WriteLine("	{0} := {1}", variable.Key, variable.Value);
                    }
                    Console.WriteLine("Stack");
                    foreach (var value in Stack)
                    {
                        Console.WriteLine("	{0}", value);
                    }
                    break;
                case "q":
                    Console.WriteLine("Quitting now.");
                    return false;
                default:
                    Console.WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
                    break;
            }

            return true;
        }

        private bool? HandleVariables(string input)
        {
            if (input.StartsWith("="))
            {
                if (Stack.Count == 0)
                {
                    Console.WriteLine("Nothing to store! Variable unaltered.");
                }
                else
                {
                    Variables[input.Substring(1)] = Stack.Pop();
                }
                return true;
            }
            if (input.StartsWith("$"))
            {
                Stack.Push(Variables[input.Substring(1)]);
                return true;
            }
            return null;
        }
    }
}
