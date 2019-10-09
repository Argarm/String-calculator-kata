using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorShould
{
    class StringCalculator
    {
        private char delimiter = ',';
        public int add(String numbers)
        {
            return numbers.Length > 0 ? check_more_than_1_number(parseInput(numbers.Trim())) : 0;
        
        }

        private String parseInput(String numbers) {
            if (numbers.Contains("//")) {
                numbers = delimiter_changer(numbers);
            }
            
            return numbers.Replace('\n', delimiter);
        }

        private String delimiter_changer(String numbers) {
            delimiter = numbers[2];
            return numbers.Substring(3);
        }

        private int check_more_than_1_number(String numbers)
        {
            return numbers.Contains(delimiter) ? Sum_Numbers(numbers) : Int32.Parse(numbers); 
        }

        private int Sum_Numbers(String numbers)
        {
            int res = 0;

            foreach (String single in numbers.Split(delimiter))
            {
                res += int.Parse(single);        
            }

            return res;
        }
    }
}
