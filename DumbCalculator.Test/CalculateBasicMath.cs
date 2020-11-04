using ApprovalTests;
using Xunit;

namespace DumbCalculator.Test
{
    public class CalculateBasicMath
    {
        [Fact]
        public void VerifyAddition()
        {
            var testSubject = new Calculator();
            // Push 2
            Calculator.HandleOneUserInput("2");
            // Push 4
            Calculator.HandleOneUserInput("4");
            // Push + operation
            Calculator.HandleOneUserInput("+");
            // Verify stack contains 6
            Approvals.VerifyAll("Stack", Calculator.StackContents, value => value.ToString());
        }
    }
}
