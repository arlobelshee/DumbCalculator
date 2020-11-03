using System;
using System.Collections.Generic;

namespace DumbCalculator
{
	internal class Program
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

		private static readonly Stack<decimal> Stack = new Stack<decimal>();
		private static readonly Dictionary<string, decimal> Variables = new Dictionary<string, decimal>();

		private static void Main(string[] args)
		{
			Console.WriteLine(
				"I wish to do your bidding! I'm an RPN interpreter! I also support variables. Use the special command ? to get help.");
            var keepGoing = true;
            while (keepGoing)
            {
                Console.Write("> ");
                var input = Console.ReadLine().Trim();
                keepGoing = HandleOneUserInput(keepGoing, input);
            }
        }

        public static bool HandleOneUserInput(bool keepGoing, string input)
        {
            if (decimal.TryParse(input, out decimal number))
            {
                Stack.Push(number);
            }
            else if (input.StartsWith("="))
            {
                if (Stack.Count == 0)
                {
                    Console.WriteLine("Nothing to store! Variable unaltered.");
                }
                else
                {
                    Variables[input.Substring(1)] = Stack.Pop();
                }
            }
            else if (input.StartsWith("$"))
            {
                Stack.Push(Variables[input.Substring(1)]);
            }
            else
            {
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
                        Console.ReadLine();
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
                        break;
                }
            }

            return keepGoing;
        }
    }
}
