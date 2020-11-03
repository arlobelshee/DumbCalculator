using System;

namespace DumbCalculator
{
    internal class ReadWriteToConsole : IReadWrite
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string formatOrValue, params object[] values)
        {
            Console.WriteLine(formatOrValue, values);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
