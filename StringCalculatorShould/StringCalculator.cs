using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorShould
{
    class StringCalculator
    {
        public int add(String name)
        {
            return name.Length> 0 ? Int32.Parse(name):0;
        
        }
    }
}
