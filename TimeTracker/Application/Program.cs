﻿using Business;
using Business.BusinessObjects;
using Business.Services;
using DataContracts;
using DataContracts.Entities;
using Repositories.Xml;
using Solution;

UserRepository userRepositories = new();
TimeTrackEntryRepository timeTrackEntryRepository = new();

var userServices = new UserServices(userRepositories, timeTrackEntryRepository);

using var mediator = new Mediator(userServices);

var a = mediator.userServices.GetUserById(1);

mediator.SubscribeToSubmittedTimeChanged(OnSubmitteddTimeChanged, a);
a.SubmitTime(3, 4, "Raz");
//mediator.UnsubscribeToSubmittedTimeChanged(OnSubmitteddTimeChanged, a);
mediator.Dispose();
a.SubmitTime(3, 4, "Raz");




void OnSubmitteddTimeChanged(int hours)
{
    Console.WriteLine($"Общая сумма часов: {hours}");
}
void Notification(string msg)
{
    Console.WriteLine(msg);
}




