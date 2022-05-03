using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts.Entities;
using DataContracts.Entities.Enumerations;

//UserServices userServices = new UserServices();

//UserData usdata=userServices.GetUserData(1);
//userServices.UpdateUserData(usdata);
UserServices userServices = new UserServices();

//UserData usdata = userServices.GetUserData(1);
//UserData usdata2 = new UserData(new User()
//{
//    Id = 1,
//    AccessRole = Role.User,
//    FullName = "New",
//    IsActive = true,
//    Password = "123",
//    Username = "Man"

//});
////usdata.User.Id=2;

//userServices.UpdateUserData(usdata);
var a = userServices.GetUsersForProject(1, 12);

foreach (User users in a)
    Console.WriteLine($"{users.FullName}");

