using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class Oper
    {
        public void Sum(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }
        public void Sub(int a, int b)
        {
            int result = a - b;
            Console.WriteLine(result);
        }
        public void Mult(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }
        public void Div(int a, int b)
        {
            if (b != 0)
            {
                int result = a / b;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Деление на ноль");
            }
        }
    }
}

