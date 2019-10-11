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
        String path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log.txt";
        [SetUp]
        public void SetUp()
        {
            if (File.Exists(path)) File.Delete(path);
            saveFile = new SaveFile();

        }

        [Test]
        public void check_ouput_expected() {

            string InTheFile = "prueba de salida";

            saveFile.Save(path, InTheFile);

            sr = new StreamReader(path);
            string outputOfTheFile = sr.ReadToEnd();
            outputOfTheFile.Should().Be(InTheFile);
        }

        [TearDown]
        public void TearDown()
        {
            sr.Close();
        }


    }
}
