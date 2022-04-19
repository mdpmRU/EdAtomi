using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{

    public class ArithmParse
    {
        public bool NumReader(string Num, out int num)
        {
            Numbers numbers;
            if (Enum.TryParse(Num[0].ToString().ToUpper() + Num.Substring(1), out numbers))
            {
                num = (int)numbers;
                return true;
            }
            else
            {
                num = 0;
                return false;
            }
        }

        private readonly string[] _op = { "+", "-", "*", "/" };
        public bool IsValidOper(string op_)
        {
            if (op_ != _op[0] && op_ != _op[1] && op_ != _op[2] && op_ != _op[3])
                return false;
            return true;
        }

        public int Calcullate(string op_, int X, int Y)
        {
            return op_ switch
            {
                "+" => Sum(X, Y),
                "-" => Sub(X, Y),
                "*" => Mult(X, Y),
                "/" => Div(X, Y),
                _ => 0
            };
        }

        private static int Sum(int a, int b)
        {   
            int result = a + b;
            return result;
        }

        private static int Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }

        private static int Mult(int a, int b)
        {
            int result = a * b;
            return result;
        }

        private static int Div(int a, int b)
        {
            int result = a / b;
            return result;
        }
    }
}

