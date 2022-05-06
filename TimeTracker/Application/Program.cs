using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

UserServices userServices = new UserServices();

UserData user = userServices.GetUserData(1);
user.SubmittedTimeChanged += OnSubmitteddTimeChanged;

//try
//{
//    user.SubmitTime(3, 5, "Proverka");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//var users = userServices.GetUsersForProject(1, 12);

//foreach (User us in users)
//    Console.WriteLine($"{us.FullName}");

var userList = userServices.GetAllActiveUsers();
foreach (var us in userList)
{
    Console.WriteLine(us.User.FullName);
}

void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}

