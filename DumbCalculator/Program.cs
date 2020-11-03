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
            var userInteraction = new ReadWriteToConsole();
            CalculateForUserUntilDone(userInteraction);
        }

        private static void CalculateForUserUntilDone(ReadWriteToConsole userInteraction)
        {
            userInteraction.WriteLine(
                "I wish to do your bidding! I'm an RPN interpreter! I also support variables. Use the special command ? to get help.");
            while (true)
            {
                userInteraction.Write("> ");
                var input = ReadWriteToConsole.ReadLine().Trim();
                if (decimal.TryParse(input, out decimal number))
                {
                    Stack.Push(number);
                }
                else if (input.StartsWith("="))
                {
                    if (Stack.Count == 0)
                    {
                        userInteraction.WriteLine("Nothing to store! Variable unaltered.");
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
                            userInteraction.WriteLine(HelpInfo);
                            break;
                        case "+":
                            if (Stack.Count < 2)
                            {
                                userInteraction.WriteLine("Not enough values to add! Please push more onto the stack and try again.");
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
                                userInteraction.WriteLine("Not enough values to subtract! Please push more onto the stack and try again.");
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
                                userInteraction.WriteLine("Not enough values to multiply! Please push more onto the stack and try again.");
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
                                userInteraction.WriteLine("Not enough values to divide! Please push more onto the stack and try again.");
                            }
                            else
                            {
                                var top = Stack.Pop();
                                var second = Stack.Pop();
                                Stack.Push(second / top);
                            }
                            break;
                        case "dump":
                            userInteraction.WriteLine("Variables:");
                            foreach (var variable in Variables)
                            {
                                userInteraction.WriteLine("	{0} := {1}", variable.Key, variable.Value);
                            }
                            userInteraction.WriteLine("Stack");
                            foreach (var value in Stack)
                            {
                                userInteraction.WriteLine("	{0}", value);
                            }
                            break;
                        case "q":
                            userInteraction.WriteLine("Quitting now.");
                            Console.ReadLine();
                            return;
                        default:
                            userInteraction.WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
                            break;
                    }
                }
            }
        }
    }
}
