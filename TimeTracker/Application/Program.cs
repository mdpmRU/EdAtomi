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
    Console.WriteLine($"Общая сумма часов: {userData.SubmittedTime}");
}


using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

var firstUser = userServices.GetUserById(1);
firstUser.SubmitTime(2,4,"RAz");

var secondUser = userServices.GetUserById(3);





