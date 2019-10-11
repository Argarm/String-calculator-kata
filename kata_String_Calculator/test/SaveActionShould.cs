using NUnit.Framework;
using FluentAssertions;
using System.IO;
using controlador;
using Save;
using kata_String_Calculator;
using System;
using System.Linq;

namespace test
{   
    [TestFixture]
    public class SaveActionShould
    {
        private SaveAction controlador;
        //private StreamReader sr;
        private readonly string path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log_test.txt";

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(path)) File.Delete(path);
            controlador = new SaveAction(path,new SaveFile(),new StringCalculator());
        }


        [Test]
        public void check_if_action_and_save_in_file_works() {
            var given = "1,2,3";
            var ouputThatShouldBeInTheFile = given + " el resultado es: 6";

            controlador.Execute(given);

            
            var linesInTheFile = File.ReadAllLines(path).Last();
            linesInTheFile.Should().Be(ouputThatShouldBeInTheFile);

        }
        [Test]
        public void check_if_trhows_an_exception_and_file_is_empty()
        {
            var given = "1,2,-3";

            Action a = () => controlador.Execute(given);
            
            
            a.Should().Throw<ArgumentException>().WithMessage("Negatives not allowed: -3");
            File.Exists(path).Should().BeFalse();

        }


        

    }
}
