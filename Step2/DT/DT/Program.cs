using DT;

//For debugging
string input = "21.04.2022 18:30:25";
string input2 = "20.04.2022 18:30:25";

DateTime dateTime = DateTime.Parse(input);
DateTime dateTime2 = DateTime.Parse(input2);

WorkWithDate wwd = new WorkWithDate(dateTime);
WorkWithDate wwd2 = new WorkWithDate(dateTime2);

Console.WriteLine(wwd.SumNowDate);
wwd.DTformat = "G";
Console.WriteLine(wwd.SumNowDate);

Console.WriteLine(wwd.Compare(wwd2));
