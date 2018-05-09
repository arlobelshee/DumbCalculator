﻿using System;
using System.Collections.Generic;

namespace DumbCalculator
{
	internal class Program
	{
		private const string HelpInfo = @"Supported commands:
	? -> print this help.
	q -> quit.
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
				if (input.StartsWith("="))
					if (Stack.Count == 0)
						Console.WriteLine("Nothing to store! Variable unaltered.");
					else
						Variables[input.Substring(1)] = Stack.Pop();
				else
					switch (input)
					{
						case "?":
							Console.WriteLine(HelpInfo);
							break;
						case "q":
							Console.WriteLine("Quitting now.");
							Console.ReadLine();
							return;
						default:
							Console.WriteLine("I have no idea what you mean. Use ? to ask for help if you want it.");
							break;
					}
			}
		}
	}
}