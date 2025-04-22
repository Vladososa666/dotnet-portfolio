using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        // Списък за съхранение на задачите
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Добре дошли в TaskManager!");

            while (true)
            {
                Console.WriteLine("\nИзберете опция:");
                Console.WriteLine("1. Добави задача");
                Console.WriteLine("2. Премахни задача");
                Console.WriteLine("3. Покажи всички задачи");
                Console.WriteLine("4. Изход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ShowTasks();
                        break;
                    case "4":
                        Console.WriteLine("Изход от програмата...");
                        return;
                    default:
                        Console.WriteLine("Невалиден избор! Моля, изберете отново.");
                        break;
                }
            }
        }

        // Метод за добавяне на нова задача
        static void AddTask()
        {
            Console.Write("Въведете името на задачата: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Задачата беше добавена успешно.");
        }

        // Метод за премахване на задача
        static void RemoveTask()
        {
            Console.Write("Въведете номера на задачата, която искате да премахнете: ");
            int taskNumber;
            if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("Задачата беше премахната успешно.");
            }
            else
            {
                Console.WriteLine("Невалиден номер на задача.");
            }
        }

        // Метод за показване на всички задачи
        static void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма добавени задачи.");
                return;
            }

            Console.WriteLine("\nСписък с всички задачи:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }
}
