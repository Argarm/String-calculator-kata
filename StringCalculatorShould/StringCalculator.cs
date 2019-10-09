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
            Console.Write(numbers);
            return numbers.Length > 0 ? check_more_than_1_number(parseInput(numbers)) : 0;
        
        }

        private String parseInput(String numbers) {
            if (numbers.Contains("//")) {
                numbers = delimiter_changer(numbers);
            }
            numbers = numbers.Trim();
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
            String negatives = "";
            foreach (String single in numbers.Split(delimiter))
            {
                if (int.Parse(single) < 0)
                {
                    negatives+= " " + single;
                    //Console.Write(single);
                }
                res += int.Parse(single);        

            }
            if (negatives.Length != 0)
            {
                throw new ArgumentException("Negatives not allowed:" + negatives);
            }

            return  res;
        }

    }
}
