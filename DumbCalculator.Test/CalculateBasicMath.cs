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
            testSubject.HandleOneUserInput("2");
            // Push 4
            testSubject.HandleOneUserInput("4");
            // Push + operation
            testSubject.HandleOneUserInput("+");
            // Verify stack contains 6
            Approvals.VerifyAll("Stack", testSubject.StackContents, value => value.ToString());
        }
    }
}
