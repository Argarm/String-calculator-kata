using NUnit.Framework;
using kata_String_Calculator;
using System;
using FluentAssertions;

namespace test
{
    public class Tests
    {
        [TestFixture]
        public class StringCalculatorShould
        {
            StringCalculator stringCalculator;
            [SetUp]
            public void setUp()
            {
                stringCalculator = new StringCalculator();
            }

            [Test]
            public void return_0_when_input_is_empty_string()
            {
                var given = "";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(0);
            }
            
            [Test]
            public void return_number_when_input_is_that_number()
            {
                var given = "2";

                var when = stringCalculator.Add(given);

                when.Should().Be(2);
            }

            [Test]
            public void return_3_when_input_is_1_and_2()
            {
                var given = "1,2";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(3);
            }

            [Test]
            public void return_sum_when_input_are_2_numbers()
            {
                var given = "5,2";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(7);
            }

            [Test]
            public void return_6_when_input_are_1_2_3()
            {
                var given = "1,2,3";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(6);
            }
            [Test]
            public void return_3_when_input_have_LF()
            {
                var given = "1\n2";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(3);
            }

            [Test]
            public void return_6_when_input_have_LF_and_commas()
            {
                var given = "1\n2,3";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(6);
            }


            [Test]
            public void return_6_when_input_have_at_the_beginning_LF_and_commas()
            {
                var given = "\n1\n2, 3";

                var when = stringCalculator.Add(given);
                
                when.Should().Be(6);
            }

            [Test]
            public void return_3_when_input_have_different_delimiter()
            {
                var given = "//;1\n2";

                var when = stringCalculator.Add(given);
                
                
                when.Should().Be(3);
            }

            [Test]
            public void return_3_when_input_have_different_delimiter_and_LF()
            {
                var given = "//;\n1;2";

                var when = stringCalculator.Add(given);

                when.Should().Be(3);
            }

            [Test]
            public void throw_exception_when_have_negative_numbers()
            {
                var given = "1,2,-3";

                Action a = () => stringCalculator.Add(given);

                a.Should().Throw<ArgumentException>().WithMessage("Negatives not allowed: -3");
                
            }


            [Test]
            public void throw_exception_when_have_negative_several_numbers()
            {
                var given = "-5,2,-3";

                Action a = () => stringCalculator.Add(given);

                a.Should().Throw<ArgumentException>().WithMessage("Negatives not allowed: -5 -3");
            }

            [Test]
            public void return_2_when_input_have_one_big_number()
            {
                var given = "1001,2";

                var when = stringCalculator.Add(given);

                when.Should().Be(2);
            }
        }
    }
}