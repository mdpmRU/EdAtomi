using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepositoriesXml = new();
ProjectRepository projectRepository = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

using var mediator = new Mediator(userRepositoriesXml, projectRepository, timeTrackEntryRepository);
mediator.SubscribeToNotify(Notification);
    
var activeUsers = mediator.GetUsersData(true);

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




