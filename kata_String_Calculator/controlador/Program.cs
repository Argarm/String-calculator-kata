using System;
using kata_String_Calculator;
using Save;
namespace controlador
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator stringCalculator = new StringCalculator();
            ISaveInterface saveFile = new SaveFile();
            SaveAction a = new SaveAction(@"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log.txt",saveFile,stringCalculator);
            a.Execute("1,2,3");

        }
    }
}
