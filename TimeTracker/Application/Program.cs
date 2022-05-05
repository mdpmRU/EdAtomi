using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

//UserServices userServices = new UserServices();

//UserData usdata=userServices.GetUserData(1);
//userServices.UpdateUserData(usdata);
UserServices userServices = new UserServices();

UserData usdata = userServices.GetUserData(1);

usdata.SubmittedTimeChanged += PrintValue;

userServices.Exception += PrintMsg;
userServices.UpdateUserData(usdata, 3, 4, "Proverka");
var a = userServices.GetUsersForProject(1, 12);

foreach (User users in a)
    Console.WriteLine($"{users.FullName}");

void PrintValue(int hours)
{
    Console.WriteLine($"Добавлено {hours}");
}
void PrintMsg(string msg)
{
    Console.WriteLine(msg);
}
