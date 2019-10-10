using System;
using kata_String_Calculator;
using Save;
namespace controlador
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalculator prueba = new StringCalculator();
            SaveInterface file = new SaveFile();
            string log = "1,2,3";
            log += "El resultado es: " + prueba.add("1,2,3") + "\n";
            file.save(@"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator", log);

        }
    }
}
