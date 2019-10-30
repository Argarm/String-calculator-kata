using System;
using System.Collections.Generic;
using System.Text;

namespace kata_String_Calculator
{
    public class StringCalculator
    {
        private int MAX_NUMBER = 1000;
        private char NEW_LINE='\n';
        private char DELIMITER = ',';
        private static string NEW_DELIMITER_IDENTIFIER= "//";
        private const int MIN_NUMBER = 0;

        public int Add(String numbers)
        {
            if (IsStringNullOrEmpty(numbers)) return 0;

            return SumNumbers(NormilizeString(numbers));

        }

        private static bool IsStringNullOrEmpty(string numbers)
        {
            return String.IsNullOrEmpty(numbers);
        }


        private String NormilizeString(String numbers)
        {
            
            if (IsNewDelimiterIdicator(numbers))
            {
                numbers = numbers.Replace(numbers[2], DELIMITER);

                numbers = numbers.Substring(3).Trim();


            }
            numbers = numbers.Trim();
           
            return numbers.Replace(NEW_LINE, DELIMITER);
        }

        private static bool IsNewDelimiterIdicator(string numbers)
        {
            
            return numbers.Contains(NEW_DELIMITER_IDENTIFIER);
        }

        private int SumNumbers(String numbers)
        {
            if(!numbers.Contains(DELIMITER)) return Int32.Parse(numbers);
            int res = 0;
            String negatives = "";
            foreach (String single in numbers.Split(DELIMITER))
            {
                
                if (int.Parse(single) < MIN_NUMBER) negatives += " " + single;
                
                if (int.Parse(single) > MAX_NUMBER) continue;
                res += int.Parse(single);

            }

            CheckNegatives(negatives);
            return res;
        }

        private void CheckNegatives(String negatives)
        {
            if (!IsStringNullOrEmpty(negatives)) throw new ArgumentException("Negatives not allowed:" + negatives);
        }

    }
}
