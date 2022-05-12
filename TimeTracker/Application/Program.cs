using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;
using Repositories.Xml;
using Solution;

var userServices = new UserServices();


//var user = userServices.GetUserData(1);


//Удалить ссылку на xml

//на чтение
//var rx = new RepXML<User>();
//var a = rx.GetAll();

var med = new Mediator();
med.GetUser();

//med.GetProject();
med.GetTimeTrackEntry();

med.Dispose();


foreach (var user1 in med.stubs.Users)
{
    Console.WriteLine($"{user1.FullName}");
}
//// на инсерт
//var a2 = Stubs.Users.First();
//rx.Insert(a2);


//user.SubmittedTimeChanged += OnSubmitteddTimeChanged;

//var activeUsers = userServices.GetUsersForProject(1);
//foreach (var activeUser in activeUsers)
//{
//    Console.WriteLine(activeUser.User.FullName);
//}

//void OnSubmitteddTimeChanged(int hours)
//{
//    Console.WriteLine($"Общая сумма часов: {hours}");
//}



