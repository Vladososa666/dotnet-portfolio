using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static string filePath = "tasks.json";
    static List<TaskItem> tasks = new();

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.Clear();
            ShowTasks();
            Console.WriteLine("\n1. Добави задача");
            Console.WriteLine("2. Маркирай задача като завършена");
            Console.WriteLine("3. Изтрий задача");
            Console.WriteLine("4. Запази и изход");

            Console.Write("\nИзбери опция: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": AddTask(); break;
                case "2": CompleteTask(); break;
                case "3": DeleteTask(); break;
                case "4": SaveTasks(); return;
                default: Console.WriteLine("Невалиден избор!"); break;
            }

            Console.WriteLine("\nНатисни Enter за да продължиш...");
            Console.ReadLine();
        }
    }

    static void ShowTasks()
    {
        Console.WriteLine("📋 Задачи:");
        for (int i = 0; i < tasks.Count; i++)
        {
            var status = tasks[i].IsCompleted ? "[x]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }
    }

    static void AddTask()
    {
        Console.Write("Въведи описание: ");
        string description = Console.ReadLine();
        tasks.Add(new TaskItem { Description = description, IsCompleted = false });
    }

    static void CompleteTask()
    {
        Console.Write("Номер на задача за завършване: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
        }
    }

    static void DeleteTask()
    {
        Console.Write("Номер на задача за изтриване: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
        }
    }

    static void SaveTasks()
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new();
        }
    }
}

class TaskItem
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

