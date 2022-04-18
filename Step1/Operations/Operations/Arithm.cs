using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{

    public class Arithm
    {
        public bool IsValidOper(string op_)
        {
            if (op_ != "+" && op_ != "-" && op_ != "*" && op_ != "/")
                return false;
            return true;
        }
        public int Calcullate(string op_, int X, int Y)
        {
            switch (op_)
            {
                case "+":
                    return Sum(X, Y);
                case "-":
                    return Sub(X, Y);
                case "*":
                    return Mult(X, Y);
                case "/":
                    return Div(X, Y);
            }
            return 0;//Код недостижим из-за валидации
        }

    ///Операции
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
}

