delegate void AccountHandler(string message);
event AccountHandler? Notify;
Notify?.Invoke("Произошло действие");

var selected = from p in Stubs.Projects where p.MaxHours > 0 select p;
foreach (Stubs.Project project in selected)
{
    Console.WriteLine($"{project.Name}");
}



public class Stubs
{
    public static DateTime date1 = new DateTime(2015, 7, 20);
    public static DateTime date2 = new DateTime(2015, 8, 20);

    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string Comment { get; set; }
    }

    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int MaxHours { get; set; }

        public int LeaderUserId { get; set; }
    }

    public static List<Project> Projects = new List<Project>()
    {
        new()
        {
            Id = 1,
            ExpirationDate = date1,
            MaxHours = 12,
            LeaderUserId = 1,
            Name = "Raz"

        },
        new()
        {
            Id = 2,
            ExpirationDate = date2,
            MaxHours = 13,
            LeaderUserId = 2,
            Name = "Dva"

        },


    };

    
}
