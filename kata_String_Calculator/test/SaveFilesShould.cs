using System;
using NUnit.Framework;
using FluentAssertions;
using System.IO;
using Save;
using System.Linq;

namespace test
{
    [TestFixture]
    public class SaveFilesShould
    {
        private ISaveInterface saveFile;
        private String path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log_test.txt";
        [SetUp]
        public void SetUp()
        {
            saveFile = new SaveFile();

        }

        [Test]
        public void check_ouput_expected() {

            var InTheFile = "prueba de salida";

            saveFile.Save(path, InTheFile);

            var outputOfTheFile = File.ReadAllLines(path).Last();
            Console.WriteLine(outputOfTheFile);
            outputOfTheFile.Should().Be(InTheFile);
        }

    }
}
