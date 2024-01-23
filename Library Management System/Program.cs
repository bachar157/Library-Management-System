using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library_Management_System_class LogicofMyProgram = new Library_Management_System_class();
            LogicofMyProgram.addingBooksToLibrary();
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1: Adding Books");
                Console.WriteLine("2: Viewing Books");
                Console.WriteLine("3: Searching Books");
                Console.WriteLine("4: Borrowing Books");
                Console.WriteLine("5: Returning Books");
                Console.Write("\nEnter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        addingBooksToLibrary();
                        break;
                    case "2":
                        // Add logic for Viewing Books
                        Console.WriteLine("You have chosen to View Books.");
                        break;
                    case "3":
                        // Add logic for Searching Books
                        Console.WriteLine("You have chosen to Search for Books.");
                        break;
                    case "4":
                        // Add logic for Borrowing Books
                        Console.WriteLine("You have chosen to Borrow Books.");
                        break;
                    case "5":
                        // Add logic for Returning Books
                        Console.WriteLine("You have chosen to Return Books.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a number between 1 and 5.");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
