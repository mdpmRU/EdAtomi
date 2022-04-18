
int X, Y;
Console.Write("Введите первое число: ");
string x = Console.ReadLine();
Numbers numbers;
if (Enum.TryParse(x.ToLower(), out numbers))
{
    X = (int)numbers;
}
else
{
    Console.WriteLine("Неудача. По умолчанию 0");
    X = 0;
}
Console.Write("Введите второе число: ");
string y = Console.ReadLine();
if (Enum.TryParse(y.ToLower(), out numbers))
{
    Y = (int)numbers;
}
else
{
    Console.WriteLine("Неудача. По умолчанию 0");
    Y = 0;
}
Console.Write("Введите операцию (+, -, *, /): ");
string operation = Console.ReadLine();
Console.WriteLine("Первое число: " + X + " Второе число: " + Y);

Operations.Oper op = new();
switch (operation)
{
    case "+":
        op.Sum(X, Y);
        break;
    case "-":
        op.Sub(X, Y);
        break;
    case "*":
        op.Mult(X, Y);
        break;
    case "/":
        op.Div(X, Y);
        break;
    default:
        Console.WriteLine("Название операции указано неккоректно");
        break;

}


enum Numbers
{
    zero,
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine
}
