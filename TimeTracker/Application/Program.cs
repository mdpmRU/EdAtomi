using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepositories = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

var userServices = new UserServices(userRepositories, timeTrackEntryRepository);

using var mediator = new Mediator(userServices);

mediator.SubscribeToNotify(Notification);

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}
void Notification(string msg)
{
    Console.WriteLine(msg);
}




