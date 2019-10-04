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
            if (name.Length > 0) return Int32.Parse(name);
            return 0;
        
        }
    }
}
