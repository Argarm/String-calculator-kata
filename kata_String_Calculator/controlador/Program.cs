using System;
using kata_String_Calculator;
using Save;
namespace controlador
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveAction a = new SaveAction(@"C:\Users\aargarcia\Desktop\kata\kata_String_Calculator\log.txt");
            a.Execute("1,2,-3");

        }
    }
}
