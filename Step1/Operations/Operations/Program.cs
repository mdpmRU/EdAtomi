Console.Write("Введите первое число: ");
string x = Console.ReadLine();
Console.Write("Введите второе число: ");
string y = Console.ReadLine();
Console.Write("Введите операцию (+, -, *, /): ");
string operation = Console.ReadLine();
int X , Y;

X = (int)System.Enum.Parse(typeof(Numbers), x, true);
Y = (int)System.Enum.Parse(typeof(Numbers), y, true);
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
    catch 
    {
        Console.WriteLine("Возникло исключение.");
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