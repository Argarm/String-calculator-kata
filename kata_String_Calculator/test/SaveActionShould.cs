using NUnit.Framework;
using FluentAssertions;
using System.IO;
using controlador;
using Save;
using kata_String_Calculator;

namespace test
{   
    [TestFixture]
    public class ControladorShould
    {
        private SaveAction controlador;
        private StreamReader sr;
        string path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log_test.txt";

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(path)) File.Delete(path);
            controlador = new SaveAction(path,new SaveFile(),new StringCalculator());
        }


        [Test]
        public void check_if_action_and_save_in_file_works() {
            var given = "1,2,3";
            var ouputInTheFile = given + " el resultado es: 6";

            controlador.Execute(given);

            sr = new StreamReader(path);
            string outputOfTheFile = sr.ReadToEnd();
            outputOfTheFile.Should().Be(ouputInTheFile);

        }

        [TearDown]
        public void TearDown() {
            sr.Close();
        }

    }
}
