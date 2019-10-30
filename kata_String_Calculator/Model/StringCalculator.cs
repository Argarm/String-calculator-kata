using System;
using System.Linq;

namespace Model
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
            if (IsEmpty(numbers)) return 0;

            return Sum(GiveMeNumbers(numbers));

        }

        private int[] GiveMeNumbers(string numbers)
        {
            var separatedString = Separate(NormilizeString(numbers));
            return ExtractNumbers(separatedString);
        }

        private string[] Separate(string numbers)
        {
            return numbers.Split(DELIMITER);
        }

        private string NormilizeString(String numbers)
        {
            numbers = numbers.Trim();

            if (IsNewDelimiterIndicator(numbers))
            {
                numbers = numbers.Replace(numbers[2], DELIMITER);

                numbers = numbers.Substring(3).Trim();
            }
            return numbers.Replace(NEW_LINE, DELIMITER);
        }

        private bool IsEmpty(string numbers)
        {
            return String.IsNullOrEmpty(numbers);
        }


        private int[] ExtractNumbers(string[] numbers)
        {
            return numbers.Select(int.Parse).ToArray();
        }

        

        private static bool IsNewDelimiterIndicator(string numbers)
        {
            
            return numbers.Contains(NEW_DELIMITER_IDENTIFIER);
        }

        private int Sum(int[] numbers)
        {
            var negatives = numbers.Where(IsNegative).ToList();
            if (negatives.Any()) throw new ArgumentException("Negatives not allowed: " + String.Join(" ",negatives));
            return numbers.Where(IsLessThanMaximum).Sum();

        }

        private bool IsLessThanMaximum(int number)
        {
            return number < MAX_NUMBER;
        }

        private bool IsNegative(int number)
        {
            return number < MIN_NUMBER;
        }

        
    }
}
