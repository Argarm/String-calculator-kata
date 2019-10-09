using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorShould
{
    [TestClass]
    public class StringCalculatorShould
    {
        StringCalculator pruebas = new StringCalculator();
        [TestMethod]
        public void Return_0_When_Input_Is_Empty_String()
        {
            Assert.AreEqual(0, pruebas.add(""));
        }

        [TestMethod]
        public void Return_Number_When_Input_Is_That_Number()
        {
            Assert.AreEqual(2, pruebas.add("2"));
        }

        [TestMethod]
        public void Return_3_When_Input_Is_1_And_2()
        {
            Assert.AreEqual(3, pruebas.add("1,2"));
        }

        [TestMethod]
        public void Return_Sum_When_Input_Are_2_numbers()
        {
            Assert.AreEqual(3, pruebas.add("5,2"));
        }

       

    }
}
