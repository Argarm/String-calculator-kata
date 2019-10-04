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
    }
}
