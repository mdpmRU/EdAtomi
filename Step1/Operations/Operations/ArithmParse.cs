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

        readonly string[] op = { "+", "-", "*", "/" };
        public bool IsValidOper(string op_)
        {
            if (op_ != op[0] && op_ != op[1] && op_ != op[2] && op_ != op[3])
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

        public int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public int Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }

        public int Mult(int a, int b)
        {
            int result = a * b;
            return result;
        }

        public int Div(int a, int b)
        {
            int result = a / b;
            return result;
        }
    }

    enum Numbers
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }
}

