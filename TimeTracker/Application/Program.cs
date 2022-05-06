using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

var userServices = new UserServices();

var user = userServices.GetUserData(1);
user.SubmittedTimeChanged += OnSubmitteddTimeChanged;

var activeUsers = userServices.GetUsersForProject(1);
foreach (var activeUser in activeUsers)
{
    Console.WriteLine(activeUser.User.FullName);
}

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}

