using System;
using NUnit.Framework;
using FluentAssertions;
using System.IO;
using Save;

namespace test
{
    [TestFixture]
    public class SaveFilesShould
    {
        private ISaveInterface saveFile;
        private StreamReader sr;
        private String path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log_test.txt";
        [SetUp]
        public void SetUp()
        {
            if (File.Exists(path)) File.Delete(path);
            saveFile = new SaveFile();

        }

        [Test]
        public void check_ouput_expected() {

            var InTheFile = "prueba de salida";

            saveFile.Save(path, InTheFile);

            sr = new StreamReader(path);
            var outputOfTheFile = sr.ReadToEnd();
            outputOfTheFile.Should().Be(InTheFile);
        }

        [TearDown]
        public void TearDown()
        {
            sr.Close();
        }


    }
}
