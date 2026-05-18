namespace WebApplication2.Controllers;
public class MissionShort
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; }
}