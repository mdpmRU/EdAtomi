using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepository = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

void OnSubmittedTimeChanged(UserData userData)
{
    Console.WriteLine($"Общая сумма часов: {userData.TotalSubmittedTime}");
}

using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);


var firstUser = userServices.GetUserById(1);
firstUser.SubmitTime(2,4,"RAz");
firstUser.SubmitTime(2, 4, "RAz");






