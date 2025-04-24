using System;

class Program
{
    static void Main()
    {
        string boardFilePath = "kanbanBoard.json";
        KanbanBoard board = JsonHelper.LoadFromJson<KanbanBoard>(boardFilePath) ?? new KanbanBoard();

        Console.WriteLine("Welcome to the Kanban Board!");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Move Task");
        Console.WriteLine("3. Show Board");
        Console.WriteLine("4. Exit");

        bool running = true;
        while (running)
        {
            var choice = Console.ReadKey(true).KeyChar;
            switch (choice)
            {
                case '1':
                    AddTask(board);
                    break;
                case '2':
                    MoveTask(board);
                    break;
                case '3':
                    ShowBoard(board);
                    break;
                case '4':
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        JsonHelper.SaveToJson(boardFilePath, board);
    }

    static void AddTask(KanbanBoard board)
    {
        Console.WriteLine("Enter task description:");
        string description = Console.ReadLine();
        var task = new TaskItem(board.ToDo.Count + 1, description, "ToDo");
        board.AddTask(task);
        Console.WriteLine($"Task {task.Id} added.");
    }

    static void MoveTask(KanbanBoard board)
    {
        Console.WriteLine("Enter task ID to move:");
        int taskId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter column to move to (ToDo, InProgress, Done):");
        string toColumn = Console.ReadLine();
        board.MoveTask(taskId, "ToDo", toColumn);  // For simplicity, moving from ToDo
    }

    static void ShowBoard(KanbanBoard board)
    {
        Console.Clear();
        Console.WriteLine("Kanban Board:");
        Console.WriteLine("To Do:");
        foreach (var task in board.ToDo) Console.WriteLine($"  {task.Id}. {task.Description}");

        Console.WriteLine("In Progress:");
        foreach (var task in board.InProgress) Console.WriteLine($"  {task.Id}. {task.Description}");

        Console.WriteLine("Done:");
        foreach (var task in board.Done) Console.WriteLine($"  {task.Id}. {task.Description}");
    }
}

