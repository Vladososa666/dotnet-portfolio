using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("To-Do List");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Tasks");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        RemoveTask(tasks);
                        break;
                    case "3":
                        ViewTasks(tasks);
                        break;
                    case "4":
                        MarkTaskAsCompleted(tasks);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTask(List<string> tasks)
        {
            Console.Write("Enter the task: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
            Console.ReadKey();
        }

        static void RemoveTask(List<string> tasks)
        {
            Console.Write("Enter the task number to remove: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;

            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks.RemoveAt(taskNumber);
                Console.WriteLine("Task removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.ReadKey();
        }

        static void ViewTasks(List<string> tasks)
        {
            Console.WriteLine("Your Tasks:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to show.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
            Console.ReadKey();
        }

        static void MarkTaskAsCompleted(List<string> tasks)
        {
            Console.Write("Enter the task number to mark as completed: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;

            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                Console.WriteLine($"Task '{tasks[taskNumber]}' is marked as completed.");
                tasks[taskNumber] = "[Completed] " + tasks[taskNumber];
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.ReadKey();
        }
    }
}
