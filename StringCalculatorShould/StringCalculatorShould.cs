using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorShould
{
    [TestClass]
    public class StringCalculatorShould
    {
        StringCalculator pruebas = new StringCalculator();
        [TestMethod]
        public void return_0_when_input_is_empty_string()
        {
            Assert.AreEqual(0, pruebas.add(""));
        }

        [TestMethod]
        public void return_number_when_input_is_that_number()
        {
            Assert.AreEqual(2, pruebas.add("2"));
        }

        [TestMethod]
        public void return_3_when_input_is_1_and_2()
        {
            Assert.AreEqual(3, pruebas.add("1,2"));
        }

        [TestMethod]
        public void return_sum_when_input_are_2_numbers()
        {
            Assert.AreEqual(7, pruebas.add("5,2"));
        }

        [TestMethod]
        public void return_6_when_input_are_1_2_3()
        {
            Assert.AreEqual(6, pruebas.add("1,2,3"));
        }
        [TestMethod]
        public void return_3_when_input_have_LF()
        {
            Assert.AreEqual(3, pruebas.add("1\n2"));
        }
        

    }
}
