using FluentAssertions;
using Xunit;

namespace DumbCalculator.Test
{
    public class StoreAndRetrieveVariables
    {
        [Fact]
        public void StoreVariableRemovesItFromTheStack()
        {
            var testSubject = new Calculator();
            testSubject.HandleOneUserInput("3");
            testSubject.HandleOneUserInput("=name");
            testSubject.StackContents.Should().BeEmpty();
        }
    }
}
