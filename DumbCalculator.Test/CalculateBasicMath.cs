using Xunit;

namespace DumbCalculator.Test
{
    public class CalculateBasicMath
    {
        [Fact]
        public void VerifyAddition()
        {
            // Push 2
            Program.HandleOneUserInput("2");
            // Push 4
            Program.HandleOneUserInput("4");
            // Push + operation
            Program.HandleOneUserInput("+");
            // Verify stack contains 6
        }
    }
}
