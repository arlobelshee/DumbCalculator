using System;

namespace DumbCalculator
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine(
				"I wish to do your bidding! I'm an RPN interpreter! I also support variables. Use the special command ? to get help.");
			Console.Write("> ");
			var input = Console.ReadLine();
			if(input.Trim() == "?") Console.WriteLine(@"Supported commands:
	? -> print this help.
	q -> quit.
	[any decimal number] -> push that number onto the stack.
	+ -> Pop the top 2 items on the stack, add them, push result onto the stack.
	- -> Pop the top 2 items on the stack, subtract the top from the one under it, push result onto the stack.
	* -> Pop the top 2 items on the stack, multiply them, push result onto the stack.
	/ -> Pop the top 2 items on the stack, divide the top into the one under it, push result onto the stack.
	=[name] -> pop the top of the stack and store it into a variable named `name`.
	$[name] -> retrieve the value of the variable named `name` and push it onto the stack.");
			Console.WriteLine("Quitting now.");
			Console.ReadLine();
		}
	}
}