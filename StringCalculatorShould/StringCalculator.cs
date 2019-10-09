using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorShould
{
    class StringCalculator
    {
        public int add(String numbers)
        {
            numbers = parseInput(numbers.Trim());
            return numbers.Length > 0 ? check_more_than_1_number(numbers) : 0;
        
        }

        private String parseInput(String numbers) { 
            return numbers.Replace('\n', ',');
        }

        public int check_more_than_1_number(String numbers)
        {
            return numbers.Contains(',') ? Sum_Numbers(numbers) : Int32.Parse(numbers); 
        }

        public int Sum_Numbers(String numbers)
        {
            int res = 0;

            foreach (String single in numbers.Split(','))
            {
                res += int.Parse(single);        
            }

            return res;
        }
    }
}
