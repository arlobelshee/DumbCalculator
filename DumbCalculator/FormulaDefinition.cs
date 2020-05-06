﻿using System.Collections.Generic;

namespace DumbCalculator
{
    internal class FormulaDefinition
    {
        private readonly Dictionary<string, decimal> _initialVariables;
        private readonly Stack<decimal> _initialStack;
        private readonly string _name;

        public FormulaDefinition(string name, Stack<decimal> initialStack, Dictionary<string, decimal> initialVariables)
        {
            _name = name;
            _initialStack = initialStack;
            _initialVariables = initialVariables;
        }
    }
}