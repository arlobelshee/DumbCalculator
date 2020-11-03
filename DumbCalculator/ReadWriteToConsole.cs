using System;

namespace DumbCalculator
{
    internal class ReadWriteToConsole
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public static void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
