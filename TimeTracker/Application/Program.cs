using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

UserServices userServices = new UserServices();

UserData usdata = userServices.GetUserData(2);
usdata.SubmittedTimeChanged += PrintValue;

try
{
    usdata.SubmitTime(3, 4, "Proverka");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var a = userServices.GetUsersForProject(1, 12);

foreach (User users in a)
    Console.WriteLine($"{users.FullName}");

//UpdateUserData(usdata, 3, 4, "Proverka");
//void UpdateUserData(UserData userData, int projectId, int hours, string comment = "")
//{
//    try
//    {
//        userData.SubmitTime(projectId, hours, comment);
//    }
//    catch (Exception exception)
//    {
//        Console.WriteLine(exception.Message);
//    }
//}

void PrintValue(int hours)
{
    Console.WriteLine($"Добавлено: {hours}");
}

