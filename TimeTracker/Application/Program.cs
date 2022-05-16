using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

var med = new Mediator();

med.SubscribeToNotify(Notification);

med.GetData();


var activeUsers = med.GetUsersData(true);
foreach (var activeUser in activeUsers)
{
    Console.WriteLine(activeUser.User.FullName);
}

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}
void Notification(string msg)
{
    Console.WriteLine(msg);
}




