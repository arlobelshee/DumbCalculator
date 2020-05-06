using System.Collections.Generic;

namespace DumbCalculator
{
    internal class FormulaDefinition
    {
        public FormulaDefinition(string name, Stack<decimal> stack, Dictionary<string, decimal> variables)
        {
            Name = name;
            InitialStack = stack;
            InitialVariables = variables;
        }

        public string Name { get; set; }
        public Stack<decimal> InitialStack { get; }
        public Dictionary<string, decimal> InitialVariables { get; }
    }
}