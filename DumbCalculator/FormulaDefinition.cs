using System;
using System.Collections.Generic;
using System.IO;

namespace DumbCalculator
{
    internal class FormulaDefinition
    {
        private string _name;

        public FormulaDefinition(string name)
        {
            _name = name;
        }

        internal void AddTo(Dictionary<string, FormulaDefinition> formulas)
        {
            formulas[_name] = this;
        }

        internal void PrintTo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}