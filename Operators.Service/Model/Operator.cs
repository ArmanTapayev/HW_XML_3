using System;
using System.Collections.Generic;
using System.Text;

namespace Operators.Service.Model
{
    public class Operator
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public double Percent { get; set; }

        public List<int> Prefixes = new List<int>();

    }
}
