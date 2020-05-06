using FluentAssertions;
using Xunit;

namespace DumbCalculator.Tests
{
	public class Calculations
	{
        [Fact]
        public void TakeInNumbers()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput("-33.6");
            Program.ProcessOneInput("2.5");
            Program.Stack.Should().BeEquivalentTo(-33.6d, 2.5d);
        }
	}
}
