// Код для тестирование зависимости
using DataContracts.Entities;
DateTime a = DateTime.Now;
Project apProject = new Project {Name = "raz", ExpirationDate = a, MaxHours = new DateTime(1), LeaderUserId = 12, Id = 1};
