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


//var timeTrackEntry = new TimeTrackEntry()
//{
//    Id = 10,
//    Comment = "Тестирование Insert",
//    Date = DateTime.Today,
//    ProjectId = 1,
//    UserId = 11,
//    Value = 12
//};
//var user = new User()
//{
//    Id = 10,
//    AccessRole = Role.User,
//    FullName = "Human3",
//    IsActive = true,
//    Password = "123",
//    Username = "Wowan",
//    Comment = "Тестирование Insert",
//};
//var project = new Project()
//{
//    Id = 10,
//    ExpirationDate = new DateTime(2015, 8, 20),
//    MaxHours = 13,
//    LeaderUserId = 11,
//    Name = "Dva",
//    Comment = "Тестирование Insert",
//};
//userRepository.Insert(user);
//timeTrackEntryRepository.Insert(TTE);
//projectRepository.Insert(project);

Console.WriteLine(userRepository.GetById(10).Comment);
Console.WriteLine(timeTrackEntryRepository.GetById(10).Comment);
Console.WriteLine(projectRepository.GetById(10).Comment);

//timeTrackEntryRepository.GetAllForUser(11);
//projectRepository.GetAllByLeader(11);

//using var mediator = new Mediator();
//var userServices = new UserServices(userRepository, timeTrackEntryRepository, mediator);

//mediator.SubscribeToSubmittedTimeChanged(OnSubmittedTimeChanged);


//var firstUser = userServices.GetUserById(1);
//firstUser.SubmitTime(2, 4, "RAz");
//firstUser.SubmitTime(2, 4, "RAz");