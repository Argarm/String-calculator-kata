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
            char delimiter = Delimiter_changer(numbers);
            if (delimiter != ',') numbers = ParseInput(numbers.Substring(3), delimiter);
            return Check_more_than_1_number(ParseInput(numbers,delimiter),delimiter);

        }

        private String ParseInput(String numbers,char delimiter)
        {
            
            numbers = numbers.Trim();
            return numbers.Replace('\n', delimiter);
        }

        private char Delimiter_changer(String numbers)
        {
            if (numbers.Contains("//"))return numbers[2];
            return ',';
        }

        private int Check_more_than_1_number(String numbers,char delimiter)
        {
            return numbers.Contains(delimiter) ? Sum_Numbers(numbers,delimiter) : Int32.Parse(numbers);
        }


        private int Sum_Numbers(String numbers,char delimiter)
        {

            int res = 0;
            String negatives = "";
            foreach (String single in numbers.Split(delimiter))
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
