namespace DumbCalculator
{
    public interface IReadWrite
    {
        string ReadLine();
        void Write(string value);
        void WriteLine(string formatOrValue, params object[] values);
    }
}