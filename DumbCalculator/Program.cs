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
			while (true)
			{
				Console.Write("> ");
				var input = Console.ReadLine().Trim();
				var parsedSuccessfully = false;
				if (HandleNumberIfPresent(input))
				{
					continue;
				}
				if (HandleVariableAssignIfPresent(input))
				{
					continue;
				}
				if (HandleVariableReferenceIfPresent(input))
				{
					continue;
				}
				parsedSuccessfully = HandleRequestForHelpIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				parsedSuccessfully = HandleAdditionIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				parsedSuccessfully = HandleSubtractionIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				parsedSuccessfully = HandleMultiplicationIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				parsedSuccessfully = HandleDivisionIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				parsedSuccessfully = HandleDumpIfPresent(input, parsedSuccessfully);
				if (parsedSuccessfully)
				{
					continue;
				}
				if (input == "q")
				{
					parsedSuccessfully = true;
					Console.WriteLine("Quitting now.");
					Console.ReadLine();
					return;
				}
				if (parsedSuccessfully)
				{
					continue;
				}
				DisplayParseError();
			}
		}

		private static bool HandleRequestForHelpIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "?")
			{
				return false;
			}
			Console.WriteLine(HelpInfo);
			return true;
		}

		private static bool HandleAdditionIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "+")
			{
				return false;
			}
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
			return true;
		}

		private static bool HandleSubtractionIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "-")
			{
				return false;
			}
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
			return true;
		}

		private static bool HandleMultiplicationIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "*")
			{
				return false;
			}
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
			return true;
		}

		private static bool HandleDivisionIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "/")
			{
				return false;
			}
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
			return true;
		}

		private static bool HandleDumpIfPresent(string input, bool parsedSuccessfully)
		{
			if (input != "dump")
			{
				return false;
			}
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
			return true;
		}

		private static void DisplayParseError()
		{
			Console.WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
		}

		private static bool HandleVariableReferenceIfPresent(string input)
		{
			if (!input.StartsWith("$"))
			{
				return false;
			}
			Stack.Push(Variables[input.Substring(1)]);
			return true;
		}

		private static bool HandleVariableAssignIfPresent(string input)
		{
			if (!input.StartsWith("="))
			{
				return false;
			}
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

		private static bool HandleNumberIfPresent(string input)
		{
			if (!decimal.TryParse(input, out decimal number))
			{
				return false;
			}
			Stack.Push(number);
			return true;
		}
	}
}
