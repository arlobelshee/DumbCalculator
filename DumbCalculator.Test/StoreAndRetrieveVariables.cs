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

        [Fact]
        public void RestoreVariablePutsItOnTopOfTheStack()
        {
            var testSubject = new Calculator();
            testSubject.HandleOneUserInput("3");
            testSubject.HandleOneUserInput("=name");
            testSubject.HandleOneUserInput("5");
            testSubject.HandleOneUserInput("$name");
            testSubject.HandleOneUserInput("$name");
            testSubject.StackContents.Should().BeEquivalentTo(new decimal[] { 5, 3, 3 } );
        }
    }
}
