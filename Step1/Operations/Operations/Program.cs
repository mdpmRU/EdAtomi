int X, Y;
Console.Write("Введите первое число: ");
string x = Console.ReadLine();
try 
{
    X = (int)System.Enum.Parse(typeof(Numbers), x, true);
}
catch (Exception)
{
    Console.WriteLine("Неккоретные данные. Присвоенно 0");
    X = 0;  
}
Console.Write("Введите второе число: ");
string y = Console.ReadLine();
try
{
    Y = (int)System.Enum.Parse(typeof(Numbers), y, true);
}
catch (Exception)
{
    Console.WriteLine("Неккоретные данные. Присвоенно 0");
    Y = 0;
}
Console.Write("Введите операцию (+, -, *, /): ");
string operation = Console.ReadLine();


Console.WriteLine("Первое число: " + X + " Второе число: " + Y);

switch (operation) 
{
    case "+":
        Sum(X, Y);
        break;
    case "-":
        Sub(X, Y);
        break;
    case "*":
        Mult(X, Y);
        break;
    case "/":
        Div(X, Y);
        break;
    default:
        Console.WriteLine("Название операции указано неккоректно");
        break;

}

void Sum(int a, int b){
    int result = a + b;
    Console.WriteLine(result);
}
void Sub(int a, int b)
{
    int result = a - b;
    Console.WriteLine(result);
}
void Mult(int a, int b)
{
    int result = a * b;
    Console.WriteLine(result);
}
void Div(int a, int b)
{
    try
    {
        int result = a / b;
        Console.WriteLine(result);
    }
    catch(DivideByZeroException) 
    {
        Console.WriteLine("Возникло исключение: деление на 0.");
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