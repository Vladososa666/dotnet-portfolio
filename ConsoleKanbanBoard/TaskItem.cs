public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // To Do, In Progress, Done

    public TaskItem(int id, string description, string status)
    {
        Id = id;
        Description = description;
        Status = status;
    }
}

