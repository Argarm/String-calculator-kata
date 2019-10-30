using System;
using Model;
using PersistanceFile;

namespace controlador
{
    public class SaveAction
    {
        private StringCalculator stringCalculator;
        private ISave saveFile;
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
            catch (Exception)
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