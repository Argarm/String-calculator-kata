﻿using System;
using System.Collections.Generic;
using System.Text;
using kata_String_Calculator;
using Save;

namespace controlador
{
    public class SaveAction
    {
        private StringCalculator stringCalculator;
        private ISaveInterface saveFile;
        private String path = @"..\Log.txt";


        public SaveAction(StringCalculator stringCalculator)
        {
            this.stringCalculator = stringCalculator;
            saveFile = new SaveFile();
        }

        public StringCalculatorDTO ExecuteAPI(String numbers) {

            String log = numbers + " el resultado es: ";
            try
            {
                var resultadoAdd = stringCalculator.Add(numbers);

                log += resultadoAdd;

                saveFile.Save(path, log);

                return new StringCalculatorDTO{ Numbers = numbers, Resultado = resultadoAdd };

            }
            catch (Exception e)
            {
                return null;
            }
            

        }

        public void Execute(String numbers,String path)
        {
            this.path = path;
            String log = numbers + " el resultado es: ";
            var resultadoAdd = stringCalculator.Add(numbers);

            log += resultadoAdd;

            saveFile.Save(path, log);
        }
    }
}