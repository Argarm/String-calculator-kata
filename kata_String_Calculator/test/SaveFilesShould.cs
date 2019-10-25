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
        private String path = @giveMeTheGeneralDirectory();


        private static string giveMeTheGeneralDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            int indexOfDirectory = workingDirectory.IndexOf("test", 0, workingDirectory.Length);
            string pathOfLogFolder = workingDirectory.Substring(0, indexOfDirectory) + "Logs_test.txt";
            return pathOfLogFolder;
        }
        [SetUp]
        public void SetUp()
        {
            saveFile = new SaveFile();

        }

        [Test]
        public void check_ouput_expected() {

            var InTheFile = "prueba de salida se guarda correctamente";

            saveFile.Save(path, InTheFile);

            var outputOfTheFile = File.ReadAllLines(path).Last();
            Console.WriteLine(outputOfTheFile);
            outputOfTheFile.Should().Be(InTheFile);
        }

    }
}
