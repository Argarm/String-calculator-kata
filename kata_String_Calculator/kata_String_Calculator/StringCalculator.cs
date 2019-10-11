using System;
using System.Collections.Generic;
using System.Text;

namespace kata_String_Calculator
{
    public class StringCalculator
    {
        public long Add(String numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;

            numbers = ParseInput(numbers);

            return Sum_Numbers(numbers);

        }


        private String ParseInput(String numbers)
        {
            if (numbers.Contains("//"))
            {
                numbers = numbers.Replace(numbers[2], ',');

                numbers = numbers.Substring(3).Trim();

            }
            numbers = numbers.Trim();
            return numbers.Replace('\n', ',');
        }

        private int Sum_Numbers(String numbers)
        {
            if(!numbers.Contains(',')) return Int32.Parse(numbers);
            int res = 0;
            String negatives = "";
            foreach (String single in numbers.Split(','))
            {
                if (int.Parse(single) < 0) negatives += " " + single;
                if (int.Parse(single) > 1000) continue;
                res += int.Parse(single);

            }

            Check_negatives(negatives);
            return res;
        }

        private void Check_negatives(String negatives)
        {
            if (!String.IsNullOrEmpty(negatives)) throw new ArgumentException("Negatives not allowed:" + negatives);
        }

    }
}
