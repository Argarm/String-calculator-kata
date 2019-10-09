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
            return name.Length > 0 ? check_more_than_1_number(name):0;
        
        }

        public int check_more_than_1_number(String name)
        {
            return name.Contains(',') ? (int)Char.GetNumericValue(name[0]) + (int)Char.GetNumericValue(name[2]) : Int32.Parse(name); 
        }
    }
}
