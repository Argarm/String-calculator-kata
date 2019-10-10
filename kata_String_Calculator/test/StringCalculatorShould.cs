using NUnit.Framework;
using kata_String_Calculator;
using System;

namespace test
{
    public class Tests
    {
        [TestFixture]
        public class StringCalculatorShould
        {
            StringCalculator pruebas;
            [SetUp]
            public void setUp()
            {
                pruebas = new StringCalculator();
            }

            [Test]
            public void return_0_when_input_is_empty_string()
            {
                Assert.AreEqual(0, pruebas.add(""));
            }

            [Test]
            public void return_number_when_input_is_that_number()
            {
                Assert.AreEqual(2, pruebas.add("2"));
            }

            [Test]
            public void return_3_when_input_is_1_and_2()
            {
                Assert.AreEqual(3, pruebas.add("1,2"));
            }

            [Test]
            public void return_sum_when_input_are_2_numbers()
            {
                Assert.AreEqual(7, pruebas.add("5,2"));
            }

            [Test]
            public void return_6_when_input_are_1_2_3()
            {
                Assert.AreEqual(6, pruebas.add("1,2,3"));
            }
            [Test]
            public void return_3_when_input_have_LF()
            {
                Assert.AreEqual(3, pruebas.add("1\n2"));
            }

            [Test]
            public void return_6_when_input_have_LF_and_commas()
            {
                Assert.AreEqual(6, pruebas.add("1\n2,3"));
            }


            [Test]
            public void return_6_when_input_have_at_the_beginning_LF_and_commas()
            {
                Assert.AreEqual(6, pruebas.add("\n1\n2,3"));
            }

            [Test]
            public void return_3_when_input_have_different_delimiter()
            {
                Assert.AreEqual(3, pruebas.add("//;1\n2"));
            }

            [Test]
            public void return_3_when_input_have_different_delimiter_and_LF()
            {
                Assert.AreEqual(3, pruebas.add("//;\n1;2"));
            }

            [Test]
            public void throw_exception_when_have_negative_numbers()
            {
                try
                {
                    pruebas.add("1,4,-3");
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "Negatives not allowed: -3");
                }
            }


            [Test]
            public void throw_exception_when_have_negative_several_numbers()
            {
                try
                {
                    pruebas.add("-5,4,-3");
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.AreEqual(e.Message, "Negatives not allowed: -5 -3");
                }
            }

            [Test]
            public void return_2_when_input_have_one_big_number()
            {
                Assert.AreEqual(2, pruebas.add("1001,2"));
            }

        }
    }
}