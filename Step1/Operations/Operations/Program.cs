using Operations;

Arithm arithm = new();
int X, Y;
Console.Write("Введите первое число: ");
string x = Console.ReadLine();
Numbers numbers;
if (Enum.TryParse(x[0].ToString().ToUpper() + x.Substring(1), out numbers))
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
if (Enum.TryParse(y[0].ToString().ToUpper() + y.Substring(1), out numbers))
{
    Y = (int)numbers;
}
else
{
    Console.WriteLine("Неудача. По умолчанию 0");
    Y = 0;
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
