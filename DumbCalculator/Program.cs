using System;
using System.Collections.Generic;

namespace DumbCalculator
{
	public class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine(
				"I wish to do your bidding! I'm an RPN interpreter! I also support variables. Use the special command ? to get help.");
            var keepGoing = true;
            while (keepGoing)
            {
                Console.Write("> ");
                var input = Console.ReadLine().Trim();
                keepGoing = Calculator.HandleOneUserInput(input);
            }
            Console.ReadLine();
        }
    }
}
