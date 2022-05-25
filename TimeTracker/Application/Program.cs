using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepository = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

void OnSubmitteddTimeChanged(UserData userData)
{
    userData.SubmittedTimeChanged += Notification;
}

void Notification(int hours)
{
    Console.WriteLine($"Общая сумма часов:{hours} ");
}

using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator, OnSubmitteddTimeChanged);

var firstUser = userServices.GetUserById(1);
firstUser.SubmitTime(2,4,"RAz");

var secondUser = userServices.GetUserById(3);





