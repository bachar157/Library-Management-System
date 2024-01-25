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
                        LogicofMyProgram.addingBooksToLibrary();
                        break;
                    case "2":
                        LogicofMyProgram.ViewBooks();
                        break;
                    case "3":
                        LogicofMyProgram.SearchingBooks();
                        break;
                    case "4":
                        LogicofMyProgram.BorrowingBooks();
                        break;
                    case "5":
                        LogicofMyProgram.ReturningBooks();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a number between 1 and 5.");
                        break;
                }
                Console.WriteLine("\n------------------------------------ ");

            }
        }
    }
}
