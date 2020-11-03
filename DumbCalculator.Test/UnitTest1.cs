using ApprovalTests;
using NSubstitute;
using System.Linq;
using Xunit;

namespace DumbCalculator.Test
{
    public class UnitTest1
    {
        [Fact]
        public void VerifyAddition()
        {
            var ui = Substitute.For<IReadWrite>();

            // Push 2
            // Push 4
            // Push + operation
            ui.ReadLine().Returns("2\n", "4\n", "+\n", "q\n");
            Program.CalculateForUserUntilDone(ui);

            // Peek, verify stack is [6].
            Approvals.VerifyAll("Stack", Program.StackContents, val => val.ToString());
        }
    }
}
