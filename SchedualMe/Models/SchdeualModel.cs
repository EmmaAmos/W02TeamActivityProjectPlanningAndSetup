namespace SchdeualMe.Models;

public string Title { get; set; } = string.Empty;
public string Description { get; set; } = string.Empty;
public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; } = false;
}
