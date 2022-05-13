using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

var userServices = new UserServices();
//var user = userServices.GetUserData(1);
var stub = new Stubs();
//user.SubmittedTimeChanged += OnSubmitteddTimeChanged;

var med = new Mediator();
//med.NotifyMediator += Notification;
med.SubscribeToNotify(Notification);
med.GetUser();
med.GetProject();
med.GetTimeTrackEntry();
//med.Dispose();


//foreach (var user1 in med.Stub.Users)
//{
//    Console.WriteLine($"{user1.FullName}");
//}

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




