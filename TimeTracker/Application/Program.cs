using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepository = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

var userServices = new UserServices(userRepository, timeTrackEntryRepository);

using var mediator = new Mediator();

var firstUser = userServices.GetUserById(1);
var secondUser = userServices.GetUserById(3);
var subscriptionId = mediator.SubscribeToSubmittedTimeChanged(Subscribe);
firstUser.RaiseSubmittedTimeChanged(secondUser, mediator._subscriptions);
secondUser.SubmitTime(3, 4, "Raz");


void Subscribe(UserData userData)
{
    userData.SubmittedTimeChanged += OnSubmitteddTimeChanged;
}
void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма пользователя {secondUser.User.FullName} часов: {hours}");
}