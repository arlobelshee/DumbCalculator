using FluentAssertions;
using System;
using Xunit;

namespace DumbCalculator.Tests
{
	public class Calculations
	{
        private const decimal lhs = 1.2M;
        private const decimal rhs = 2.5M;

        [Fact]
        public void TakeInNumbers()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput("-33.6");
            Program.ProcessOneInput("2.5");
            Program.Stack.Should().BeEquivalentTo(-33.6M, 2.5M);
        }

        [Fact]
        public void BinaryOperationWithOnlyOneArg()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput("+");
            Program.Stack.Should().BeEquivalentTo(lhs);
        }

        [Fact]
        public void Add()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput(rhs.ToString());
            Program.ProcessOneInput("+");
            Program.Stack.Should().BeEquivalentTo(lhs + rhs);
        }

        [Fact]
        public void Subtract()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput(rhs.ToString());
            Program.ProcessOneInput("-");
            Program.Stack.Should().BeEquivalentTo(lhs - rhs);
        }

        [Fact]
        public void Multiply()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput(rhs.ToString());
            Program.ProcessOneInput("*");
            Program.Stack.Should().BeEquivalentTo(lhs * rhs);
        }

        [Fact]
        public void Divide()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput(rhs.ToString());
            Program.ProcessOneInput("/");
            Program.Stack.Should().BeEquivalentTo(lhs / rhs);
        }

        [Fact]
        [Trait("Category", "Documents possible bug")]
        public void Exponentiate()
        {
            Program.Stack.Clear();
            Program.ProcessOneInput(rhs.ToString());
            Program.ProcessOneInput(lhs.ToString());
            Program.ProcessOneInput("^");
            Program.Stack.Should().BeEquivalentTo((decimal) Math.Pow((double) lhs, (double) rhs));
        }
	}
}
