using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ud07xUnit.Models
{
    public static class Operacions
    {
        public static int Sumar(int a, int b)
        {
            return a + b;
        }

        public static int Restar(int a, int b)
        {
            return a - b;
        }

        public static int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public static string Dividir(int a, int b)
        {
            try
            {
                return (a / b).ToString();
            }
            catch (DivideByZeroException)
            {
                return "Error: División por cero";
            }
        }
    }
}
