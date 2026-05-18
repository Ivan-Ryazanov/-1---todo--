namespace WebApplication2.Controllers;
public class Mission
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime CreatedAt { get; set; } // доп 
    public DateTime UpdatedAt { get; set; } // доп 
    public string Description { get; set; } // доп 
}
