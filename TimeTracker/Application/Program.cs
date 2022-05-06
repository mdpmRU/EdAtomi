using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

UserServices userServices = new UserServices();

UserData user = userServices.GetUserData(1);
user.SubmittedTimeChanged += OnSubmitteddTimeChanged;

var activeUsers = userServices.GetUsersForProject(1);
foreach (var us in activeUsers )
{
    Console.WriteLine(us.User.FullName);
}

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}

