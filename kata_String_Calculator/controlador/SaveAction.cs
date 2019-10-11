using System;
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
        String path;
        public SaveAction(String path,ISaveInterface save, StringCalculator stringCalculator)
        {
            this.path = path;
            this.stringCalculator = stringCalculator;
            saveFile = save;

        }

        public void Execute(String numbers) {
            String log = numbers + " el resultado es: ";

            log+= stringCalculator.Add(numbers);

            saveFile.Save(path,log);

        }
    }
}
