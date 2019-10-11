﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Save;
using FluentAssertions;
using System.IO;

namespace test
{
    [TestFixture]
    public class SaveFilesShould
    {
        private ISaveInterface saveFile;

        String path = @"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log.txt";
        [SetUp]
        public void setUp()
        {
            if (File.Exists(path)) File.Delete(path);
            saveFile = new SaveFile();

        }

        [Test]
        public void check_ouput_expected() {
            string numbers = "prueba de salida";

            saveFile.Save(path,numbers);

            StreamReader sr = new StreamReader(path);
            string line = sr.ReadToEnd();
            line.Should().Be(numbers);
        }



    }
}
