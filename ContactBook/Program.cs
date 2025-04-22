using System;
using System.Collections.Generic;

namespace ContactBook
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("Contact Book");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. View Contacts");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        RemoveContact();
                        break;
                    case 3:
                        ViewContacts();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            } while (option != 4);
        }

        static void AddContact()
        {
            Console.Write("Enter contact name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter contact email: ");
            string email = Console.ReadLine();

            contacts.Add(new Contact(name, phone, email));
            Console.WriteLine("Contact added!");
        }

        static void RemoveContact()
        {
            Console.Write("Enter contact name to remove: ");
            string name = Console.ReadLine();
            var contact = contacts.Find(c => c.Name.ToLower() == name.ToLower());

            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact removed!");
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
        }

        static void ViewContacts()
        {
            Console.WriteLine("\nContacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
            }
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}

