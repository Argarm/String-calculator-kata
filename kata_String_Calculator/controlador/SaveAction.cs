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
        public SaveAction(String path)
        {
            this.path = path;
            stringCalculator = new StringCalculator();
            saveFile = new SaveFile();

        }

        public void Execute(String numbers) {
            String log = numbers + " el resultado es: ";

            log+= stringCalculator.Add(numbers);

            saveFile.Save(path,log);

        }
    }
}
