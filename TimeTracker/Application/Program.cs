using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;


string filepathProjectsXml = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\Projects.xml";
string filepathUsers = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\Users.xml";
string filepathTimeTrackEntries = "D:\\AtomiSoft\\EdAtomi\\TimeTracker\\TimeTrackEntries.xml";
UserRepository userRepository = new(filepathUsers);
TimeTrackEntryRepository timeTrackEntryRepository = new(filepathTimeTrackEntries);
ProjectRepository projectRepository = new(filepathProjectsXml);

void OnSubmittedTimeChanged(UserData userData)
{
    Console.WriteLine($"Общая сумма часов: {userData.TotalSubmittedTime}");
}


//var listUsers = Stubs.Users;
//var listProjects = Stubs.Projects;
//var listTimeTrackEntries = Stubs.TimeTrackEntries;
//timeTrackEntryRepository.SaveAll(listTimeTrackEntries);
//userRepository.SaveAll(listUsers);
//projectRepository.SaveAll(listProjects);

var TTE = new TimeTrackEntry()
{
    Id = 10,
    Comment = "Тестирование Insert",
    Date = DateTime.Today,
    ProjectId = 1,
    UserId = 1,
    Value = 12
};
timeTrackEntryRepository.Insert(TTE);

//var user = userRepository.GetById(1);
//Console.WriteLine(user.FullName);


//var listProjectsXML = projectRepository.GetAll().ToList();
//var listTimeTrackEntriesXML = timeTrackEntryRepository.GetAll().ToList();

//userRepository.SaveAll(listUsers);

//projectRepository.SaveAll(listProjects);








using var mediator = new Mediator();
var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

//mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);


//var firstUser = userServices.GetUserById(1);
//firstUser.SubmitTime(2,4,"RAz");
//firstUser.SubmitTime(2, 4, "RAz");






