using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;
using Repositories.Xml;
using Solution;


const string projectsFilePath = "..\\..\\..\\..\\Projects.xml";
const string usersFilePath = "..\\..\\..\\..\\Users.xml";
const string timeTrackEntriesFilePath = "..\\..\\..\\..\\TimeTrackEntries.xml";
UserRepository userRepository = new(usersFilePath);
TimeTrackEntryRepository timeTrackEntryRepository = new(timeTrackEntriesFilePath);
ProjectRepository projectRepository = new(projectsFilePath);

void OnSubmittedTimeChanged(UserData userData)
{
    Console.WriteLine($"Общая сумма часов: {userData.TotalSubmittedTime}");
}

Console.WriteLine(userRepository.GetById(10).Comment);
Console.WriteLine(timeTrackEntryRepository.GetById(10).Comment);
Console.WriteLine(projectRepository.GetById(10).Comment);

timeTrackEntryRepository.GetAllForUser(11);
projectRepository.GetAllByLeader(11);

using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);


var firstUser = userServices.GetUserById(1);
firstUser.SubmitTime(2, 4, "RAz");
firstUser.SubmitTime(2, 4, "RAz");