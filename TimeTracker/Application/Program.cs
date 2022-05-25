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
var subscriptionId = mediator.SubscribeToSubmittedTimeChanged(OnSubmitteddTimeChanged);
mediator.RaiseSubmittedTimeChanged(firstUser);
firstUser.SubmitTime(3, 4, "Raz");

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}
void Notification(int msg)
{
    Console.WriteLine(msg);
}




