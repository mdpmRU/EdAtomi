using Operations;

ArithmParse arithm = new();
int X, Y;

Console.Write("Введите первое число: ");
string x = Console.ReadLine();
if (arithm.NumReader(x, out X))
{
    Console.WriteLine("Число успешно распознано");
}
else
{
    Console.WriteLine("Неудачно. По умолчанию 0");
}

Console.Write("Введите второе число: ");
string y = Console.ReadLine();
if(arithm.NumReader(y, out Y))
{
    Console.WriteLine("Число успешно распознано");
}
else
{
    Console.WriteLine("Неудачно. По умолчанию 0");
}

Console.Write("Введите операцию (+, -, *, /): ");
string op = Console.ReadLine();

Console.WriteLine("Первое число: " + X + " Второе число: " + Y);

if (arithm.IsValidOper(op))
{
    if(op == "/" && Y == 0)
    {
        Console.WriteLine("Ошибка деления на ноль");
    }
    else
    {
        Console.WriteLine(arithm.Calcullate(op, X, Y));
    }
}
else
{
    Console.WriteLine("Операция не найдена");
}