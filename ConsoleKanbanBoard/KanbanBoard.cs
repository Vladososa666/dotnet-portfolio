using System;
using System.Collections.Generic;

public class KanbanBoard
{
    public List<TaskItem> ToDo { get; set; }
    public List<TaskItem> InProgress { get; set; }
    public List<TaskItem> Done { get; set; }

    public KanbanBoard()
    {
        ToDo = new List<TaskItem>();
        InProgress = new List<TaskItem>();
        Done = new List<TaskItem>();
    }

    public void AddTask(TaskItem task)
    {
        if (ToDo.Count < 10)
            ToDo.Add(task);
        else
            Console.WriteLine("To Do list is full.");
    }

    public void MoveTask(int taskId, string fromColumn, string toColumn)
    {
        TaskItem task = null;
        if (fromColumn == "ToDo")
            task = ToDo.Find(t => t.Id == taskId);
        else if (fromColumn == "InProgress")
            task = InProgress.Find(t => t.Id == taskId);
        else if (fromColumn == "Done")
            task = Done.Find(t => t.Id == taskId);

        if (task != null)
        {
            if (toColumn == "ToDo")
                ToDo.Add(task);
            else if (toColumn == "InProgress")
                InProgress.Add(task);
            else if (toColumn == "Done")
                Done.Add(task);

            Console.WriteLine($"Task {taskId} moved to {toColumn}.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}

