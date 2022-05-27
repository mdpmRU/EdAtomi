using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepository = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();
ProjectRepository projectRepository = new();

void OnSubmittedTimeChanged(UserData userData)
{
    Console.WriteLine($"Общая сумма часов: {userData.TotalSubmittedTime}");
}


//var listUsers = Stubs.Users;
//var listProjects = Stubs.Projects;
//var listTimeTrackEntries = Stubs.TimeTrackEntries;

var user = userRepository.GetById(1);
Console.WriteLine(user.FullName);


//var listProjectsXML = projectRepository.GetAll().ToList();
//var listTimeTrackEntriesXML = timeTrackEntryRepository.GetAll().ToList();

//userRepository.SaveAll(listUsers);
//timeTrackEntryRepository.SaveAll(listTimeTrackEntries);
//projectRepository.SaveAll(listProjects);








using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

//mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);


//var firstUser = userServices.GetUserById(1);
//firstUser.SubmitTime(2,4,"RAz");
//firstUser.SubmitTime(2, 4, "RAz");






